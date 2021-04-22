using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models
{
    public class ArtCollection
    {
        public int ArtId { get; set; }
        public int CollectionId { get; set; }


        // Navigation Properties
        public Collection Collection { get; set; }
        public Art Art { get; set; }
    }
    public class AddToArtCollection
    {
        public int ArtId { get; set; }
        public int CollectionId { get; set; }
    }
}
