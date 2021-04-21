using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtHub.Data;
using ArtHub.Models;
using ArtHub.Data.Interfaces;
using ArtHub.Models.Api;

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
        [HttpGet] // Read from database
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            var profile = await profileRepository.GetProfiles(); // Wat is this 
            return await _context.Profiles.ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")] // Read
        public async Task<ActionResult<ProfileDto>> GetProfile(int id)
        {
            var profile = await _context.Profiles.Select(profile => new ProfileDto
            {
               Id = profile.ProfileId,
               DisplayName = profile.DisplayName,
               Description = profile.Description


            }).FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")] // Put Update
        public async Task<IActionResult> UpdateProfile(int id, Profile profile)
        {
            if (id != profile.ProfileId)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost] // Post means create
        public async Task<ActionResult<Profile>> CreateProfile(Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            var dto = new ProfileDto()
            {
                Id = profile.ProfileId,
                DisplayName = profile.DisplayName,
                Description = profile.Description
            };
            return CreatedAtAction("GetProfile", new { Id = profile.ProfileId }, dto);
        }


        /*
        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.ProfileId == id);
        }
    }
}
