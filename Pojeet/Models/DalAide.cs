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

        
        public void DemanderAide(int id, string nom, string mail, string objet, string message, int profilId, StatutAide statutAide, DateTime Date)
        {
            Aide aide = new Aide
            {
                Id = id,
                Date = DateTime.Now,
                Nom = nom,
                Mail = mail,
                Objet = objet,
                Message = message,
                ProfilId = 1,
                StatutAide = StatutAide.NonEnvoye


            };

            _context.Aide.Add(aide);
            _context.SaveChanges();

        }

        public List<Aide> ObtientAides()
        {
            return _context.Aide.ToList();
        }

        public Aide ObtientAide(int id)
        {
            Aide aide = _context.Aide.Where(c => c.Id == id).FirstOrDefault();
            return aide;
        }
        public void ModifierAide(int id)
        {
            Aide aide = _context.Aide.Where(c => c.Id == id).FirstOrDefault();
            aide.StatutAide = StatutAide.Envoye;
            _context.SaveChanges();
        }

        public List<Aide> ObtientNewAides()
        {
            return _context.Aide.Where(c => c.StatutAide == StatutAide.NonEnvoye).ToList();
        }
    }
}
