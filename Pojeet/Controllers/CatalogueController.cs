 using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    [Authorize]

    public class CatalogueController : Controller
    {
        private IDalCatalogue dal;
        private IDalAfficherAnnonce dal1;
        private Dal dal2;
        public CatalogueController()
        {
            this.dal = new DalCatalogue();
            this.dal1 = new DalAfficherAnnonce();
            this.dal2 = new Dal();
        }

        public IActionResult AnnonceCatalogue(int id)
        {
            CompteConsumer consumer = dal.ObtientConsumer(id);

            List<Annonce> listeAnnonce = dal.ObtientAnnonce();

            
            return View(new ProfilViewModel { Annonce = listeAnnonce, CompteConsumer = consumer});
        }


     
        public IActionResult RechercherAnnonce(ProfilViewModel uvm)
        {
            /*CompteConsumer consumer = dal.ObtientConsumer(uvm.CompteConsumer.Id);*/

            List<Annonce> listeAnnonce = dal.RechercherAnnonce(uvm);
            return View(new ProfilViewModel { Annonce = listeAnnonce});


          /*      List<Annonce> listeAnnonce = dal.ObtientAnnonce();
                return View(new ProfilViewModel {Annonce=listeAnnonce,CompteConsumer= consumer});*/
            
           

        }
        
        public ActionResult Annonce(int Id1, int Id2)
        {
            CompteConsumer consumer = dal1.ObtientConsumer(Id1);
            Annonce annonce1 = dal1.ObtientAnnonce(Id2);
            List<Avis> listeAvis = dal1.ObtientAvis(annonce1.ProfilId);
            Conversation conversation = dal.Contact(Id1, Id2);
            // List<Avis> listeAvis = dal2.ObtenirListeAvis(Id);
            return View(new AnnonceViewModel { Annonce = annonce1, CompteConsumer = consumer, Avis = listeAvis, Conversation= conversation});

        }

    }
}
