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

        public DbProfileRepository(ArtHubDbContext context)
        {
            _context = context;
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

        public async Task<List<Profile>> GetProfiles()
        {

            // may change to use Dto
            return await _context.Profiles.ToListAsync();
        }

        public async Task<ProfileDto> CreateProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> UpdateProfile(Profile profile)
        {
            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(profile.ProfileId))
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

    }
}
