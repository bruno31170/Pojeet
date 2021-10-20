using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class AnnonceController : Controller
    {
        private IDalAnnonce dal;
        public AnnonceController()
        {
            this.dal = new DalAnnonce();
        }
        
        
        public IActionResult PosterAnnonce()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PosterAnnonce(Annonce annonce)
        {
            if (!ModelState.IsValid)
                return View("Error");
            dal.PosterAnnonce(annonce.TitreAnnonce, annonce.Description, annonce.DateParution, annonce.Localisation, annonce.DateButoir, annonce.Prix);
            return RedirectToAction("Reussi");
        }


        public IActionResult SupprimerAnnonce()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SupprimerAnnonce(int id)
        {
            dal.SupprimerAnnonce(id);
            return RedirectToAction("Reussi");
        }
    }
}
