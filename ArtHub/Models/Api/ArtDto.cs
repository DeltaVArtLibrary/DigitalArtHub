using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models.Api
{
    public class AllArtDto
    {
        public int ArtId { get; set; }
        public string Content { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ProfileId { get; set; }

        public string ProfileDisplayName { get; set; }

    }   

    public class ArtDto
    {
        public int ArtId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; } 

        public string Description { get; set; } 

        public DateTime UploadDate { get; set; }

        public int ProfileId { get; set; }

        public string ProfileDisplayName { get; set; }

        //public string MediaType { get; set; }
        
    }
}
