using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class GfController : Controller
    {
        public IDalTransaction dal;
        public GfController()
        {
            this.dal = new DalTransaction();
        }
        public IActionResult AdminCommandes()
        {
            List<CompteConsumer> listeConsumer = new List<CompteConsumer>();

           listeConsumer = dal.ObtientConsumer();

            List<Transaction> listeTransaction = new List<Transaction>();
            listeTransaction = dal.ObtientTransaction();
            return View(new TransactionViewModel { listConsumer = listeConsumer , Transaction = listeTransaction });


        }
    }
}
