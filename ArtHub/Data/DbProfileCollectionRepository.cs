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
                    ProfileId = collection.ProfileId,
                    Title = collection.Title,
                    Description = collection.Description,
                    Art = collection.ArtCollections.Select(a => new tempArtDto
                    {
                        Id = a.ArtId,
                        Title = a.Art.Title
                    }).ToList()
                })
                .Where(c => c.ProfileId == profileId)
                .ToListAsync();

        }

        public async Task<CollectionDto> GetProfileCollection(int collectionId)
        {
            return await new DbCollectionRepository(_context).GetCollection(collectionId);
        }

        public async Task<bool> UpdateProfileCollection(Collection collection)
        {
            _context.Entry(collection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Save worked
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(collection.CollectionId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }

        private bool CollectionExists(int collectionId)
        {
            return _context.Collections.Any(c => c.CollectionId == collectionId);
        }
        public bool ValidateCollection(int profileId, int collectionId)
        {
            return _context.Collections.Any(c => c.ProfileId == profileId && c.CollectionId == collectionId);
        }
    }
}
