using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class LaisserAvisController : Controller
    {
        private IDalLaisserAvis dal;
        private IDalInbox dal1;
        public LaisserAvisController()
        {
            this.dal = new DalLaisserAvis();
            this.dal1 = new DalInbox();
        }
        public IActionResult EnvoyerAvis(int id)
        {
            Profil profil=new Profil();
            String prenom = "";
            Avis avis = new Avis();
            Boolean authentifie = HttpContext.User.Identity.IsAuthenticated;
            if (authentifie)
            {
                CompteConsumer compteConsumer = dal1.ObtenirConsumer(HttpContext.User.Identity.Name);
                avis.CompteConsumerId= compteConsumer.Id;
                profil = dal.ObtientProfil(id);
                avis.ProfilId = profil.Id;
                prenom = profil.Prenom;
            }
            
            return View(new AvisViewModel {Prenom=prenom, Avis=avis});
        }



        [HttpPost]
        public IActionResult EnregistrerAvis(Avis Avis)
        {
            dal.EnregistrerAvis(Avis);
            dal.ActualiserNoteGlobale(Avis);
            dal.SuprimerNotification(Avis);
            return Redirect("/Profil/Index?tabId=contact2");
        }
    }
}
