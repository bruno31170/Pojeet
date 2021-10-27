using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class MessagerieConversation
    {
        public int Id { get; set; }
        public int MessagerieId { get; set; }
        public virtual Messagerie Messagerie { get; set; }

        public int ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
