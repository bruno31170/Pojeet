using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalAnnonce : IDisposable
    {
        
        void PosterAnnonce(TypeAnnonce TypeDeAnnonce, string titreAnnonce, string description, 
            DateTime dateParution, string localisation, DateTime dateButoir, int prix, CategorieAnnonce  categorieAnnonce, string photo);

        void SupprimerAnnonce(int id);
    }
}
