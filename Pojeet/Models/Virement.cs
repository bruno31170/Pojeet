using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Virement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double VirementMontant { get; set; }
        public int TransactionReference { get; set; }
        public virtual Transaction Transaction { get; set; }
        public int ProfilId { get; set; }
        public virtual Profil ProfilRecepteur { get; set; }
   
        public StatutVirement StatutVirement { get; set; }

    }
    public enum StatutVirement
    {
        Envoyé,
        NonEnvoyé,

    }
}

