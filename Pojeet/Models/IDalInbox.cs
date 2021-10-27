using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pojeet.Models
{
    public interface IDalInbox : IDisposable
    {
        void DeleteCreateDatabase();
        List<CompteConsumer> ObtientTousConsumer();
        bool VerificationMessagerieVide(int id1);
        Conversation ObtientLaConversation(int id);
        int ObtientPremiereConversation(List<Conversation> listeConversation);
        List<Message> ObtientTousLesMessages(int conversationId);
        Messagerie ObtientLaMessagerie(int id);
        CompteConsumer ObtenirConsumer(int id);
        CompteConsumer ObtenirConsumer(string idStr);
        List<Conversation> ObtientLesConversations(int id1);
        (int, List<Conversation>) ObtientLesConversations(int id1, String motCle, Messagerie messagerie);
        List<MessagerieConversation> ObtientMessagerieConversation(int id);



    }
}
