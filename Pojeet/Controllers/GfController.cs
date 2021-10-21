using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class GfController : Controller
    {
        private IDalTransaction dal;
        public GfController()
        {
            this.dal = new DalTransaction();
        }
        public IActionResult AdminCommandes()
        {

            List<Transaction> listeTransaction = dal.ObtientTransaction();
            return View(listeTransaction);


        }
    }
}
