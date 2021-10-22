﻿using System;
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
            private DalProfil dal;
        public ProfilController()
        {
            this.dal = new Dal();
            this.dal = new DalProfil();
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



    //
        public IActionResult Indexx(int profilId)
        {
            /*string motdepasse, string pseudo, string nom, string prenom, string dateNaissance,
           string adresse, string ville, string code_postal, string pays, string mail, int numeroTelephone, string description*/

                /*
                Profil profil = new Profil
                {
                    Nom = nom,
                    Prenom = prenom,
                    DateDeNaissance = dateNaissance,
                    Adresse = adresse,
                    Ville = ville,
                    CodePostal = code_postal,
                    Pays = pays,
                    Mail = mail,
                    NumeroTelephone = numeroTelephone,
                    Description = description,
                };*/
            CompteConsumer consumer = new CompteConsumer 
            {
                /*Id= idConsumer, 
                Pseudo = pseudo, 
                Profil = profil */
            };

            List<Annonce> annonce = dal.ObtientAnnonceProfil(profilId);

            ProfilViewModel model = new ProfilViewModel { CompteConsumer = consumer, Annonce = annonce };


            return View("Indexx", model);

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
