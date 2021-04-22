using ArtHub.Data.Interfaces;
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

        public ArtCollectionController(IArtCollectionRepository artCollectionRepository)
        {
            this.artCollectionRepository = artCollectionRepository;
        }
    }
}
