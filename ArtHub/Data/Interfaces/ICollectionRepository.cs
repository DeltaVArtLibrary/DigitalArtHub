using ArtHub.Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface ICollectionRepository
    {
        Task<IEnumerable<CollectionDto>> GetAllCollections();
        Task<CollectionDto> GetCollection(int collectionId);

    }
}