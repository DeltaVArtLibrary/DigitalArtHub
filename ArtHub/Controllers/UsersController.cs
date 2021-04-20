using ArtHub.Models.Api;
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
        // uses registerData model to create a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterData data)
        {
            return Ok();
        }
    }
}
