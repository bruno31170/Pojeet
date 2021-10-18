using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Dal : IDal
    {
        private BddContext _context;
        public Dal()
        {
            _context = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public List<CompteConsumer> ObtientTousConsumer()
        {
            return _context.CompteConsumer.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int AjouterConsumer(string motdepasse, string pseudo, string nom, string prenom, string dateNaissance, 
            string adresse, string mail, int numeroTelephone, string description, string competence)
        {
            Profil profil = new Profil { Nom = nom, Prenom = prenom, DateDeNaissance = dateNaissance, Adresse = adresse, Mail = mail, 
                NumeroTelephone = numeroTelephone, Description = description, Competence = competence };
            CompteConsumer consumer = new CompteConsumer { MotDePasse = motdepasse, Pseudo = pseudo, Profil = profil };
            
            
            _context.CompteConsumer.Add(consumer);
            _context.SaveChanges();
            return consumer.Id;
        }
        public void ModifierConsumer(int id, string motdepasse, string pseudo)
        {
            CompteConsumer consumer = _context.CompteConsumer.Find(id);
            if (consumer != null)
            {
                consumer.MotDePasse = motdepasse;
                consumer.Pseudo = pseudo;
                _context.SaveChanges();
            }
        }

        public void SuppressionConsumer(int id)
        {
            CompteConsumer consumer = _context.CompteConsumer.Find(id);
            if (consumer != null)
            {
                _context.CompteConsumer.Remove(consumer);
                _context.SaveChanges();
            }
        }
    }
}
