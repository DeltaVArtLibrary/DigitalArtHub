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
    public class ProfileMembersController : ControllerBase
    {
        private readonly ArtHubDbContext _context;
        private readonly IProfileMembersRepository profileMembersRepository;

        public ProfileMembersController(ArtHubDbContext context, IProfileMembersRepository profileMembersRepository)
        {
            _context = context;
            this.profileMembersRepository = profileMembersRepository;
        }

        // GET: api/ProfileMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileMember>>> GetProfileMembers()
        {
            return await _context.ProfileMembers.ToListAsync();
        }

        // GET: api/ProfileMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileMember>> GetProfileMember(int id)
        {
            var profileMember = await _context.ProfileMembers.FindAsync(id);

            if (profileMember == null)
            {
                return NotFound();
            }

            return profileMember;
        }

        // PUT: api/ProfileMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileMember(int id, ProfileMember profileMember)
        {
            if (id != profileMember.ProfileId)
            {
                return BadRequest();
            }

            _context.Entry(profileMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileMemberExists(id))
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

        // POST: api/ProfileMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfileMember>> PostProfileMember(ProfileMember profileMember)
        {
            _context.ProfileMembers.Add(profileMember);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfileMemberExists(profileMember.ProfileId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfileMember", new { id = profileMember.ProfileId }, profileMember);
        }

        /*// DELETE: api/ProfileMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileMember(int id)
        {
            var profileMember = await _context.ProfileMembers.FindAsync(id);
            if (profileMember == null)
            {
                return NotFound();
            }

            _context.ProfileMembers.Remove(profileMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }*/

        private bool ProfileMemberExists(int id)
        {
            return _context.ProfileMembers.Any(e => e.ProfileId == id);
        }
    }
}
