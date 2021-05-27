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
                    Profile = new ProfileDto { 
                        Id = collection.Profile.ProfileId,
                        Description = collection.Profile.Description,
                        DisplayName = collection.Profile.DisplayName,
                    },
                    Title = collection.Title,
                    Description = collection.Description,
                    Art = collection.ArtCollections.Select(art => new AllArtDto
                    {
                        ArtId = art.ArtId,
                        Title = art.Art.Title,
                        Content = art.Art.Content,
                        Description = art.Art.Description,
                        ProfileId = art.Art.ProfileId,
                        ProfileDisplayName = art.Art.Profile.DisplayName
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
                    Profile = new ProfileDto
                    {
                        Id = collection.Profile.ProfileId,
                        Description = collection.Profile.Description,
                        DisplayName = collection.Profile.DisplayName,
                    },
                    Title = collection.Title,
                    Description = collection.Description,
                    Art = collection.ArtCollections.Select(art => new AllArtDto
                    {
                        ArtId = art.ArtId,
                        Title = art.Art.Title,
                        Content = art.Art.Content,
                        Description = art.Art.Description,
                        ProfileId = art.Art.ProfileId,
                        ProfileDisplayName = art.Art.Profile.DisplayName
                    }).ToList()
                })
                .Where(c => c.CollectionId == collectionId)
                .FirstOrDefaultAsync();
        }
    }
}
