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

        public List<Art> Art { get; set; }
        public List<Collection> Collection { get; set; }
        public List<ProfileMember> ProfileMember { get; set; }
    }
    public class CreateProfileDto
    {
        public int ProfileId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
