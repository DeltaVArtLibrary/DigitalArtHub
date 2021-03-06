using ArtHub.Models.Api;
using ArtHub.Models.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtHub.Services
{
    public interface IUserService
    {
        Task<UserDto> Register(RegisterData data, ModelStateDictionary modelState);
        Task<UserDto> Authenticate(string username, string password);
        Task<UserDto> GetCurrentUser();
        Task<UserDto> GetUser(ClaimsPrincipal user);
    }
}
