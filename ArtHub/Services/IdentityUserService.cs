using ArtHub.Models.Api;
using ArtHub.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace ArtHub.Services
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; }

        public async Task<ApplicationUser> Register(RegisterData data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                // PasswordHash = data.Password
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
                return user;

            foreach(var error in result.Errors)
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
    }
}
