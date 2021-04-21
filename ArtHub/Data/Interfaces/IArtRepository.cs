using ArtHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IArtRepository
    {
        Task<IEnumerable<Art>> GetAllArt();
        Task<Art> GetArt(int id);
        Task CreateArt(Art art);
        Task<bool> UpdateArt(int id, Art art);
        Task<bool> DeleteArt(int id);
    }
}
