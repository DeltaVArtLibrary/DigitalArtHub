using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }
    }
}
