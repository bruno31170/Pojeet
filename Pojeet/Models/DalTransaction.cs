using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalTransaction : IDalTransaction
    {
        private BddContext _context;
        public DalTransaction()
        {
            _context = new BddContext();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Transaction> ObtientTransaction()
        {
            List<Transaction> listeTransaction = this._context.Transactions.Include(t => t.Profil).Include(t => t.Annonce).ToList();
            return listeTransaction;
        }

        public List<CompteConsumer> ObtientConsumer()
        {
            List<CompteConsumer> listeConsumer = this._context.CompteConsumer.Include(c => c.Profil).ToList();
            return listeConsumer;
        }

        public CompteConsumer ObtientCompteConsumer(int id)
        {
            CompteConsumer consumer = _context.CompteConsumer.Where(c => c.ProfilId == id).Include(c => c.Profil).FirstOrDefault();
            return consumer;
        }

        public List<Transaction> ObtientTransaction(int id)
        {
            List<Transaction> listeTransaction = this._context.Transactions.Where(c => c.ProfilId == id || c.Annonce.ProfilId == id).Include(c => c.Profil).Include(c => c.Annonce.profil).ToList();
            return listeTransaction;
        }
        public Transaction ObtientUneTransaction(int reference)
        {
            Transaction transaction = this._context.Transactions.Where(c => c.Reference == reference).Include(c => c.Profil).Include(c => c.Annonce.profil).FirstOrDefault();
            return transaction;
        }

        public double ObtenirMargeBrute(int reference)
        {
            Transaction transaction = ObtientUneTransaction(reference);
            double MargeBrute = Math.Round(transaction.Montant * 0.05, 2);

            return MargeBrute;
        }

        public double ObtenirReste(int reference)
        {
            Transaction transaction = ObtientUneTransaction(reference);
            double Reste = Math.Round(transaction.Montant - (transaction.Montant * 0.05), 2);

            return Reste;
        }

        public int ObtenirNbTransaction(int id)
        {
            Profil profil = ObtientCompteConsumer(id).Profil;
            List<Transaction> listeTransaction = ObtientTransaction(profil.Id);
            int NbTransaction = listeTransaction.Where(c => c.ProfilId == id || c.Annonce.ProfilId == id).Count();


            return NbTransaction;
        }

        public Paiement ObtenirPaiement(int reference)
        {
            Paiement paiement = this._context.Paiement.Where(c => c.TransactionReference == reference).FirstOrDefault();
            return paiement;
        }

        public Virement ObtenirVirement(int reference)
        {
            Virement virement = this._context.Virement.Where(c => c.TransactionReference == reference).Include(c => c.ProfilRecepteur).FirstOrDefault();
            
            return virement;
        }



        public CompteProvider ObtenirHelper(Virement virement)
        {
            Virement virement1 = new Virement();
            CompteProvider compteProvider = _context.CompteProvider.Where(c => c.CompteConsumerId == virement.ProfilId).Include(c => c.Rib).Include(c => c.CompteConsumer.Profil).FirstOrDefault();
            return compteProvider;
        }

        public void ModifierVirement(int reference)
        {
            Virement virement = _context.Virement.Where(c => c.TransactionReference == reference).FirstOrDefault();
            Transaction transaction = _context.Transactions.Where(c => c.Reference == reference).FirstOrDefault();
            transaction.EtatTransaction = EtatTransaction.Termine;
            virement.Date = DateTime.Now;
            
            virement.StatutVirement = StatutVirement.Envoyé;
           
            _context.SaveChanges();
        }

        //public CompteProvider AfficherVirement(int reference)
        //{
        //    Virement virement = _context.Virement.Where(c => c.TransactionReference == reference).FirstOrDefault();
        //    CompteProvider compteProvider = _context.CompteProvider.Where(c => c.CompteConsumerId == virement.ProfilId).Include(c => c.CompteConsumer).Include(c => c.CompteConsumer.Profil).FirstOrDefault();
        //    return compteProvider;
        //}

        public List<CompteConsumer> ObtientTousConsumer()
        {
            return _context.CompteConsumer.Include(c => c.Profil).ToList();
        }

        public List<CompteProvider> ObtientTousHelpers()
        {
            return _context.CompteProvider.Include(c => c.Rib).Include(c => c.CompteConsumer).Include(c => c.CompteConsumer.Profil).ToList();
        }

        public List<CompteProvider> ObtientTousHelpersAValider()
        {
            return _context.CompteProvider.Where(c => c.Etat == Etat.DemandeEnCours).ToList();
        }

        
    }
}
