using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;


namespace Pojeet.Controllers
{
    public class LoginController : Controller
    {

        private Dal dal;

        public LoginController()
        {
            this.dal = new Dal();
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
        public IActionResult CreerCompte(CompteConsumer compteConsumer)
        {
            if (ModelState.IsValid)
            {
                int id = dal.AjouterConsumer(compteConsumer.MotDePasse, compteConsumer.Pseudo, compteConsumer.Profil.Nom, compteConsumer.Profil.Prenom, compteConsumer.Profil.DateDeNaissance,
            compteConsumer.Profil.Adresse, compteConsumer.Profil.Ville, compteConsumer.Profil.CodePostal, compteConsumer.Profil.Pays, compteConsumer.Profil.Mail, compteConsumer.Profil.NumeroTelephone, compteConsumer.Profil.Description, compteConsumer.Profil.Photo);

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



        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

