using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pojeet.Controllers
{
    [Authorize]
    public class ProfilController : Controller
    {
        private Dal dal;
        public ProfilController()
        {
            this.dal = new Dal();
        }

        public IActionResult Index()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                //viewModel.Profil = dal.ObtenirProfil(viewModel.CompteConsumer.Id);
                return View(viewModel);
            }
            return View(viewModel);


        }

        public IActionResult ModifierConsumer()
        {
            //if (id != 0)
            //{
            //    using (IDal dal = new Dal())
            //    {
            //        CompteConsumer consumer = dal.ObtientTousConsumer().Where(r => r.Id == id).FirstOrDefault();
            //        if (consumer == null)
            //        {
            //            return View("Error");
            //        }
            //        return View(consumer);
            //    }
            //}
            //return View("Error");

            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                return View(compteConsumer);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ModifierConsumer(CompteConsumer consumer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("ModifierConsumer");
            //}


            if (consumer.Id != 0)
            {
                using (Dal ctx = new Dal())
                {
                    ctx.ModifierConsumer(consumer.Id, consumer.MotDePasse, consumer.Pseudo, consumer.Profil.Nom, consumer.Profil.Prenom, consumer.Profil.DateDeNaissance,
            consumer.Profil.Adresse, consumer.Profil.Ville, consumer.Profil.CodePostal, consumer.Profil.Pays, consumer.Profil.Mail, consumer.Profil.NumeroTelephone, consumer.Profil.Description, consumer.Profil.Photo);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Error");
            }
        }

    }
}
