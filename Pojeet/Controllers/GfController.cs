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
        public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult AdminCommandes()
        {
            List<CompteConsumer> listeConsumer = new List<CompteConsumer>();

            listeConsumer = dal.ObtientConsumer();

            List<Transaction> listeTransaction = new List<Transaction>();
            listeTransaction = dal.ObtientTransaction();

            return View(new TransactionViewModel
            {
                listConsumer = listeConsumer,
                Transaction = listeTransaction
            });


        }

        public ActionResult Consumer(int id)
        {
            CompteConsumer consumer = new CompteConsumer();
            consumer = dal.ObtientCompteConsumer(id);

            List<Transaction> transactions = new List<Transaction>();
            transactions = dal.ObtientTransaction(consumer.ProfilId);
            
            return View(new ConsumerViewModel
            {
                Consumer = consumer,
                ListeTransaction = transactions
            });
        }

        public ActionResult Helper(int id)
        {
            CompteConsumer consumer = new CompteConsumer();
            consumer = dal.ObtientCompteConsumer(id);

            List<Transaction> transactions = new List<Transaction>();
            transactions = dal.ObtientTransaction(consumer.ProfilId);

            return View(new ConsumerViewModel
            {
                Consumer = consumer,
                ListeTransaction = transactions
            });
        }
        public ActionResult Commande(int reference)
        {
            Transaction transaction = new Transaction();
            transaction = dal.ObtientUneTransaction(reference);
            CompteConsumer compteConsumer = new CompteConsumer();
            compteConsumer = dal.ObtientCompteConsumer(transaction.ProfilId);
            double MargeBrute = dal.ObtenirMargeBrute(transaction.Reference);
            double Reste = dal.ObtenirReste(transaction.Reference);
            int NbTransaction = dal.ObtenirNbTransaction(transaction.Profil.Id);
            return View(new CommandeViewModel { CompteConsumer = compteConsumer, Transaction = transaction, MargeBrute =MargeBrute, Reste= Reste, NbTransaction = NbTransaction });
        }
    }
 }
