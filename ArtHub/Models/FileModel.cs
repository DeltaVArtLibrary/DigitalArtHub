using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Models
{
    public class FileModel
    {
        public string ArtFile { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
