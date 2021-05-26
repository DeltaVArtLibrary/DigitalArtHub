using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtHub.Data;
using ArtHub.Models;
using ArtHub.Data.Interfaces;
using ArtHub.Models.Api;
using Microsoft.AspNetCore.Authorization;

namespace ArtHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ArtHubDbContext _context;
        private readonly IProfileRepository profileRepository;

        public ProfileController(ArtHubDbContext context, IProfileRepository profileRepository)
        {
            _context = context;
            this.profileRepository = profileRepository;
        }

        // GET: api/Profile
        [AllowAnonymous]
        [HttpGet] // Read from database
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetProfiles()
        {
            return Ok(await profileRepository.GetProfiles());
        }

        // GET: api/Profile/5
        [AllowAnonymous]
        [HttpGet("{ProfileId}")] // Read
        public async Task<ActionResult<ProfileDto>> GetProfile(int ProfileId)
        {
            var profile = await profileRepository.GetProfile(ProfileId);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{profileId}")] // Put Update
        public async Task<IActionResult> UpdateProfile(int profileId, CreateProfileDto profile)
        {
            if (profileId != profile.ProfileId)
            {
                return BadRequest();
            }
            if (!await profileRepository.UpdateProfile(profile))
            { 
                return NotFound();
            }

            return NoContent();
        }



        // POST: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost] // Post means create
        public async Task<ActionResult<Profile>> CreateProfile(CreateProfileDto profile)
        {
           
            var profileDto = await profileRepository.CreateProfile(profile);


            return CreatedAtAction("GetProfile", new { profileId = profileDto.Id }, profileDto);
        }


    }
}
