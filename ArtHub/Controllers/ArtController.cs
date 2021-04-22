using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtHub.Data;
using ArtHub.Models;
using ArtHub.Data.Interfaces;
using ArtHub.Models.Api;
using static ArtHub.Models.Api.AllArtDto;

namespace ArtHub.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly IArtRepository artRepository;

        public ArtController(IArtRepository artRepository)
        {
            this.artRepository = artRepository;
        }

        // GET: api/Art
        [HttpGet]
        public async Task<ActionResult<List<AllArtDto>>> GetAllArt()
        {
            var art = await artRepository.GetAllArt(); 
            return Ok(art);
        }

        // GET: api/Art/5
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArt(int id, Art art)
        {
            if (id != art.ArtId) 
            {
                return BadRequest();
            }

            if (!await artRepository.UpdateArt(id, art))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Arts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Art>> CreateArt(Art art)
        {
            await artRepository.CreateArt(art);

            return CreatedAtAction("GetArt", new { id = art.ArtId }, art);
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
