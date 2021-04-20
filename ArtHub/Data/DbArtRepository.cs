using ArtHub.Data.Interfaces;
using ArtHub.Models;
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

        public Task<Art> GetArtPiece(int id)
        {
            throw new NotImplementedException();
        }
        /*
public async Task<Art> GetArt(int id)
{
   return await _context.Art.FindAsync(Id);
}
*/
    }
}
