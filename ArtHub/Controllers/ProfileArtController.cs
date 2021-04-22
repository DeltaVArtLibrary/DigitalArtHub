using ArtHub.Data.Interfaces;
using ArtHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Controllers
{
    [Route("api/Profile/{profileId/Art")]
    [ApiController]
    public class ProfileArtController : ControllerBase
    {
        private readonly IArtRepository artRepository;

        public ProfileArtController(IArtRepository artRepository)
        {
            this.artRepository = artRepository;
        }
        // PUT: api/Arts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        [HttpPost]
        public async Task<ActionResult<Art>> CreateArt(CreateArtData art)
        {
            var newArt = await artRepository.CreateArt(art);


            return CreatedAtAction("GetArt", new { id = newArt.ArtId }, newArt);
        }

        // DELETE: api/Arts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArt(int id)
        {
            if (!await artRepository.DeleteArt(id))
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
