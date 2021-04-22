using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models
{
    public class Art
    {
        public int ArtId { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(1500)]
        public string Description { get; set; } 

        public string MediaType { get; set; }

        public DateTime UploadDate { get; set; }

        [Required]
        public int ProfileId { get; set; }

        //Navigation Properties

        public Profile Profile { get; set; }

    }
    public class CreateArtData
    {
        public int ArtId { get; set; }
        public int ProfileId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
    }
}
