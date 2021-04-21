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
    public class DbCollectionRepository : ICollectionRepository
    {
        private readonly ArtHubDbContext _context;

        public DbCollectionRepository(ArtHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CollectionDto>> GetAllCollections()
        {
            return await _context.Collections
                .Select(collection => new CollectionDto
                {
                    CollectionId = collection.CollectionId,
                    ProfileId = collection.ProfileId,
                    Title = collection.Title,
                    Description = collection.Description,
                    Art = collection.ArtCollections.Select(art => new tempArtDto
                    {
                        Id = art.ArtId,
                        Title = art.Art.Title
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<CollectionDto> GetCollection(int collectionId)
        {
            return await _context.Collections
                .Select(collection => new CollectionDto
                {
                    CollectionId = collection.CollectionId,
                    ProfileId = collection.ProfileId,
                    Title = collection.Title,
                    Description = collection.Description,
                    Art = collection.ArtCollections.Select(a => new tempArtDto
                    {
                        Id = a.ArtId,
                        Title = a.Art.Title
                    }).ToList()
                })
                .Where(c => c.CollectionId == collectionId)
                .FirstOrDefaultAsync();
        }
    }
}
