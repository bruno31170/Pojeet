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

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
