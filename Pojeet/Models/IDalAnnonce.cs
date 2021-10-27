using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalAnnonce : IDisposable
    {
        
        void PosterAnnonce(int profilId, TypeAnnonce TypeDeAnnonce, string titreAnnonce, string description, 
            DateTime dateParution, string localisation, DateTime dateButoir, int prix, CategorieAnnonce  categorieAnnonce, IFormFile photo, EtatAnnonce etatAnnonce);

        void SupprimerAnnonce(int id);
    }
}
