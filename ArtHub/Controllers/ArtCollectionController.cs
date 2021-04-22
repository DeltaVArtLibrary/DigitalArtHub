using ArtHub.Data.Interfaces;
using ArtHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Controllers
{
    [Route("api/Profile/{profileId}/Collection/{collectionId}")]
    [ApiController]
    public class ArtCollectionController : ControllerBase
    {
        private readonly IArtCollectionRepository artCollectionRepository;
        private readonly IProfileCollectionRepository profileCollectionRepository;

        public ArtCollectionController(IArtCollectionRepository artCollectionRepository, IProfileCollectionRepository profileCollectionRepository)
        {
            this.artCollectionRepository = artCollectionRepository;
            this.profileCollectionRepository = profileCollectionRepository;
        }
        // POST api/Profile/{profileId}/Collection/{collectionId}
        [HttpPost]
        public async Task<ActionResult> AddToCollection(int profileId, int collectionId, [FromBody] AddToArtCollection artCollection)
        {
            if (!profileCollectionRepository.CollectionExistsForProfile(profileId, collectionId))
                return BadRequest();
            if (collectionId != artCollection.CollectionId)
                return BadRequest();
            if (!await artCollectionRepository.AddToCollection(artCollection))
                return BadRequest();
            return NoContent();
        }
    }
}
