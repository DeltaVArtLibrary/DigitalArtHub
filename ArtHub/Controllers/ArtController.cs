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

namespace ArtHub.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly ArtHubDbContext _context;
        private readonly IArtRepository artRepository;

        public ArtController(ArtHubDbContext context, IArtRepository artRepository)
        {
            _context = context;
            this.artRepository = artRepository;
        }

        // GET: api/Arts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Art>>> GetAllArt()
        {
            return await _context.Art.ToListAsync();
        }

        // GET: api/Arts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Art>> GetArtPiece(int id)
        {
            var art = await _context.Art.FindAsync(id);

            if (art == null)
            {
                return NotFound();
            }

            return art;
        }

        // PUT: api/Arts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArt(int id, Art art)
        {
            if (id != art.ArtId)
            {
                return BadRequest();
            }

            _context.Entry(art).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtExists(id))
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

        // POST: api/Arts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Art>> PostArt(Art art)
        {
            _context.Art.Add(art);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArt", new { id = art.ArtId }, art);
        }

        // DELETE: api/Arts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArt(int id)
        {
            var art = await _context.Art.FindAsync(id);
            if (art == null)
            {
                return NotFound();
            }

            _context.Art.Remove(art);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtExists(int id)
        {
            return _context.Art.Any(e => e.ArtId == id);
        }
    }
}
