using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<CompteConsumer> ObtientTousConsumer();
        int AjouterConsumer(string motdepasse, string pseudo, string nom, string prenom, string dateNaissance,
            string adresse, string mail, int numeroTelephone, string description, string competence);
        void ModifierConsumer(int id, string motdepasse, string pseudo);
        void SuppressionConsumer(int id);
    }
}
