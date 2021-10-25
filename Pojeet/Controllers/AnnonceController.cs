using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class AnnonceController : Controller
    {
        private IDalAnnonce idal;
        
        public AnnonceController()
        {
            this.idal = new DalAnnonce();
        }
        
        
        public IActionResult PosterAnnonce()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PosterAnnonce(Annonce annonce)
        {
            
                //if (!ModelState.IsValid)
                   // return View("Error");
                idal.PosterAnnonce(annonce.TypeDeAnnonce, annonce.TitreAnnonce, annonce.Description, annonce.DateParution,
                    annonce.Localisation, annonce.DateButoir, annonce.Prix, annonce.CategorieDeAnnonce, annonce.Photo);
            
            return View("Reussi"); //Retourner view mes annonces
        }

       
        
        public ActionResult SupprimerAnnonce(int id)
        {
            idal.SupprimerAnnonce(id);
            return Redirect("~/Profil/Index"); //Retourner view mes annonces
        }


       
    }
}
