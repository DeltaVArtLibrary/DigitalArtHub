using ArtHub.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models
{
    public class ProfileMember
    {
        public int ProfileId { get; set; }
        public string UserId { get; set; }

        // navigational properties
        public Profile Profile { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class CreateProfileMember
    {
        public int ProfileId { get; set; }
        public string UserId { get; set; }
    }


}
