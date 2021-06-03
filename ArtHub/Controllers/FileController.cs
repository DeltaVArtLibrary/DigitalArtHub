using ArtHub.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Controllers
{   [Route("api/file")]
    [ApiController]
    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromForm] FileModel file)
        {
            return Ok();
        }
      
    }
}
