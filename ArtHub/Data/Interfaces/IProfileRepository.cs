using ArtHub.Models;
using ArtHub.Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IProfileRepository
    {
        
        Task<List<ProfileDto>> GetProfiles();
        Task<ProfileDto> GetProfile(int Id);
        Task<ProfileDto> CreateProfile(CreateProfileDto profile); // Post means to Create
        Task<ProfileDto> CreateProfile(CreateProfileDto profile, UserDto user); // work around for first time account creation.
        Task<bool> UpdateProfile(CreateProfileDto Profile); // Put means to Update
        Task<ProfileDto> CreateProfileMember(CreateProfileMember profileMemberCreated);
        Task<List<ProfileDto>> GetProfilesFromUser(string UserId);



    }
}