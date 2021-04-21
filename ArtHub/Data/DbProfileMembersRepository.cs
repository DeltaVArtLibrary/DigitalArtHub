using ArtHub.Data.Interfaces;
using ArtHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data
{
    public class DbProfileMembersRepository : IProfileMembersRepository
    {
        private readonly ArtHubDbContext _context;

        public DbProfileMembersRepository(ArtHubDbContext context)
        {
            _context = context;
        }



        public async Task CreateProfileMember(ProfileMember profileMember)
        {
            _context.ProfileMembers.Add(profileMember);
            await _context.SaveChangesAsync();
        }

        public Task<ProfileMember> GetProfileMember(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProfileMember>> GetProfileMembers()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProfileMember(int id, ProfileMember profileMember)
        {
            throw new NotImplementedException();
        }
    }
}
