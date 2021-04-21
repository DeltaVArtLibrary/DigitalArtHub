using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models.Api
{
    public class ProfileMemberDto
    {
        public string Username { get; set; } // change to display name once added to user Table
        public string UserId { get; set; }
    }
}
