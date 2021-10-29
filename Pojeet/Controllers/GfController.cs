using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class GfController : Controller
    {
        public IDalTransaction dal;
        public DalInbox dalinbox;
        public Dal dal1;
        private IWebHostEnvironment _env;
        public GfController(IWebHostEnvironment env)
        {
            this.dal = new DalTransaction();
            this.dalinbox = new DalInbox();
            this.dal1 = new Dal();

        }

        public IActionResult Index()
        {
            GPViewModel viewModel = new GPViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (viewModel.Authentifie)
            {
                viewModel.gestionnairePlatforme = dal1.ObtenirGP(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(GPViewModel viewModel, string returnUrl)
        {
            if (viewModel.gestionnairePlatforme.MotDePasse != null && viewModel.gestionnairePlatforme.Pseudo != null)
            {
                GestionnairePlateforme gestionnairePlatforme = dal1.AuthentifierGP(viewModel.gestionnairePlatforme.Pseudo, viewModel.gestionnairePlatforme.MotDePasse);
                if (gestionnairePlatforme != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, gestionnairePlatforme.Id.ToString()),
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("AdminIndex");
                }
                //ModelState.AddModelError("Utilisateur.Pseudo", "Pseudo et/ou mot de passe incorrect(s)");
                viewModel.ErrorMessage = "Pseudo et/ou mot de passe incorrect(s)";
                return View(viewModel);
            }
            return View(viewModel);
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
                listConsumer = listeConsumer,
                Transaction = listeTransaction,
                Argent = argent
            });


        }

        public ActionResult DemandeDevenirHelper()
        {
            List<CompteProvider> list = new List<CompteProvider>();
            list = dal.ObtientTousHelpers();
            List<CompteConsumer> listConsum = new List<CompteConsumer>();
            listConsum = dal.ObtientTousConsumer();

            return View(new DemandeHelperViewModel
            {
                listProvider = list,
                ListConsumer = listConsum,
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
            
            Transaction transaction = dal.ObtientUneTransaction(reference);
            CompteConsumer compteConsumer = dal.ObtientCompteConsumer(transaction.ProfilId);            
            double MargeBrute = dal.ObtenirMargeBrute(transaction.Reference);
            double Reste = dal.ObtenirReste(transaction.Reference);
            int NbTransaction = dal.ObtenirNbTransaction(transaction.ProfilId);
            Paiement paiement = dal.ObtenirPaiement(transaction.Reference);
            return View(new CommandeViewModel { CompteConsumer = compteConsumer, Transaction = transaction, MargeBrute =MargeBrute, Reste= Reste, NbTransaction = NbTransaction, Paiement =paiement });

           }

        //[HttpPost]
        //public IActionResult CreateVirement(int annonceId, int profilId, Virement newVirement)
        //{
        //    using (DalInbox ctx = new DalInbox())
        //    {
        //        ctx.CreerVirement(newVirement.VirementMontant, newVirement.TransactionReference, newVirement.ProfilId);
        //        return RedirectToAction("Commande");


        //    }
        //} 

        public ActionResult Comptabilite()
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


            //Liste transaction de l'année
            List<Transaction> listeTransactionAnnee = new List<Transaction>();
            foreach (var item in listeTransaction)
            {
                if (item.Date.Year == DateTime.Now.Year)
                {
                    listeTransactionAnnee.Add(item);
                }
            }

            //Chiffre d'affaire et marge brut de l'année
            Argent argentAnnee = new Argent();
            argentAnnee.ChiffreDaffaire = 0;

            foreach (var item in listeTransactionAnnee)
            {

                argentAnnee.ChiffreDaffaire = argentAnnee.ChiffreDaffaire + item.Montant;
            }
            argentAnnee.ChiffreDaffaire = Convert.ToInt32(argentAnnee.ChiffreDaffaire);
            argentAnnee.MargeBrut = argentAnnee.ChiffreDaffaire * 0.05;
            argentAnnee.MargeBrut = Convert.ToInt32(argentAnnee.MargeBrut);

            //Liste transaction, chiffre d'affaire et marge brut selon mois
            List<Transaction> listeTransactionJanvier = new List<Transaction>();
            List<Transaction> listeTransactionFevrier = new List<Transaction>();
            List<Transaction> listeTransactionMars = new List<Transaction>();
            List<Transaction> listeTransactionAvril = new List<Transaction>();
            List<Transaction> listeTransactionMai = new List<Transaction>();
            List<Transaction> listeTransactionJuin = new List<Transaction>();
            List<Transaction> listeTransactionJuillet = new List<Transaction>();
            List<Transaction> listeTransactionAout = new List<Transaction>();
            List<Transaction> listeTransactionSeptembre = new List<Transaction>();
            List<Transaction> listeTransactionOctobre = new List<Transaction>();
            List<Transaction> listeTransactionNovembre = new List<Transaction>();
            List<Transaction> listeTransactionDecembre = new List<Transaction>();

            Argent argentJanvier = new Argent();
            Argent argentFevrier = new Argent();
            Argent argentMars = new Argent();
            Argent argentAvril = new Argent();
            Argent argentMai = new Argent();
            Argent argentJuin = new Argent();
            Argent argentJuillet = new Argent();
            Argent argentAout = new Argent();
            Argent argentSeptembre = new Argent();
            Argent argentOctobre = new Argent();
            Argent argentNovembre = new Argent();
            Argent argentDecembre = new Argent();
            argentJanvier.ChiffreDaffaire = 0;
            argentFevrier.ChiffreDaffaire = 0;
            argentMars.ChiffreDaffaire = 0;
            argentAvril.ChiffreDaffaire = 0;
            argentMai.ChiffreDaffaire = 0;
            argentJuin.ChiffreDaffaire = 0;
            argentJuillet.ChiffreDaffaire = 0;
            argentAout.ChiffreDaffaire = 0;
            argentSeptembre.ChiffreDaffaire = 0;
            argentOctobre.ChiffreDaffaire = 0;
            argentNovembre.ChiffreDaffaire = 0;
            argentDecembre.ChiffreDaffaire = 0;

            foreach (var item in listeTransactionAnnee)
            {
                int dateMoi = Convert.ToInt32(item.Date.Month);

                if (dateMoi == 1)
                {
                    listeTransactionJanvier.Add(item);
                    argentJanvier.ChiffreDaffaire = argentJanvier.ChiffreDaffaire + item.Montant;
                    argentJanvier.MargeBrut = argentJanvier.ChiffreDaffaire * 0.05;
                    argentJanvier.MargeBrut = Convert.ToInt32(argentJanvier.MargeBrut);
                }
                if (dateMoi == 2)
                {
                    listeTransactionFevrier.Add(item);
                    argentFevrier.ChiffreDaffaire = argentFevrier.ChiffreDaffaire + item.Montant;
                    argentFevrier.MargeBrut = argentFevrier.ChiffreDaffaire * 0.05;
                    argentFevrier.MargeBrut = Convert.ToInt32(argentFevrier.MargeBrut);
                }
                if (dateMoi == 3)
                {
                    listeTransactionMars.Add(item);
                    argentMars.ChiffreDaffaire = argentMars.ChiffreDaffaire + item.Montant;
                    argentMars.MargeBrut = argentMars.ChiffreDaffaire * 0.05;
                    argentMars.MargeBrut = Convert.ToInt32(argentMars.MargeBrut);
                }
                if (dateMoi == 4)
                {
                    listeTransactionAvril.Add(item);
                    argentAvril.ChiffreDaffaire = argentAvril.ChiffreDaffaire + item.Montant;
                    argentAvril.MargeBrut = argentAvril.ChiffreDaffaire * 0.05;
                    argentAvril.MargeBrut = Convert.ToInt32(argentAvril.MargeBrut);
                }
                if (dateMoi == 5)
                {
                    listeTransactionMai.Add(item);
                    argentMai.ChiffreDaffaire = argentMai.ChiffreDaffaire + item.Montant;
                    argentMai.MargeBrut = argentMai.ChiffreDaffaire * 0.05;
                    argentMai.MargeBrut = Convert.ToInt32(argentMai.MargeBrut);
                }
                if (dateMoi == 6)
                {
                    listeTransactionJuin.Add(item);
                    argentJuin.ChiffreDaffaire = argentJuin.ChiffreDaffaire + item.Montant;
                    argentJuin.MargeBrut = argentJuin.ChiffreDaffaire * 0.05;
                    argentJuin.MargeBrut = Convert.ToInt32(argentJuin.MargeBrut);
                }
                if (dateMoi == 7)
                {
                    listeTransactionJuillet.Add(item);
                    argentJuillet.ChiffreDaffaire = argentJuillet.ChiffreDaffaire + item.Montant;
                    argentJuillet.MargeBrut = argentJuillet.ChiffreDaffaire * 0.05;
                    argentJuillet.MargeBrut = Convert.ToInt32(argentJuillet.MargeBrut);
                }
                if (dateMoi == 8)
                {
                    listeTransactionAout.Add(item);
                    argentAout.ChiffreDaffaire = argentAout.ChiffreDaffaire + item.Montant;
                    argentAout.MargeBrut = argentAout.ChiffreDaffaire * 0.05;
                    argentAout.MargeBrut = Convert.ToInt32(argentAout.MargeBrut);
                }
                if (dateMoi == 9)
                {
                    listeTransactionSeptembre.Add(item);
                    argentSeptembre.ChiffreDaffaire = argentSeptembre.ChiffreDaffaire + item.Montant;
                    argentSeptembre.MargeBrut = argentSeptembre.ChiffreDaffaire * 0.05;
                    argentSeptembre.MargeBrut = Convert.ToInt32(argentSeptembre.MargeBrut);
                }
                if (dateMoi == 10)
                {
                    listeTransactionOctobre.Add(item);
                    argentOctobre.ChiffreDaffaire = argentOctobre.ChiffreDaffaire + item.Montant;
                    argentOctobre.MargeBrut = argentOctobre.ChiffreDaffaire * 0.05;
                    argentOctobre.MargeBrut = Convert.ToInt32(argentOctobre.MargeBrut);
                }
                if (dateMoi == 11)
                {
                    listeTransactionNovembre.Add(item);
                    argentNovembre.ChiffreDaffaire = argentNovembre.ChiffreDaffaire + item.Montant;
                    argentNovembre.MargeBrut = argentNovembre.ChiffreDaffaire * 0.05;
                    argentNovembre.MargeBrut = Convert.ToInt32(argentNovembre.MargeBrut);
                }
                if (dateMoi == 12)
                {
                    listeTransactionDecembre.Add(item);
                    argentDecembre.ChiffreDaffaire = argentDecembre.ChiffreDaffaire + item.Montant;
                    argentDecembre.MargeBrut = argentDecembre.ChiffreDaffaire * 0.05;
                    argentDecembre.MargeBrut = Convert.ToInt32(argentDecembre.MargeBrut);
                }

            }

            return View(new TransactionViewModel { 
                listConsumer = listeConsumerMois, 
                Transaction = listeTransactionMois, 
                Argent = argent, 
                ArgentAnnee = argentAnnee, 
                TransactionTotale = listeTransactionAnnee, 
                TransactionJanvier = listeTransactionJanvier,
                TransactionFevrier = listeTransactionFevrier,
                TransactionMars = listeTransactionMars,
                TransactionAvril = listeTransactionAvril,
                TransactionMai = listeTransactionMai,
                TransactionJuin = listeTransactionJuin,
                TransactionJuillet = listeTransactionJuillet,
                TransactionAout = listeTransactionAout,
                TransactionSeptembre = listeTransactionSeptembre,
                TransactionOctobre = listeTransactionOctobre,
                TransactionNovembre = listeTransactionNovembre,
                TransactionDecembre = listeTransactionDecembre,
                ArgentJanvier = argentJanvier,
                ArgentFevrier = argentFevrier,
                ArgentMars = argentMars,
                ArgentAvril = argentAvril,
                ArgentMai = argentMai,
                ArgentJuin = argentJuin,
                ArgentJuillet = argentJuillet,
                ArgentAout = argentAout,
                ArgentSeptembre = argentSeptembre,
                ArgentOctobre = argentOctobre,
                ArgentNovembre = argentNovembre,
                ArgentDecembre = argentDecembre,
            });
        }
    }
}
