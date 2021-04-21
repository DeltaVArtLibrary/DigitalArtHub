using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models.Api
{
    public class ProfileDto
    {

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<ProfileMemberDto> Members { get; set; }

    }
}
