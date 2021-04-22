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

namespace ArtHub.Controllers
{
    [Route("api/Profile/{profileId}/Collection")]
    [ApiController]
    public class ProfileCollectionController : ControllerBase
    {
        private readonly ArtHubDbContext _context;
        private readonly IProfileCollectionRepository profileCollectionRepository;

        public ProfileCollectionController(ArtHubDbContext context, IProfileCollectionRepository profileCollectionRepository)
        {
            _context = context;
            this.profileCollectionRepository = profileCollectionRepository;
        }

        // GET: api/Profile/{profileId}/Collection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionDto>>> GetProfileCollections(int profileId)
        {
            return Ok(await profileCollectionRepository.GetAllProfileCollections(profileId));
        }

        // GET: api/Profile/{profileId}/Collection/{collectionId}
        [HttpGet("{collectionId}")]
        public async Task<ActionResult<CollectionDto>> GetCollection(int collectionId)
        {
            var collection = await profileCollectionRepository.GetProfileCollection(collectionId);

            if (collection == null)
            {
                return NotFound();
            }

            return Ok(collection);
        }

        // PUT: api/Profile/{profileId}/Collection/{collectionId}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{collectionId}")]
        public async Task<IActionResult> PutCollection(int profileId, int collectionId, UpdateCollection collection)
        {
            if (collectionId != collection.CollectionId || profileId != collection.ProfileId)
            {
                return BadRequest();
            }

            if (!await profileCollectionRepository.UpdateProfileCollection(collection))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Profile/{profileId}/Collection
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollectionDto>> PostCollection(int profileId, [FromBody] CreateCollection collection)
        {
            if (profileId != collection.ProfileId)
                return BadRequest();
            Collection newCollection = await profileCollectionRepository.CreateCollection(profileId, collection);

            return CreatedAtAction("GetCollection", new { profileId = newCollection.ProfileId, collectionId = newCollection.CollectionId }, newCollection);
        }

        // POST api/Profile/{profileId}/Collection/{collectionId}
        [HttpPost("{collectionId}")]
        public async Task<ActionResult> AddToCollection(int profileId, int collectionId, [FromBody] AddToArtCollection artCollection)
        {
            if (!profileCollectionRepository.CollectionExistsForProfile(profileId, collectionId))
                return BadRequest();
            if (collectionId != artCollection.CollectionId)
                return BadRequest();
            if (!await profileCollectionRepository.AddToCollection(artCollection))
                return BadRequest();
            return NoContent();
        }

        // DELETE: api/Profile/{profileId}/Collection/{collectionId}
        /*[HttpDelete("{collectionId}")]
        public async Task<IActionResult> DeleteCollection(int collectionId)
        {
            throw new NotImplementedException();

            var collection = await _context.Collections.FindAsync(collectionId);
            if (collection == null)
            {
                return NotFound();
            }

            _context.Collections.Remove(collection);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool CollectionExists(int id)
        {
            return _context.Collections.Any(e => e.CollectionId == id);
        }
        */
    }
}
