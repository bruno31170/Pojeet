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
        public ActionResult PosterAnnonce(UtilisateurViewModel uvm)
        {
            
                if (!ModelState.IsValid)
                   return View("Error");
               idal.PosterAnnonce(uvm.Anonce.TypeDeAnnonce, uvm.Anonce.TitreAnnonce, uvm.Anonce.Description, uvm.Anonce.DateParution,
                   uvm.Anonce.Localisation, uvm.Anonce.DateButoir, uvm.Anonce.Prix, uvm.Anonce.CategorieDeAnnonce, uvm.Anonce.Photo);
            
            return View("Reussi"); //Retourner view mes annonces
        }


        
        public ActionResult SupprimerAnnonce(int id)
        {
            idal.SupprimerAnnonce(id);
            return Redirect("~/Profil/Index"); //Retourner view mes annonces
        }


       
    }
}
