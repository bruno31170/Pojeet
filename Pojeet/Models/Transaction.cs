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
        public int AnnonceId { get; set; }
        public virtual Annonce Annonce { get; set; }
        public double Montant { get; set; }
        public double MontantHelper { get; set; }
        public int ProfilId { get; set; }
        public virtual Profil Profil { get; set; }
        
        public EtatTransaction EtatTransaction { get; set; }

    }
    public enum EtatTransaction
    {
        En_attente,
        Paye,
        Effectue,
        Valide,
        Refuse,
        Termine

    }
}
