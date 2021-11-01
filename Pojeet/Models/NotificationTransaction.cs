using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class NotificationTransaction
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public Transaction transaction { get; set; }
        public int ProfilId { get; set; }
        public Profil profil { get; set; }
        public TypeNotification TypeNotification { get; set; }

    }
    public enum TypeNotification
    {
        Proposition_de_prix,
        Transaction_a_valider,
        Laisser_un_avis,
    }

}

