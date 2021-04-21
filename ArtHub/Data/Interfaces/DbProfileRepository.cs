using ArtHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtHub.Data.Interfaces
{
    class DbProfileRepository : IProfileRepository
    {

        private readonly ArtHubDbContext _context;

        public DbProfileRepository(ArtHubDbContext context)
        {
            this._context = context;
        }

        public Task<Profile> GetProfile(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
            throw new NotImplementedException();
        }

        public async Task PostProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> PutProfile(Profile profile)
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
            throw new NotImplementedException();
        }

    }
}
