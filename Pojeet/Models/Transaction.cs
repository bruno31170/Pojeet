using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Transaction
    {
        [Key]
        public int Reference { get; set; }
        public DateTime Date { get; set; }
        public int AnnonceBesoinId { get; set; }
        public virtual Annonce AnnonceBesoin { get; set; }
        public double Montant { get; set; }
        public EtatTransaction EtatTransaction { get; set; }

    }
    public enum EtatTransaction
    {
        En_attente,
        Valide,
        Refuse,
        Termine
    }
}
