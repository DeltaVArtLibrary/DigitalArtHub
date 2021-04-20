using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHub.Controllers
{
    public class ArtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
