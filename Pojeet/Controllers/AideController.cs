using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class AideController : Controller
    {
        public IActionResult Aide()
        {
            return View("Aide");
        }
    }
}
