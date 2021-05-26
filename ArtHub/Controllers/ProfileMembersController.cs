using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtHub.Data;
using ArtHub.Models;
using ArtHub.Data.Interfaces;
using ArtHub.Models.Api;
using Microsoft.AspNetCore.Authorization;

namespace ArtHub.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileMembersController : ControllerBase
    {
        
        private readonly IProfileRepository profileRepository;

        public ProfileMembersController(ArtHubDbContext context, IProfileRepository profileRepository)
        {
            
            this.profileRepository = profileRepository;
        }




        // POST: api/ProfileMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProfileDto>> PostProfileMember(CreateProfileMember profileMember)
        {

            return Ok(await profileRepository.CreateProfileMember(profileMember));
        }

    }
}
