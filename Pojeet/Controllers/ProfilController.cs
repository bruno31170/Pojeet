using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pojeet.Controllers
{
    public class ProfilController : Controller
    {
        private DalProfil dal;
        public ProfilController()
        {
            this.dal = new DalProfil();
        }

        // GET: /<controller>/
        public IActionResult Indexx(int profilId)
        {
            /*string motdepasse, string pseudo, string nom, string prenom, string dateNaissance,
           string adresse, string ville, string code_postal, string pays, string mail, int numeroTelephone, string description*/

                /*
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
                };*/
            CompteConsumer consumer = new CompteConsumer 
            {
                /*Id= idConsumer, 
                Pseudo = pseudo, 
                Profil = profil */
            };

            List<Annonce> annonce = dal.ObtientAnnonceProfil(profilId);

            ProfilViewModel model = new ProfilViewModel { CompteConsumer = consumer, Annonce = annonce };


            return View("Indexx", model);
        }
    }
}
