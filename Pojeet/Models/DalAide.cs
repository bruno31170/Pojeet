using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalAide
    {
        private BddContext _context;
        public DalAide()
        {
            _context = new BddContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        
        public void DemanderAide(int id, string nom, string mail, string objet, string message, int profilId)
        {
            Aide aide = new Aide
            {
                Id = id,
                Nom = nom,
                Mail = mail,
                Objet = objet,
                Message = message,
                ProfilId = 1


            };

            _context.Aide.Add(aide);
            _context.SaveChanges();

        }
    }
}
