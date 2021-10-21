using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Conversation 
    {
        public int Id { get; set; }
        public int AnnonceId { get; set; }
        public virtual Annonce Annonce { get; set; }

        public int CompteConsumerId { get; set; }
        public virtual CompteConsumer Auteur_Message{ get; set; }
        public int MessagerieId { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}
