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

        bool VerificationMessagerieVide(int id1);

        void SuppressionConsumer(int id);
        int AjouterProvider(CompteConsumer compteConsumer, string iban, string bic, string titulaire, IFormFile photo, List<string> competence);
        Conversation ObtientLaConversation(int id);
        int ObtientPremiereConversation(List<Conversation> listeConversation);
        List<Message> ObtientTousLesMessages(int conversationId);
        Messagerie ObtientLaMessagerie(int id);
        CompteConsumer ObtenirConsumer(int id);
        CompteConsumer ObtenirConsumer(string idStr);
        List<Conversation> ObtientLesConversations(int id1);
        (int, List<Conversation>) ObtientLesConversations(int id1, String motCle, Messagerie messagerie);
        List<MessagerieConversation> ObtientMessagerieConversation(int id);
        public void CreerMessagerie(int id);


    }
}
