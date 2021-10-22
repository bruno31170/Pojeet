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
            string adresse, string ville, string code_postal, string pays, string mail, int numeroTelephone, string description);


        void ModifierConsumer(int id, string motdepasse, string pseudo, string nom, string prenom, string dateNaissance,
            string adresse, string mail, int numeroTelephone, string description);

        void SuppressionConsumer(int id);


        List<Conversation> ObtientToutesLesConversations(int id);
        List<Message> ObtientTousLesMessages(int conversationId);
        Messagerie ObtientLaMessagerie(int id);
        CompteConsumer ObtenirConsumer(int id);
        CompteConsumer ObtenirConsumer(string idStr);

    }
}
