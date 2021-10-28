using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class CompteProvider
    {
        public int Id { get; set; }
        public int CompteConsumerId { get; set; }
        public virtual CompteConsumer CompteConsumer { get; set; }
        public string DocumentIdentification { get; set; }
        public int RibId { get; set; }
        public virtual Rib Rib { get; set; }
        public Etat Etat { get; set; }
        public DateTime DateCreationCompte { set; get; }
        public string Competence { get; set; }
    }
    public enum Etat
    {
        DemandeEnCours,
        Valide,
        Refuse
    }
}
