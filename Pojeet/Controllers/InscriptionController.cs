using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class InscriptionController : Controller
    {
        private Dal dal;
        public InscriptionController()
        {
            this.dal = new Dal();
        }

        public IActionResult Index()
        {
            List<CompteConsumer> listConsumer = new List<CompteConsumer>();
            using (IDal dal = new Dal())
            {
                listConsumer = dal.ObtientTousConsumer();
            }

            return View(listConsumer);
        }

        public IActionResult ModifierConsumer(int id)
        {
            if (id != 0)
            {
                using (IDal dal = new Dal())
                {
                    CompteConsumer consumer = dal.ObtientTousConsumer().Where(r => r.Id == id).FirstOrDefault();
                    if (consumer == null)
                    {
                        return View("Error");
                    }
                    return View(consumer);
                }
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult ModifierConsumer(CompteConsumer consumer)
        {
            if (!ModelState.IsValid)
            {
                return View("ModifierConsumer");
            }


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
        //[HttpPost]
        //public IActionResult AjouterConsumer(CompteConsumer consumer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("AjouterConsumer");
        //    }

        //    using (Dal ctx = new Dal())
        //    {
        //        ctx.AjouterConsumer(consumer.MotDePasse, consumer.Pseudo, consumer.Profil.Nom, consumer.Profil.Prenom, consumer.Profil.DateDeNaissance,
        //    consumer.Profil.Adresse, consumer.Profil.Ville, consumer.Profil.CodePostal, consumer.Profil.Pays, consumer.Profil.Mail, consumer.Profil.NumeroTelephone, consumer.Profil.Description);
        //        return RedirectToAction("AjouterConsumer", new { @id = consumer.Id });
        //    }

        //}

        //public IActionResult AjouterConsumer()
        //{

        //    return View();

        //}
    }
}
