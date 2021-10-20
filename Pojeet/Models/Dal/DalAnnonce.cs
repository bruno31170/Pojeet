using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models.Dal
{
    public class DalAnnonce
    {
        private BddContext _context;
        public DalAnnonce()
        {
            _context = new BddContext();
        }
        public int PosterAnnonce(string titreAnnonce, string description, DateTime dateParution, string localisation, DateTime dateButoir)
        {
            AnnonceBesoin annonceBesoin = new AnnonceBesoin
            {
                TitreAnnonce = titreAnnonce,
                Description = description,
                DateParution = dateParution,
                Localisation = localisation,
                DateButoir = dateParution,
                
            };
            


            _context.CompteConsumer.Add(consumer);
            _context.SaveChanges();
            return consumer.Id;
        }
    }
}
