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
using static ArtHub.Models.Api.AllArtDto;
using Microsoft.AspNetCore.Authorization;

namespace ArtHub.Controllers 
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : ControllerBase
    {
        private readonly IArtRepository artRepository;

        public ArtController(IArtRepository artRepository)
        {
            this.artRepository = artRepository;
        }

        // GET: api/Art
        [AllowAnonymous]

        [HttpGet]
        public async Task<ActionResult<List<AllArtDto>>> GetAllArt()
        {
            var art = await artRepository.GetAllArt(); 
            return Ok(art);
        }

        // GET: api/Art/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtDto>> GetArt(int id)
        {
            var art = await artRepository.GetArt(id);
            if (art == null)
            {
                return NotFound();  //Implicit conversion to ActionResult<Art>
            }

            return art;
        }
    }
}
