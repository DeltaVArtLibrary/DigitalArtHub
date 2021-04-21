using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models.Api
{
    public class CollectionDto
    {
        public int CollectionId { get; set; }
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MyProperty { get; set; }
        public List<tempArtDto> Art { get; set; }
    }
    public class tempArtDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
