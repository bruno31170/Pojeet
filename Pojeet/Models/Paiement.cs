using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TransactionMontant { get; set; }
        public int TransactionReference { get; set; }
        public virtual Transaction Transaction { get; set; }
        public int ProfilId {get; set; }
        public virtual Profil ProfilPayant { get; set; }
        public StatutPaiement StatutPaiement { get; set; }

    }
    public enum StatutPaiement
    {
        Payé,
        NonPayé,
    }
}
