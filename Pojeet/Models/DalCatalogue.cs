using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalCatalogue : IDalCatalogue
    {
        private BddContext _context;
        public DalCatalogue()
        {
            _context = new BddContext();
        }


        public List<Annonce> ObtientAnnonce()
        {
            List<Annonce> listeAnnonce = this._context.Annonce.ToList();
            return listeAnnonce;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
