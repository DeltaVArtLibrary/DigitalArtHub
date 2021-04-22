using ArtHub.Models;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IArtCollectionRepository
    {
        Task<bool> AddToCollection(ArtCollection artCollection);
    }
}