using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class NotificationMessagerie
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public Conversation conversation { get; set; }
        public int ProfilId { get; set; }
        public virtual Profil Profil { get; set; }
        public int MessagesNonLus {get; set;}

    }
}
