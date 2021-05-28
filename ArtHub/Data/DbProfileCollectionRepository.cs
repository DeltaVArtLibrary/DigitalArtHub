using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Collection> CreateCollection(int profileId, CreateCollection collection)
        {
            Collection newCollection = new Collection {
                Title = collection.Title,
                ProfileId = profileId
            };
            _context.Collections.Add(newCollection);
            await _context.SaveChangesAsync();
            return newCollection;
        }

        public async Task<IEnumerable<CollectionDto>> GetAllProfileCollections(int profileId)
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
                .Where(c => c.Profile.Id == profileId)
                .ToListAsync();

        }

        public async Task<bool> UpdateProfileCollection(UpdateCollection collection)
        {
            Collection updatedCollection = new Collection { CollectionId = collection.CollectionId, Title = collection.Title, Description = collection.Description, ProfileId = collection.ProfileId};
            _context.Entry(updatedCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(updatedCollection.CollectionId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }
        public async Task<bool> AddToCollection(AddToArtCollection artCollection)
        {
            if (ArtExistsInCollection(artCollection))
                return false;
            if (!ArtAndCollectionExist(artCollection))
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
        private bool ArtExistsInCollection(AddToArtCollection artCollection)
        {
            return _context.ArtCollections.Any(ac => ac.ArtId == artCollection.ArtId && ac.CollectionId == artCollection.CollectionId);
        }
        private bool ArtAndCollectionExist(AddToArtCollection artCollection)
        {
            bool artExists = _context.Art.Any(a => a.ArtId == artCollection.ArtId);
            bool collectionExists = _context.Collections.Any(c => c.CollectionId == artCollection.CollectionId);
            return artExists && collectionExists;
        }

        private bool CollectionExists(int collectionId)
        {
            return _context.Collections.Any(c => c.CollectionId == collectionId);
        }
        public bool CollectionExistsForProfile(int profileId, int collectionId)
        {
            return _context.Collections.Any(c => c.ProfileId == profileId && c.CollectionId == collectionId);
        }
    }
}
