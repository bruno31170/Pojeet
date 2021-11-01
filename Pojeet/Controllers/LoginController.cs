using System;
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
using System.Net;
using System.Net.Mail;
using HtmlAgilityPack;

namespace Pojeet.Controllers
{


    public class LoginController : Controller
    {

        private Dal dal;
        private IWebHostEnvironment _env;

        //CONSTRUCTEUR
        public LoginController(IWebHostEnvironment env)
        {
            this.dal = new Dal();
            _env = env;
        }

        // PAGE DE CONNEXION
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
                //ModelState.AddModelError("Utilisateur.Pseudo", "Pseudo et/ou mot de passe incorrect(s)");
                viewModel.ErrorMessage = "Pseudo et/ou mot de passe incorrect(s)";
                return View(viewModel);
            }
            return View(viewModel);
        }



        //CREATION DU COMPTE CONSUMER
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

                if (pictureFile != null)
                {
                    if (pictureFile.Length > 0)
                    {
                        string path3 = _env.WebRootPath + "/media/profil/" + pictureFile.FileName;
                        FileStream stream3 = new FileStream(path3, FileMode.Create);
                        pictureFile.CopyTo(stream3);
                    }
                }
                dal.CreerMessagerie(compteConsumer.ProfilId);



                var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, id.ToString()),
                    };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                //MAIL
                MailMessage message = new MailMessage();
                message.From = new MailAddress("helpmycar.isika@gmail.com", "HelpMyCar");
                message.To.Add(compteConsumer.Profil.Mail);
                message.Subject = "Inscription";
                message.IsBodyHtml = true;
                var doc = new HtmlDocument();
                FileStream cheminHtml = new FileStream(_env.WebRootPath + "/html/Bienvenue.html", FileMode.Open);
                doc.Load(cheminHtml);
                message.Body = doc.DocumentNode.OuterHtml;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("helpmycar.isika@gmail.com", "helpmycar2021")
                };
                {
                    smtp.Send(message);
                }


                return Redirect("SuccessInscritpion");
            }
            return View(compteConsumer);
        }



        //DECONNEXION
        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }



        //CREATIN DU COMPTE HELPER 
        [HttpPost]
        public IActionResult CreerHelper(CompteProvider compteProvider, IFormFile pictureFile, List<string> competences)
        {
            ProviderViewModel viewModel = new ProviderViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);

            using (Dal ctx = new Dal())
            {
                ctx.AjouterProvider(compteConsumer, compteProvider.Rib.Iban, compteProvider.Rib.Bic, compteProvider.Rib.TitulaireCompte, pictureFile, competences);

                if (pictureFile != null)
                {
                    if (pictureFile.Length > 0)
                    {
                        string path3 = _env.WebRootPath + "/media/provider/" + pictureFile.FileName;
                        FileStream stream3 = new FileStream(path3, FileMode.Create);
                        pictureFile.CopyTo(stream3);
                    }
                }

                MailMessage message = new MailMessage();
                message.From = new MailAddress("helpmycar.isika@gmail.com", "HelpMyCar");
                message.To.Add(compteConsumer.Profil.Mail);
                message.Subject = "Helper chez HelpMyCar";
                message.IsBodyHtml = true;
                var doc = new HtmlDocument();
                FileStream cheminHtml = new FileStream(_env.WebRootPath + "/html/WelcomeHelper.html", FileMode.Open);
                doc.Load(cheminHtml);
                message.Body = doc.DocumentNode.OuterHtml;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("helpmycar.isika@gmail.com", "helpmycar2021")
                };
                {
                    smtp.Send(message);
                }

                return Redirect("../Profil/Index");
            }
        }

        public IActionResult CreerHelper()
        {
            ProviderViewModel viewModel = new ProviderViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                if (viewModel.CompteConsumer == null)
                {
                    viewModel.CompteProvider = null;
                }
                else
                {
                    viewModel.CompteProvider = dal.ObtenirHelper(viewModel.CompteConsumer.Id);
                }
                return View(viewModel);
            }
            return View(viewModel);
        }

        public IActionResult SuccessInscritpion()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }
    }
}

