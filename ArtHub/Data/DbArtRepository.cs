using ArtHub.Data.Interfaces;
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
        /*
        public async Task<Art> GetArt(int id)
        {
            return await _context.Art.FindAsync(Id);
        }
        */
    }
}
