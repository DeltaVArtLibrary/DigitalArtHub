using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models
{
    public class ArtCollection
    {
        // Navigation Properties
        public Collection Collection { get; set; }
        public Art Art { get; set; }
    }
}
