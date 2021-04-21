using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
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

        private bool MemberExists(int p, string m)
        {
            return _context.ProfileMembers.Any(pm => pm.ProfileId == p && pm.UserId == m);
        }
        public async Task<ProfileDto> CreateProfileMember(ProfileMember profileMember)
        {
            if (!MemberExists(profileMember.ProfileId, profileMember.UserId))
            {
                _context.ProfileMembers.Add(profileMember);
                await _context.SaveChangesAsync();
            }

            return await new DbProfileRepository(_context).GetProfile(profileMember.ProfileId);
        }


    }
}
