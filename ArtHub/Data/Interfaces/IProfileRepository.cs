using ArtHub.Models;
using ArtHub.Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IProfileRepository
    {
        
        Task<List<Profile>> GetProfiles();
        Task<ProfileDto> GetProfile(int Id);
        Task CreateProfile(Profile profile); // Post means to Create
        Task<bool> UpdateProfile(Profile Profile); // Put means to Update

    }
}