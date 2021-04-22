using ArtHub.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data
{
    public class DbArtCollectionRepository : IArtCollectionRepository
    {
        private readonly ArtHubDbContext _context;

        public DbArtCollectionRepository(ArtHubDbContext context)
        {
            _context = context;
        }
    }
}
