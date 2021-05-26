using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data
{
    public class DbProfileMembersRepository : IProfileMembersRepository
    {
        private readonly ArtHubDbContext _context;

        public IProfileRepository ProfileRepository { get; }

        public DbProfileMembersRepository(ArtHubDbContext context, IProfileRepository profileRepository)
        {
            _context = context;
            this.ProfileRepository = profileRepository;
        }

        private bool MemberExists(int p, string m)
        {
            return _context.ProfileMembers.Any(pm => pm.ProfileId == p && pm.UserId == m);
        }
        public async Task<ProfileDto> CreateProfileMember(CreateProfileMember profileMemberCreated)
        {
            ProfileMember profileMember = new ProfileMember { ProfileId = profileMemberCreated.ProfileId, UserId = profileMemberCreated.UserId };
            if (!MemberExists(profileMember.ProfileId, profileMember.UserId))
            {
                _context.ProfileMembers.Add(profileMember);
                await _context.SaveChangesAsync();
            }

            return await ProfileRepository.GetProfile(profileMember.ProfileId);
        }

        public async Task<List<ProfileDto>> GetProfilesFromUser(string UserId)
        {
            return await _context.ProfileMembers.Where(pm => pm.UserId == UserId).Select(pm => new ProfileDto
            {
                Id = pm.Profile.ProfileId,
                DisplayName = pm.Profile.DisplayName,
                Description = pm.Profile.Description,
                Members = pm.Profile.ProfileMember.Select(p => new ProfileMemberDto
                {
                    Username = p.User.UserName,
                    UserId = p.UserId,
                }).ToList()
            }).ToListAsync();
        }
    }
}
