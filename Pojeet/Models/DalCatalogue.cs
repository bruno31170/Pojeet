using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Pojeet.ViewModels;
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
        public void Dispose()
        {
            _context.Dispose();
        }
        public List<Annonce> ObtientAnnonce()
        {
            List<Annonce> listeAnnonce = this._context.Annonce.Include(m => m.profil).ToList();
            return listeAnnonce;
        }
        public CompteConsumer ObtientConsumer(int id)
        {
            CompteConsumer consumer = this._context.CompteConsumer.FirstOrDefault(c => c.Id == id);
            return consumer;
        }


        public List<Annonce> RechercherAnnonce(UtilisateurViewModel uvm)
        {
            List<Annonce> rechercheAnnonce = new List<Annonce>();
            List<Annonce> annonce = ObtientAnnonce();
            foreach (var item in annonce)
            {
                if (item.TitreAnnonce == uvm.Anonce.TitreAnnonce)
                    rechercheAnnonce.Add(item);
            }
            return rechercheAnnonce;
        }

        public Annonce ObtientUneAnnonce(int id)
        {
            Annonce annonce = this._context.Annonce.FirstOrDefault(c => c.Id == id);
            return annonce;

        }

    }
}
