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

        public async Task<bool> AddToCollection(ArtCollection artCollection)
        {
            if (ArtCollectionExists(artCollection))
                return false;
            _context.ArtCollections.Add(artCollection);
            await _context.SaveChangesAsync();
            return true;
        }
        private bool ArtCollectionExists(ArtCollection artCollection)
        {
            return _context.ArtCollections.Any(ac => ac.ArtId == artCollection.ArtId && ac.CollectionId == artCollection.CollectionId);

        }
    }
}
