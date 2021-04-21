using ArtHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IProfileRepository
    {
        
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile(int Id);
        Task CreateProfile(Profile profile); // Post means to Create
        Task<bool> UpdateProfile(Profile Profile); // Put means to Update

    }
}