using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pojeet.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<CompteConsumer> ObtientTousConsumer();
        int AjouterConsumer(string motdepasse, string pseudo, string nom, string prenom, string dateNaissance,
            string adresse, string ville, string code_postal, Pays pays, string mail, int numeroTelephone, string description, IFormFile photo);
        void ModifierConsumer(int id, string pseudo, string nom, string prenom, string dateNaissance,
           string adresse, string ville, string code_postal, Pays pays, string mail, int numeroTelephone, string description, IFormFile photo);
        void SuppressionConsumer(int id);
        int AjouterProvider(CompteConsumer compteConsumer, string iban, string bic, string titulaire, IFormFile photo, List<string> competence);
        CompteConsumer ObtenirConsumer(int id);
        CompteConsumer ObtenirConsumer(string idStr);
        public void CreerMessagerie(int id);
        public void ModifierEtatProviderValide(int id);
        public List<Transaction> ObtientTransaction(int id);


    }
}
