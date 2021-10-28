using Pojeet.Models;
using System.Collections.Generic;

namespace Pojeet.Models
{
    public class InboxViewModel
    {
        public bool Authentifie { get; set; }
        public Conversation Conversation { get; set; }
        public List<Message> List2 { get; set; }
        public List<Conversation> List1 { get; set; }
        public int id1 { get; set; }
        public int id2 { get; set; }

        public Message NouveauMessage { get; set; }
        public Messagerie Messagerie { get; set; }

        public Transaction NouvelleTransaction { get; set; }

        public List<MessagerieConversation> MessagerieConversation { get; set; }

        public string MotCle { get; set; }
        public CompteConsumer CompteConsumer { get; set; }
    }
}
