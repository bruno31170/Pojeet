using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalAfficherAnnonce: IDalAfficherAnnonce
    {
        private BddContext _context;
        public DalAfficherAnnonce()
        {
            _context = new BddContext();
        }

        public CompteConsumer ObtientConsumer(int id)
        {
            CompteConsumer consumer = this._context.CompteConsumer.Where(c => c.ProfilId==id).Include(c => c.Profil).FirstOrDefault();
            return consumer;
        }

        public Annonce ObtientAnnonce(int id)
        {
            Annonce annonce = this._context.Annonce.Where(r => r.Id == id).Include(c => c.profil).FirstOrDefault();
            return annonce;
        }

        public List<Avis> ObtientAvis(int id)
        {
            List<Avis> listeAvis = this._context.Avis.Where(c => c.ProfilId == id).Include(c => c.CompteConsumer.Profil).Include(c => c.Profil).ToList();
            return listeAvis;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
