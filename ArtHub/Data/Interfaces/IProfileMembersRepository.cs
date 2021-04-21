using ArtHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public interface IProfileMembersRepository
    {
        Task<List<ProfileMember>> GetProfileMembers();
        Task<ProfileMember> GetProfileMember(int id);
        Task CreateProfileMember(ProfileMember profileMember);
        Task<bool> UpdateProfileMember(int id, ProfileMember profileMember);
    }
}
