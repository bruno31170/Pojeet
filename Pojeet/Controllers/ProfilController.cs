using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;


namespace Pojeet.Controllers
{
    [Authorize]
    public class ProfilController : Controller
    {

        private Dal dal;
        private DalProfil dalProfil;
        private IWebHostEnvironment _env;

        public ProfilController(IWebHostEnvironment env)
        {
            this.dal = new Dal();
            this.dalProfil = new DalProfil();
            _env = env;
        }

        public IActionResult Index(string tabId)
        {
            ViewBag.tabId = "#" + tabId;


            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);

                List<Transaction> transactions = new List<Transaction>();
                transactions = dal.ObtientTransaction(viewModel.CompteConsumer.Id);


                viewModel.ListeTransaction = transactions;
                viewModel.ListeAvis = dal.ObtenirListeAvis(viewModel.CompteConsumer.Id);
                viewModel.Annonce = dalProfil.ObtientAnnonceProfil(viewModel.CompteConsumer.Id);

                viewModel.NoteGlobale = dal.ObtenirNoteGlobale(viewModel.CompteConsumer.Id);

                viewModel.CompteProvider = dal.ObtenirHelper(viewModel.CompteConsumer.Id);

                return View(viewModel);
            }
            return View(viewModel);

        }

        public IActionResult ProfilVisiteur(int id)
        {

            UtilisateurViewModel viewModel = new UtilisateurViewModel();

            viewModel.CompteConsumer = dal.ObtenirConsumer(id);
            viewModel.ListeAvis = dal.ObtenirListeAvis(viewModel.CompteConsumer.Id);
            viewModel.Annonce = dalProfil.ObtientAnnonceProfil(viewModel.CompteConsumer.Id);

            viewModel.NoteGlobale = dal.ObtenirNoteGlobale(viewModel.CompteConsumer.Id);

            viewModel.CompteProvider = dal.ObtenirHelper(viewModel.CompteConsumer.Id);

            return View(viewModel);

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
        public IActionResult ModifierConsumer(CompteConsumer consumer, IFormFile pictureFile)
        {

            if (consumer.Id != 0)
            {
                using (Dal ctx = new Dal())
                {
                    ctx.ModifierConsumer(consumer.Id, consumer.Pseudo, consumer.Profil.Nom, consumer.Profil.Prenom, consumer.Profil.DateDeNaissance,
            consumer.Profil.Adresse, consumer.Profil.Ville, consumer.Profil.CodePostal, consumer.Profil.Pays, consumer.Profil.Mail, consumer.Profil.NumeroTelephone, consumer.Profil.Description, pictureFile);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        string path3 = _env.WebRootPath + "/media/profil/" + pictureFile.FileName;
                        FileStream stream3 = new FileStream(path3, FileMode.Create);
                        pictureFile.CopyTo(stream3);
                    }

                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Error");
            }
        }


        public IActionResult ModifierEtatProviderValide(int id)
        {

            if (id != 0)
            {
                using (Dal ctx = new Dal())
                {

                    ctx.ModifierEtatProviderValide(id);
                    CompteProvider prov = ctx.ObtenirHelper(id);


                    //MAIL
                    //MailMessage message = new MailMessage();
                    //message.From = new MailAddress("helpmycar.isika@gmail.com", "HelpMyCar");
                    //message.To.Add(prov.CompteConsumer.Profil.Mail);
                    //message.Subject = "Inscription";
                    //message.IsBodyHtml = true;
                    //var doc = new HtmlDocument();
                    //FileStream cheminHtml = new FileStream(_env.WebRootPath + "/html/HelperValide.html", FileMode.Open);
                    //doc.Load(cheminHtml);
                    //message.Body = doc.DocumentNode.OuterHtml;

                    //var smtp = new SmtpClient
                    //{
                    //    Host = "smtp.gmail.com",
                    //    Port = 587,
                    //    EnableSsl = true,
                    //    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //    UseDefaultCredentials = false,
                    //    Credentials = new NetworkCredential("helpmycar.isika@gmail.com", "helpmycar2021")
                    //};
                    //{
                    //    smtp.Send(message);
                    //}




                    return RedirectToAction("DemandeDevenirHelper", "Gf");


                }






            }
            else
            {
                return View("Error");
            }
        }


        public IActionResult SupprimerConsumer()
        {

            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);

                if (compteConsumer.Id != 0)
                {
                    using (Dal ctx = new Dal())
                    {
                        ctx.SuppressionConsumer(compteConsumer.Id);
                        HttpContext.SignOutAsync();
                        return Redirect("/");
                    }
                }
                else
                {
                    return View("Error");
                }

            }
            return View("");
        }

        public IActionResult ActualiserEtatTransaction(int reference, EtatTransaction etat)
        {
            using (Dal ctx = new Dal())
            {
                ctx.ActualiserEtatTransaction(reference, etat);
            }

            return RedirectToAction("Index");
        }
    }
}
