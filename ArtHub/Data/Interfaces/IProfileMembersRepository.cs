using ArtHub.Models;
using ArtHub.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IProfileMembersRepository
    {
      
        /*Task<List<ProfileMember>> GetProfileMembers();*/ // MAYBE NO NEED
        /*        Task<ProfileMember> GetProfileMember(int id);*/ // DO WE NEED THIS?!
        Task<ProfileDto> CreateProfileMember(ProfileMember profileMember);
        /*Task<bool> UpdateProfileMember(int id, ProfileMember profileMember);*/ // USERSTORY SAYS NO
    }
}
