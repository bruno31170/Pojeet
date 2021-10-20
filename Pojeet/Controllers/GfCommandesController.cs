using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class GfCommandesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
