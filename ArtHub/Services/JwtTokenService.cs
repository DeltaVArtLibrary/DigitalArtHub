using ArtHub.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Services
{
    public class JwtTokenService
    {
        public async Task<string> GetToken(ApplicationUser user, TimeSpan expiresIn)
        {
            return "token!";
        }
    }
}
