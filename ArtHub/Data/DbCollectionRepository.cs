using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data
{
    public class DbCollectionRepository : ICollectionRepository
    {
        private readonly ArtHubDbContext _context;

        public DbCollectionRepository(ArtHubDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CollectionDto>> GetAllCollections()
        {
            throw new NotImplementedException();
        }
    }
}
