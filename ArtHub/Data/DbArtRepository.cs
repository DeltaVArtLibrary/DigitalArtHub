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
                    Content = art.Content, // Added for front-end
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

        public async Task<ArtDto> CreateArt(CreateArtData art)
        {
            Art newArt = new Art
            {
                ProfileId = art.ProfileId,
                Title = art.Title,
                Content = art.Content,
                UploadDate = DateTime.Now,
                Description = art.Description
            };
            _context.Art.Add(newArt);
            await _context.SaveChangesAsync();
            return await GetArt(newArt.ArtId);
        }

        public async Task<bool> UpdateArt(CreateArtData art)
        {
            Art newArt = new Art
            {
                ArtId = art.ArtId,
                ProfileId = art.ProfileId,
                Title = art.Title,
                Content = art.Content,
                Description = art.Description
            };
            _context.Entry(newArt).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtExists(art.ArtId))
                {
                    return false;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }            
        }

        public async Task<bool> DeleteArt(int profileId, int artId)
        {            
            Art art = await _context.Art.FindAsync(artId); 
            if (art == null || art.ProfileId != profileId)
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

