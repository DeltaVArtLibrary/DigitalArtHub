using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data
{
    public class DbArtRepository : IArtRepository
    {
        private readonly ArtHubDbContext _context;

        public DbArtRepository (ArtHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<AllArtDto>> GetAllArt()
        {
            return await _context.Art
                .Select(art => new AllArtDto
                {
                    ArtId = art.ArtId,
                    Title = art.Title,
                    Description = art.Description,

                    ProfileId = art.ProfileId,
                    ProfileDisplayName = art.Profile.DisplayName,
                })
            .ToListAsync();
        }
        
        public async Task<ArtDto> GetArt(int id)
        {
            return await _context.Art
                .Select(art => new ArtDto
                {
                    ArtId = art.ArtId,
                    Title = art.Title,
                    Description = art.Description,
                    Content = art.Content,
                    UploadDate = art.UploadDate,

                    ProfileId = art.ProfileId,
                    ProfileDisplayName = art.Profile.DisplayName,
                })

            .FirstOrDefaultAsync(a => a.ArtId == id);
            
        }

        public async Task CreateArt(Art art)
        {
            _context.Art.Add(art);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateArt(int id, Art art)
        {
            _context.Entry(art).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtExists(id))
                {
                    return false;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }            
        }

        public async Task<bool> DeleteArt(int id)
        {            
            Art art = await _context.Art.FindAsync(id); 
            if (art == null)
            {
                return false;
            }
            _context.Remove(art);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ArtExists(int id)
        {
            return _context.Art.Any(e => e.ArtId == id);
        }
    }
}

