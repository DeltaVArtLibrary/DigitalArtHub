using ArtHub.Data.Interfaces;
using ArtHub.Models;
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

        public async Task<bool> AddToCollection(AddToArtCollection artCollection)
        {
            if (ArtCollectionExists(artCollection) || ArtAndCollectionExist(artCollection))
                return false;
            ArtCollection newAddition = new ArtCollection
            {
                ArtId = artCollection.ArtId,
                CollectionId = artCollection.CollectionId
            };
            _context.ArtCollections.Add(newAddition);
            await _context.SaveChangesAsync();
            return true;
        }
        private bool ArtCollectionExists(AddToArtCollection artCollection)
        {
            return _context.ArtCollections.Any(ac => ac.ArtId == artCollection.ArtId && ac.CollectionId == artCollection.CollectionId);
        }
        private bool ArtAndCollectionExist(AddToArtCollection artCollection)
        {
            bool artExists = _context.Art.Any(a => a.ArtId == artCollection.ArtId);
            bool collectionExists = _context.Collections.Any(c => c.CollectionId == artCollection.CollectionId);
            return artExists && collectionExists;
        }
    }
}
