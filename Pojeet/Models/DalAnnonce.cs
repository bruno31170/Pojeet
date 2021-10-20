using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalAnnonce : IDalAnnonce
    {
        private BddContext _context;
        public DalAnnonce()
        {
            _context = new BddContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public void PosterAnnonce(string titreAnnonce, string description, DateTime dateParution, string localisation, DateTime dateButoir, int prix)
        {
            Annonce annonce = new Annonce
            {
                TitreAnnonce = titreAnnonce,
                Description = description,
                DateParution = dateParution,
                Localisation = localisation,
                DateButoir = dateButoir,
                Prix = prix

            };

            _context.Annonce.Add(annonce);
            _context.SaveChanges();
            
        }

        public void SupprimerAnnonce(int id)
        {
            Annonce annonce = _context.Annonce.Find(id);
            if (annonce != null)
            {
                _context.Annonce.Remove(annonce);
                _context.SaveChanges();
            }
        }
    }
}
