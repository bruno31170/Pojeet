using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pojeet.Controllers
{
    public class PaiementController : Controller
    {
        private IDalInbox dalInbox;
        private IDal dal;
        public PaiementController()
        {
            this.dalInbox = new DalInbox();
            this.dal = new Dal();
        }
        [HttpPost]
        public IActionResult PaiementPage(PaiementViewModel pvm)

        {
            Annonce annonce= dal.ObtientAnnonce(pvm.Transaction.AnnonceId);
            pvm.Annonce = annonce;
            return View( pvm );


        }
    }
}
