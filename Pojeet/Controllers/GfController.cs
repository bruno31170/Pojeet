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
            List<CompteConsumer> listeConsumer = new List<CompteConsumer>();
            listeConsumer = dal.ObtientConsumer();

            List<Transaction> listeTransaction = new List<Transaction>();
            listeTransaction = dal.ObtientTransaction();

            //Nombre Consumer du jour
            List<CompteConsumer> listeConsumerJour = new List<CompteConsumer>();
            foreach (var item in listeConsumer)
            {
                if (item.DateCreationCompte.Day == DateTime.Now.Day)
                {
                    listeConsumerJour.Add(item);
                }
            }

            //Liste transaction du jour
            List<Transaction> listeTransactionJour = new List<Transaction>();
            foreach (var item in listeTransaction)
            {
                if (item.Date.Day == DateTime.Now.Day)
                {
                    listeTransactionJour.Add(item);
                }
            }

            //Chiffre d'affaire et marge brut du jour
            Argent argent = new Argent();
            argent.ChiffreDaffaire = 0;

            foreach (var item in listeTransactionJour)
            {

                argent.ChiffreDaffaire = argent.ChiffreDaffaire + item.Montant;
            }
            argent.MargeBrut = argent.ChiffreDaffaire * 0.05;
            argent.MargeBrut = Convert.ToInt32(argent.MargeBrut);
            return View(new CommandeViewModel
            {
                listConsumer = listeConsumerJour,
                Listetransaction = listeTransactionJour,
                Argent = argent
            });

            
        }
            
    
    

        public IActionResult AdminCommandes()
        {
            List<CompteConsumer> listeConsumer = new List<CompteConsumer>();
            listeConsumer = dal.ObtientConsumer();

            List<Transaction> listeTransaction = new List<Transaction>();
            listeTransaction = dal.ObtientTransaction();

            //Nombre Consumer du mois
            List<CompteConsumer> listeConsumerMois = new List<CompteConsumer>();
            foreach (var item in listeConsumer)
            {
                if (item.DateCreationCompte.Month == DateTime.Now.Month)
                {
                    listeConsumerMois.Add(item);
                }
            }

            //Liste transaction dans le mois
            List<Transaction> listeTransactionMois = new List<Transaction>();
            foreach (var item in listeTransaction)
            {   
                if (item.Date.Month == DateTime.Now.Month)
                {
                    listeTransactionMois.Add(item);
                }
            }

            //Chiffre d'affaire et marge brut du mois
            Argent argent = new Argent();
            argent.ChiffreDaffaire = 0;
            
            foreach (var item in listeTransactionMois)
            {
                
                argent.ChiffreDaffaire = argent.ChiffreDaffaire + item.Montant;
            }
            argent.MargeBrut = argent.ChiffreDaffaire * 0.05;
            argent.MargeBrut = Convert.ToInt32(argent.MargeBrut);
            return View(new TransactionViewModel
            {
                listConsumer = listeConsumerMois,
                Transaction = listeTransactionMois,
                Argent = argent
            });


        }

        public ActionResult Consumer(int id)
        {
            CompteConsumer consumer = new CompteConsumer();
            consumer = dal.ObtientCompteConsumer(id);

            List<Transaction> transactions = new List<Transaction>();
            transactions = dal.ObtientTransaction(consumer.Id);
            
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
            transactions = dal.ObtientTransaction(consumer.Id);

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
            int NbTransaction = dal.ObtenirNbTransaction(transaction.ProfilId);
            return View(new CommandeViewModel { CompteConsumer = compteConsumer, Transaction = transaction, MargeBrute =MargeBrute, Reste= Reste, NbTransaction = NbTransaction });
        }
    }
 }
