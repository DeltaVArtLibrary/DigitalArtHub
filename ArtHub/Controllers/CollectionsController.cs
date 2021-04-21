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

namespace ArtHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ArtHubDbContext _context;
        private readonly ICollectionRepository collectionRepository;

        public CollectionsController(ArtHubDbContext context, ICollectionRepository collectionRepository)
        {
            _context = context;
            this.collectionRepository = collectionRepository;
        }

        // GET: api/Collections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollections()
        {
            return Ok(await collectionRepository.GetAllCollections());
        }
    }
}