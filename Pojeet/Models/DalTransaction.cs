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
            CompteConsumer consumer = this._context.CompteConsumer.Where(c => c.Id == id).Include(c => c.Profil).FirstOrDefault();
            return consumer;
        }

        public List<Transaction> ObtientTransaction(int id)
        {
            List<Transaction> listeTransaction = this._context.Transactions.Where(c => c.ProfilId == id).Include(c => c.Profil).Include(c => c.Annonce).ToList();
            return listeTransaction;
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
