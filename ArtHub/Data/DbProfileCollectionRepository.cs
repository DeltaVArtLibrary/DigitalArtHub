using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data
{
    public class DbProfileCollectionRepository : IProfileCollectionRepository
    {
        private readonly ArtHubDbContext _context;

        public DbProfileCollectionRepository(ArtHubDbContext context)
        {
            _context = context;
        }

        public async Task CreateCollection(int profileId, CreateCollection collection)
        {
            Collection newCollection = new Collection {
                Title = collection.Title,
                ProfileId = profileId
            };
            _context.Collections.Add(newCollection);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<CollectionDto>> GetAllProfileCollections(int profileId)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionDto> GetProfileCollection(int profileId, int collectionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProfileCollection(int profileId, int collectionId)
        {
            throw new NotImplementedException();
        }
    }
}
