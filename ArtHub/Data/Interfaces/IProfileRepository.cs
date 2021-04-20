using ArtHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    internal interface IProfileRepository
    {
        
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile(int Id);
        Task PostProfile(Profile profile); // Post means to Create
        Task<bool> PutProfile(Profile Profile); // Put means to Update

    }
}