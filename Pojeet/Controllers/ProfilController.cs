using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pojeet.Controllers
{
    [Authorize]
    public class ProfilController : Controller
    {
        private Dal dal;
        public ProfilController()
        {
            this.dal = new Dal();
        }

        public IActionResult Index()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.CompteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                //viewModel.Profil = dal.ObtenirProfil(viewModel.CompteConsumer.Id);
                return View(viewModel);
            }
            return View(viewModel);


        }
    }
}
