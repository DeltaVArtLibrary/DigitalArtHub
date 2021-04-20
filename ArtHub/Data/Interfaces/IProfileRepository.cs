using ArtHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    internal interface IProfileRepository
    {
        
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile(int Id);
        Task PostProfile(Profile profile); // Post means to Create
        Task<bool> PutProfile(Profile Profile); // Put means to Update
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile(int Id);
    }
}