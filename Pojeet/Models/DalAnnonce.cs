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


        public void PosterAnnonce(TypeAnnonce typeAnnonce, string titreAnnonce, string description, DateTime dateParution, string localisation, DateTime dateButoir, int prix, CategorieAnnonce categorieAnnonce, string photo)
        {
            Annonce annonce = new Annonce
            {
                TypeDeAnnonce = typeAnnonce,
                TitreAnnonce = titreAnnonce,
                Description = description,
                DateParution = DateTime.Now,
                Localisation = localisation,
                DateButoir = dateButoir,
                Prix = prix,
                CategorieDeAnnonce = categorieAnnonce,
                Photo = photo


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
