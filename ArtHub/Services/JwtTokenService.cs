using ArtHub.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHub.Services
{
    public class JwtTokenService
    {
        // constuctor from Keith
        private readonly IConfiguration configuration;
        private readonly SignInManager<ApplicationUser> signInManager;

        public JwtTokenService(IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
        }
        public async Task<string> GetToken(ApplicationUser user, TimeSpan expiresIn)
        {
            var principal = await signInManager.CreateUserPrincipalAsync(user);
            if (principal == null)
                return null;

            var signingKey = GetSecurityKey(configuration);

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow + expiresIn,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: principal.Claims
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secret = configuration["JWT:Secret"];

            if (secret == null)
                throw new InvalidOperationException("JWT:Secret is missing!");

            var secretBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(secretBytes);
        }

        /*internal static TokenValidationParameters GetValidationParameters(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),

                // simplify testing
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
            };
        }*/
    }
}
