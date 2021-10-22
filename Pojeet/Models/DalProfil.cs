using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalProfil
    {
        private BddContext _context;

        public DalProfil()
        {
            _context = new BddContext();
        }
        public CompteConsumer ObtientConsumer(int id)
        {
            CompteConsumer consumer = this._context.CompteConsumer.Where(c => c.Id == id).Include(c => c.Profil.ListeAvis).FirstOrDefault();
            return consumer;
        }
        public List<Annonce> ObtientAnnonceProfil(int profilId)
        {
            List<Annonce> listeAnnonce = ObtientAnnonce();
            List<Annonce> listeAnnonceProfil = new List<Annonce>();
            //Annonce annonce = (Annonce)this._context.Annonce.Where(n => n.ProfilId == profilId);
            foreach (var item in listeAnnonce)
            {
                if (item.ProfilId == profilId)
                    listeAnnonceProfil.Add(item);
            }

            return listeAnnonceProfil;
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
