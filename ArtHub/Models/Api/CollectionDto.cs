using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models.Api
{
    public class CollectionDto
    {
        public int CollectionId { get; set; }
        public ProfileDto Profile { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AllArtDto> Art { get; set; } // swap out for actual Art Dto before merge to main
    }
}
