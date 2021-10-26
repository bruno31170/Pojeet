using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
            ViewBag.tabId = "#"+tabId;
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                viewModel.ListeAvis = dal.ObtenirListeAvis(viewModel.CompteConsumer.Id);
                viewModel.Annonce = dalProfil.ObtientAnnonceProfil(viewModel.CompteConsumer.Id);

                viewModel.NoteGlobale = dal.ObtenirNoteGlobale(viewModel.CompteConsumer.Id);

                viewModel.CompteProvider = dal.ObtenirHelper(viewModel.CompteConsumer.Id);

                return View(viewModel);
            }
            return View(viewModel);

        }

      



        /*public IActionResult MesAnnoncesProfil(int profilId)
         {
             string motdepasse, string pseudo, string nom, string prenom, string dateNaissance,
            string adresse, string ville, string code_postal, string pays, string mail, int numeroTelephone, string description


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
             };
             CompteConsumer consumer = new CompteConsumer
             {
                 Id= idConsumer, 
                 Pseudo = pseudo, 
                 Profil = profil 
             };

             List<Annonce> annonce = dalProfil.ObtientAnnonceProfil(profilId);

             UtilisateurViewModel model = new UtilisateurViewModel { CompteConsumer = consumer, Annonce = annonce };


             return View("Index", model);

         }*/

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

        
    }
}
