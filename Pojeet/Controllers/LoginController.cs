﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;


namespace Pojeet.Controllers
{


    public class LoginController : Controller
    {

        private Dal dal;

        private IWebHostEnvironment _env;

        public LoginController(IWebHostEnvironment env)
        {
            this.dal = new Dal();
            _env = env;
        }

        public IActionResult Index()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(UtilisateurViewModel viewModel, string returnUrl)
        {
            if (viewModel.CompteConsumer.MotDePasse != null && viewModel.CompteConsumer.Pseudo != null)
            {
                CompteConsumer CompteConsumer = dal.Authentifier(viewModel.CompteConsumer.Pseudo, viewModel.CompteConsumer.MotDePasse);
                if (CompteConsumer != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, CompteConsumer.Id.ToString()),
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("../Profil/Index");
                }
                ModelState.AddModelError("Utilisateur.Pseudo", "Pseudo et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }


        public IActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerCompte(CompteConsumer compteConsumer, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                int id = dal.AjouterConsumer(compteConsumer.MotDePasse, compteConsumer.Pseudo, compteConsumer.Profil.Nom, compteConsumer.Profil.Prenom, compteConsumer.Profil.DateDeNaissance,
            compteConsumer.Profil.Adresse, compteConsumer.Profil.Ville, compteConsumer.Profil.CodePostal, compteConsumer.Profil.Pays, compteConsumer.Profil.Mail, compteConsumer.Profil.NumeroTelephone, compteConsumer.Profil.Description, pictureFile);

                if (pictureFile.Length > 0)
                {
                    string path3 = _env.WebRootPath + "/media/" + pictureFile.FileName;
                    FileStream stream3 = new FileStream(path3, FileMode.Create);
                    pictureFile.CopyTo(stream3);
                }

                var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, id.ToString()),
                    };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("../Profil/Index");
            }
            return View(compteConsumer);
        }



        public IActionResult ModifierConsumer()
        {

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



        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }


        //public IActionResult CreerProvider()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreerProvider(CompteProvider compteProvider)
        //{
        //    UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
        //    CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
        //    if (viewModel.Authentifie)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            int id = dal.AjouterProvider(compteConsumer, compteProvider.Rib.Iban, compteProvider.Rib.Bic, compteProvider.Rib.TitulaireCompte, compteProvider.DocumentIdentification, compteProvider.Competence);

        //            return Redirect("../Profil/Index");
        //        }
        //        return View(compteProvider);
        //    }

        //    return View(compteProvider);
        //}




        [HttpPost]
        public IActionResult CreerHelper(CompteProvider compteProvider)
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);

            //if (!ModelState.IsValid)
            //{
            //    return View("CreerHelper");
            //}

            using (Dal ctx = new Dal())
            {
                ctx.AjouterProvider(compteConsumer, compteProvider.Rib.Iban, compteProvider.Rib.Bic, compteProvider.Rib.TitulaireCompte, compteProvider.DocumentIdentification, compteProvider.Competence);
                return RedirectToAction("../Profil/Index");
            }

        }

        public IActionResult CreerHelper()
        {

            return View();

        }

    }
}

