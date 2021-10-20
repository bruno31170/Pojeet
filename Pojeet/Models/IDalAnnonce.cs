using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalAnnonce : IDisposable
    {
        
        void PosterAnnonce(string titreAnnonce, string description, DateTime dateParution, string localisation, DateTime dateButoir, int prix);

        void SupprimerAnnonce(int id);
    }
}
