using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class CatalogueController : Controller
    {
        private IDalCatalogue dal;
        public CatalogueController()
        {
            this.dal = new DalCatalogue();
        }
        public IActionResult AnnonceCatalogue()
        {
            
                List<Annonce> listeAnnonce = dal.ObtientAnnonce();
                return View(listeAnnonce);
            
           
        }


    }
}
