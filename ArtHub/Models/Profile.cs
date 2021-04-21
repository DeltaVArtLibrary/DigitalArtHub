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
        [StringLength(50)]
        public string DisplayName { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        // Navigation Properties

        public Art Art { get; set; }
        public Collection Collection { get; set; }
        public ProfileMember ProfileMember { get; set; }
    }
}
