using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class AideController : Controller
    {
        private DalAide dal;

        public AideController()
        {
            this.dal = new DalAide();
            
        }

        public IActionResult Aide()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DemanderAide(AideViewModel avm)
        {


            dal.DemanderAide(avm.Aide.Id, avm.Aide.Nom, avm.Aide.Mail, avm.Aide.Objet, avm.Aide.Message, avm.Aide.ProfilId, avm.Aide.StatutAide, avm.Aide.Date);

            return View("Views/Aide/AideReussi.cshtml");
        }
    }
}
