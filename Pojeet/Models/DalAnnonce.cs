using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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


        public void PosterAnnonce(int profilId, TypeAnnonce typeAnnonce, string titreAnnonce, string description, DateTime dateParution,
            string localisation, DateTime dateButoir, int prix, CategorieAnnonce categorieAnnonce, IFormFile photo, EtatAnnonce etatAnnonce)
        {

            if (photo != null)
            {
                Annonce anonce = new Annonce
                {

                    TypeDeAnnonce = typeAnnonce,
                    TitreAnnonce = titreAnnonce,
                    Description = description,
                    DateParution = DateTime.Now,
                    Localisation = localisation,
                    DateButoir = dateButoir,
                    Prix = prix,
                    CategorieDeAnnonce = categorieAnnonce,
                    Photo = photo.FileName,
                    ProfilId = profilId,
                    EtatAnnonce = etatAnnonce

                };

                _context.Annonce.Add(anonce);
                _context.SaveChanges();
            }

            if (photo == null)
            {
                Annonce anonce = new Annonce
                {

                    TypeDeAnnonce = typeAnnonce,
                    TitreAnnonce = titreAnnonce,
                    Description = description,
                    DateParution = DateTime.Now,
                    Localisation = localisation,
                    DateButoir = dateButoir,
                    Prix = prix,
                    CategorieDeAnnonce = categorieAnnonce,

                    ProfilId = profilId,
                    EtatAnnonce = etatAnnonce

                };

                _context.Annonce.Add(anonce);
                _context.SaveChanges();
            }

        }

        public List<Annonce> ObtientAnnonce()
        {
            List<Annonce> listeAnnonce = this._context.Annonce.ToList();
            return listeAnnonce;
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
        public Annonce ObtientAnnonce(int id)
        {
            Annonce annonce = _context.Annonce.Where(c => c.Id == id).Include(c => c.profil).FirstOrDefault();
            return annonce;
        }

        public void ValiderAnnonce(int id)
        {
            Annonce annonce = this._context.Annonce.Where(c => c.Id == id).FirstOrDefault();
            annonce.EtatAnnonce = EtatAnnonce.Validé;
            _context.SaveChanges();
        }


    }
}
