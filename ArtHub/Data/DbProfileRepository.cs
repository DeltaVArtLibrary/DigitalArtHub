using ArtHub.Models;
using ArtHub.Models.Api;
using ArtHub.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    public class DbProfileRepository : IProfileRepository
    {

        private readonly ArtHubDbContext _context;
        private readonly IUserService userService;

        public DbProfileRepository(ArtHubDbContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        public async Task<ProfileDto> GetProfile(int Id)
        {
            return await _context.Profiles
                .Select(profile => new ProfileDto
                {
                    Description = profile.Description,
                    DisplayName = profile.DisplayName,
                    Id = profile.ProfileId,
                    Members = profile.ProfileMember.Select(p => new ProfileMemberDto
                    {
                        Username = p.User.UserName,
                        UserId = p.UserId,
                    }).ToList()
                })
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<List<ProfileDto>> GetProfiles()
        {
            return await _context.Profiles
                .Select(profile => new ProfileDto
                {
                    Description = profile.Description,
                    DisplayName = profile.DisplayName,
                    Id = profile.ProfileId,
                    Members = profile.ProfileMember.Select(p => new ProfileMemberDto
                    {
                        Username = p.User.UserName,
                        UserId = p.UserId,
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<ProfileDto> CreateProfile(CreateProfileDto profile)
        {
            Profile newProfile = new Profile
            {
                DisplayName = profile.DisplayName,
                Description = profile.Description
            };
            _context.Profiles.Add(newProfile);
            await _context.SaveChangesAsync();

            await CreateProfileMember(new CreateProfileMember
            {
                ProfileId = newProfile.ProfileId,
                UserId = (await userService.GetCurrentUser()).Id
            });

            return await GetProfile(newProfile.ProfileId);
        }
        public async Task<ProfileDto> CreateProfile(CreateProfileDto profile, UserDto user)
        {
            Profile newProfile = new Profile
            {
                DisplayName = profile.DisplayName,
                Description = profile.Description
            };
            _context.Profiles.Add(newProfile);
            await _context.SaveChangesAsync();

            await CreateProfileMember(new CreateProfileMember
            {
                ProfileId = newProfile.ProfileId,
                UserId = user.Id
            });

            return await GetProfile(newProfile.ProfileId);
        }


        public async Task<bool> UpdateProfile(CreateProfileDto profile)
        {

            Profile newProfile = new Profile
            {
                DisplayName = profile.DisplayName,
                Description = profile.Description,
                ProfileId = profile.ProfileId, 
            };

            _context.Entry(newProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(newProfile.ProfileId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }


        private bool ProfileExists(int Id)
        {
            return _context.Profiles.Any(p => p.ProfileId == Id);
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

            return await GetProfile(profileMember.ProfileId);
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
