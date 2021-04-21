using ArtHub.Models;
using ArtHub.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IProfileCollectionRepository
    {
        Task CreateCollection(int profileId, CreateCollection collection);
        Task<IEnumerable<CollectionDto>> GetAllProfileCollections(int profileId);
        Task<CollectionDto> GetProfileCollection(int profileId, int collectionId);
        Task<bool> UpdateProfileCollection(int profileId, int collectionId);

    }
}
