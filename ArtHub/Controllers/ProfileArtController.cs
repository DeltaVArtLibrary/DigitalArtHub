using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Controllers
{
    [Authorize]
    [Route("api/Profile/{profileId}/Art")]
    [ApiController]
    public class ProfileArtController : ControllerBase
    {
        private readonly IArtRepository artRepository;
        private readonly IFileService fileService;

        public ProfileArtController(IArtRepository artRepository, IFileService fileService)
        {
            this.artRepository = artRepository;
            this.fileService = fileService;
        }
        // GET: api/Art
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<AllArtDto>>> GetAllArt(int profileId)
        {
            var art = await artRepository.GetAllArt();
            return Ok(art.Where(a => a.ProfileId == profileId));
        }

        // GET: api/Art/5
        [AllowAnonymous]
        [HttpGet("{artId}")]
        public async Task<ActionResult<ArtDto>> GetArt(int id)
        {
            var art = await artRepository.GetArt(id);
            if (art == null)
            {
                return NotFound();  //Implicit conversion to ActionResult<Art>
            }

            return art;
        }

        // PUT: api/Arts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{artId}")]
        public async Task<IActionResult> UpdateArt(int profileId, int artId, CreateArtData art)
        {
            if (artId != art.ArtId || profileId != art.ProfileId)
            {
                return BadRequest();
            }

            if (!await artRepository.UpdateArt(art))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Arts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Art>> CreateArt(int profileId, CreateArtData art, IFormFile artImage)
        {
            if (profileId != art.ProfileId)
            {
                return BadRequest();
            }

            var newArt = await artRepository.CreateArt(art);


            return CreatedAtAction("GetArt", new { profileId = newArt.ProfileId, artId = newArt.ArtId }, newArt);
        }

        // DELETE: api/Arts/5
        [Authorize]
        [HttpDelete("{artId}")]
        public async Task<IActionResult> DeleteArt(int profileId, int artId)
        {
            if (!await artRepository.DeleteArt(profileId, artId))
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
