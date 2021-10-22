using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
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

        public IActionResult AnnonceCatalogue(int id)
        {
                CompteConsumer consumer = dal.ObtientConsumer(id);

                List<Annonce> listeAnnonce = dal.ObtientAnnonce();
                return View(new ProfilViewModel {Annonce=listeAnnonce,CompteConsumer= consumer});
            
           
        }

        public ActionResult Annonce(int id)
        {
            CompteConsumer consumer = dal.ObtientConsumer(id);
            Annonce annonce = dal.ObtientUneAnnonnce(id);
            return View();
        }




    }
}
