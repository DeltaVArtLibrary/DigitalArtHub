using ArtHub.Models.Api;
using ArtHub.Models.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> Register(RegisterData data, ModelStateDictionary modelState);
    }
}
