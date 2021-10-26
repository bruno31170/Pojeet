using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Pojeet.Controllers
{
    public class AnnonceController : Controller
    {

        private IDalAnnonce dal;
        private IDalCatalogue dal1;

        public AnnonceController()
        {
            this.dal = new DalAnnonce();
            this.dal1 = new DalCatalogue();
        }
        
        
        public IActionResult PosterAnnonce()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult PosterAnnonce(UtilisateurViewModel uvm)
        {
            List<Annonce> annonce = dal1.ObtientAnnonce();
            Annonce derniereAnnonce = annonce.Last();
            int id = derniereAnnonce.Id + 1;

            /*if (!ModelState.IsValid)   Je ne comprends pas pourquoi le modelState est InValide alors que toutes mes conditions dans annonces sont remplis (Bruno)
               return View("Error");*/
            dal.PosterAnnonce(uvm.Anonce.TypeDeAnnonce, uvm.Anonce.TitreAnnonce, uvm.Anonce.Description, uvm.Anonce.DateParution,
                   uvm.Anonce.Localisation, uvm.Anonce.DateButoir, uvm.Anonce.Prix, uvm.Anonce.CategorieDeAnnonce, uvm.Anonce.Photo, uvm.Anonce.EtatAnnonce);

            List<Annonce> annonces = dal1.ObtientAnnonce();

            return View("Views/Profil/Index.cshtml");
            //return View("Views/Catalogue/AnnonceCatalogue.cshtml");

        }



        public ActionResult SupprimerAnnonce(int id)
        {
            dal.SupprimerAnnonce(id);
            return Redirect("~/Profil/Index"); //Retourner view mes annonces
        }


    }
}
