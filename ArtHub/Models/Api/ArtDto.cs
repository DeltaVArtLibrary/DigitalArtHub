using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models.Api
{
    public class ArtDto
    {
        public int ArtId { get; set; }

        public int ProfileId { get; set; }

        public string DisplayName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } 

    }


    namespace ArtHub.Models.Api
    {
        public class ArtPieceDto
        {
            public int ArtId { get; set; }

            public int ProfileId { get; set; }

            public string DisplayName { get; set; }

            public string Title { get; set; }

            public string Content { get; set; } 

            public string Description { get; set; } 

            public DateTime UploadDate { get; set; }

            //public string MediaType { get; set; }
        }
    }
}
