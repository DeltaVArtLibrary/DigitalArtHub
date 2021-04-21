using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models
{
    public class Collection
    {
        [Required]
        public int ProfileId { get; set; }

        public int CollectionId { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        // Navigation Properties
        public Profile Profile { get; set; }


    }
    public class CreateCollection
    {
        public string Title { get; set; }
        public int ProfileId { get; set; }
    }
    public class UpdateCollection
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
