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


                //var fromAddress = new MailAddress("helpmycar.isika@gmail.com", "HelpMyCar");
                //var toAddress = new MailAddress(compteConsumer.Profil.Mail, compteConsumer.Profil.Nom + " " + compteConsumer.Profil.Prenom);
                //const string fromPassword = "helpmycar2021";
                //const string subject = "Inscription HelpMyCar";
                //string body = @"<html>
                //                    <body>
                //                        <p>Dear Ms. Susan,</p>
                //                        <p>Thank you for your letter of yesterday inviting me to come for an interview on Friday afternoon, 5th July, at 2:30.
                //                        I shall be happy to be there as requested and will bring my diploma and other papers with me.</p>
                //                        <p>Sincerely,<br>-Jack</br></p>
                //                    </body>
                //                </html>";

                //var smtp = new SmtpClient
                //{
                //    Host = "smtp.gmail.com",
                //    Port = 587,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                //};
                //using (var message = new MailMessage(fromAddress, toAddress)
                //{
                //    Subject = subject,
                //    Body = body
                //})
                //{
                //    smtp.Send(message);
                //}

                MailMessage message = new MailMessage();
                message.From = new MailAddress("helpmycar.isika@gmail.com", "HelpMyCar");
                message.To.Add(compteConsumer.Profil.Mail);
                message.Subject = "Inscription";
                message.IsBodyHtml = true;
                message.Body = "<p>Bienvenu!!</p></br>";

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
        public IActionResult CreerHelper(CompteProvider compteProvider, IFormFile pictureFile)
        {
            ProviderViewModel viewModel = new ProviderViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);

            using (Dal ctx = new Dal())
            {
                ctx.AjouterProvider(compteConsumer, compteProvider.Rib.Iban, compteProvider.Rib.Bic, compteProvider.Rib.TitulaireCompte, pictureFile, compteProvider.Competence);

                if (pictureFile.Length > 0)
                {
                    string path3 = _env.WebRootPath + "/media/provider/" + pictureFile.FileName;
                    FileStream stream3 = new FileStream(path3, FileMode.Create);
                    pictureFile.CopyTo(stream3);
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
    }
}

