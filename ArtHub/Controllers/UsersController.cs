using ArtHub.Models.Api;
using ArtHub.Services;
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
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // uses registerData model to create a new user
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterData data)
        {
            var user = await userService.Register(data, this.ModelState);
            if (!ModelState.IsValid)
                return BadRequest(new ValidationProblemDetails(ModelState));

            return Ok(user);
        }
    }
}
