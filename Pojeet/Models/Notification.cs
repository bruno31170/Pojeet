using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public Transaction transaction { get; set; }
        public int ProfilId { get; set; }
        public Profil profil { get; set; }


    }
}
