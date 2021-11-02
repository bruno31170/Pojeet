using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Pojeet.Controllers
{
    public class AnnonceController : Controller
    {


        private IDalAnnonce dal;
        private IDalCatalogue dal1;
        private Dal dal2;
        private DalProfil dalProfil;
        private IWebHostEnvironment _env;
        private DalTransaction dal3;



        public AnnonceController(IWebHostEnvironment env)
        {
            this.dal = new DalAnnonce();
            this.dal1 = new DalCatalogue();
            this.dal2 = new Dal();
            this.dalProfil = new DalProfil();
            _env = env;
            this.dal3 = new DalTransaction();

        }


        public IActionResult PosterAnnonce()
        {
            return View();
        }



        [HttpPost]
        public ActionResult PosterAnnonce(UtilisateurViewModel uvm, IFormFile AnnoncePhoto)
        {


            
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal2.ObtenirConsumer(HttpContext.User.Identity.Name);


                viewModel.ListeAvis = dal2.ObtenirListeAvis(viewModel.CompteConsumer.Id);

                viewModel.ListeTransaction = dal3.ObtientTransaction(viewModel.CompteConsumer.Id);

                viewModel.NoteGlobale = dal2.ObtenirNoteGlobale(viewModel.CompteConsumer.Id);

                viewModel.CompteProvider = dal2.ObtenirHelper(viewModel.CompteConsumer.Id);


                dal.PosterAnnonce(viewModel.CompteConsumer.Id, uvm.Anonce.TypeDeAnnonce, uvm.Anonce.TitreAnnonce, uvm.Anonce.Description, uvm.Anonce.DateParution,
                   uvm.Anonce.Localisation, uvm.Anonce.DateButoir, uvm.Anonce.Prix, uvm.Anonce.CategorieDeAnnonce, AnnoncePhoto, uvm.Anonce.EtatAnnonce);

                viewModel.Annonce = dalProfil.ObtientAnnonceProfil(viewModel.CompteConsumer.Id);

                if (AnnoncePhoto != null)
                {
                    if (AnnoncePhoto.Length > 0)
                    {
                        string path3 = _env.WebRootPath + "/media/annonce/" + AnnoncePhoto.FileName;
                        FileStream stream3 = new FileStream(path3, FileMode.Create);
                        AnnoncePhoto.CopyTo(stream3);

                    }

                }
            }
            
            return View("Views/Profil/Index.cshtml", viewModel);
        }


        


        public ActionResult SupprimerAnnonce(int id)
        {
            dal.SupprimerAnnonce(id);
            return Redirect("~/Profil/Index"); //Retourner view mes annonces
        }

        

    }
}
