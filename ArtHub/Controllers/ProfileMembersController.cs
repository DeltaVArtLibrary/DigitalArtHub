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
        
        private readonly IProfileMembersRepository profileMembersRepository;

        public ProfileMembersController(ArtHubDbContext context, IProfileMembersRepository profileMembersRepository)
        {
            
            this.profileMembersRepository = profileMembersRepository;
        }




        // POST: api/ProfileMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProfileDto>> PostProfileMember(ProfileMember profileMember)
        {

            return Ok(await profileMembersRepository.CreateProfileMember(profileMember));
        }

    }
}
