using ArtHub.Data.Interfaces;
using ArtHub.Models;
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

        public Task<IEnumerable<Art>> GetAllArt()
        {
            throw new NotImplementedException();
        }

        public async Task<Art> GetArtPiece(int id)
        {
            return await _context.Art.FindAsync(id);            
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
            Art art = await GetArtPiece(id);
            if (art == null)
            {
                return false;
            }
            _context.Entry(art).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ArtExists(int id)
        {
            return _context.Art.Any(e => e.ArtId == id);
        }

    }
}

