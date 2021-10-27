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


        public List<Transaction> ObtientTransaction()
        {
            List<Transaction> listeTransaction = this._context.Transactions.Include(t=> t.Profil).Include(t=> t.Annonce).ToList();
            return listeTransaction;
        }

        public List<CompteConsumer> ObtientConsumer()
        {
            List<CompteConsumer> listeConsumer = this._context.CompteConsumer.Include(c => c.Profil).ToList();
            return listeConsumer;
        }

        public CompteConsumer ObtientCompteConsumer(int id)
        {
            CompteConsumer consumer = _context.CompteConsumer.Where(c => c.Id == id).Include(c => c.Profil).FirstOrDefault();
            return consumer;
        }

        public List<Transaction> ObtientTransaction(int id)
        {
            List<Transaction> listeTransaction = this._context.Transactions.Where(c => c.ProfilId == id || c.Annonce.ProfilId == id).Include(c => c.Profil).Include(c => c.Annonce.profil).ToList();
            return listeTransaction;
        }
        public Transaction ObtientUneTransaction (int reference)
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
            List<Transaction> listeTransaction = ObtientTransaction(id);
            int i = 0;
            int NbTransaction = 0;
            foreach (Transaction transaction in listeTransaction)
            {
                i++;
            }
            NbTransaction = i;
            return NbTransaction;
        }
        //public int ObtenirNbCommandeMois(DateTime date)
        //{
        //    List<Transaction> transactions = ObtientTransaction();
        //    DateTime dt = DateTime.Now;
        //    DateTime firstDayOfMonth = new DateTime(dt.Year, date.Month, 1);
        //    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
           
        //}

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
