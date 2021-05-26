using ArtHub.Models.Api;
using ArtHub.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ArtHub.Services
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtTokenService tokenService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IdentityUserService(UserManager<ApplicationUser> userManager, JwtTokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<UserDto> Authenticate(string username, string password)
        {
           var user = await userManager.FindByNameAsync(username);
            if (await userManager.CheckPasswordAsync(user, password))
                return await GetUserDtoAsync(user);

            return null;

        }

        public async Task<UserDto> GetCurrentUser()
        {
            var principal = httpContextAccessor.HttpContext.User;
            return await GetUser(principal);
        }

        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            return await GetUserDtoAsync(user);
        }

        public async Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                // PasswordHash = data.Password
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
                return await GetUserDtoAsync(user);

            // Create Profile from user data
          

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }

        private async Task<UserDto> GetUserDtoAsync(ApplicationUser user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await tokenService.GetToken(user, TimeSpan.FromMinutes(30)),
            };
        }
    }
}
