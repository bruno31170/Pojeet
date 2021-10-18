using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class CompteProvider
    {
        public int Id { get; set; }
        public int CompteConsumerId { get; set; }
        public virtual CompteConsumer CompteConsumer { get; set; }

        public int DocumentIdentificationId { get; set; }
        public virtual DocumentIdentification DocumentIdentification { get; set; }

        public Etat Etat { get; set; }



    }
    public enum Etat
    {
        DemandeEnCours,
        Valide,
        Refuse
    }
}
