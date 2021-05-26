using ArtHub.Data.Interfaces;
using ArtHub.Models;
using ArtHub.Models.Api;
using ArtHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IProfileRepository profileRepository;
        private readonly IUserService userService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IProfileMembersRepository profileMemberRepository;

        public UsersController(IUserService userService, IProfileRepository profileRepository, IProfileMembersRepository profileMemberRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.profileMemberRepository = profileMemberRepository;
            this.profileRepository = profileRepository;
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        // uses registerData model to create a new user
        [HttpPost("Register")]
        public async Task<ActionResult<ProfileDto>> Register(RegisterData data)
        {
            var user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
                return BadRequest(new ValidationProblemDetails(ModelState));

            CreateProfileDto profile = new CreateProfileDto { DisplayName = data.Username };

            var profileDto = await profileRepository.CreateProfile(profile);

            profileDto = await profileMemberRepository.CreateProfileMember(new CreateProfileMember { ProfileId = profileDto.Id, UserId = user.Id });

            return Ok(profileDto);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user == null)
                return Unauthorized();

            return user;
        }


        [Authorize]
        [HttpGet("Self")]
        public async Task<UserDto> Self() 
        {
            return await userService.GetUser(User);
        }

        [Authorize]
        [HttpGet("Profiles")]
        public async Task<List<ProfileDto>> MyProfiles()
        {
            string userId = (await userService.GetCurrentUser()).Id;
            return await profileMemberRepository.GetProfilesFromUser(userId);
        }
    }
}
