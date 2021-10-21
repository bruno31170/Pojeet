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
            List<Transaction> listeTransaction = this._context.Transactions.ToList();
            return listeTransaction;
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
