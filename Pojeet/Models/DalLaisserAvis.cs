using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalLaisserAvis : IDalLaisserAvis
    {
        private BddContext _context;
        public DalLaisserAvis()
        {
            _context = new BddContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public Profil ObtientProfil(int id)
        {
            Profil profil = _context.Profil.Where(r => r.Id == id).Include(c => c.ListeAvis).FirstOrDefault();
            return profil;
        }
        public void EnregistrerAvis(Avis avis)
        {
            Avis avislocal = new Avis
            {
                date = DateTime.Now,
                commentaire = avis.commentaire,
                note = avis.note,
                CompteConsumerId = avis.CompteConsumerId,
                ProfilId = avis.ProfilId,

            };
            _context.Avis.Add(avislocal);
            _context.SaveChanges();
        }


        public void ActualiserNoteGlobale(Avis avis)
        {
            Profil profil = _context.Profil.Where(r => r.Id == avis.ProfilId).Include(c => c.ListeAvis).FirstOrDefault();
            List<Avis> listeAvis = profil.ListeAvis;
            int noteGlobale = profil.NoteMoyenne;
            noteGlobale = noteGlobale+avis.note / (1+listeAvis.Count());
            profil.NoteMoyenne = noteGlobale;
            
            _context.SaveChanges();

        }
    }
}
