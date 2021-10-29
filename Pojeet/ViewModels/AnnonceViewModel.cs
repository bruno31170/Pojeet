using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.ViewModels
{
    public class AnnonceViewModel
    {
        public CompteConsumer CompteConsumer { get; set; }
        public Annonce Annonce { get; set; }
        public List<Avis> Avis { get; set; }
        public Conversation Conversation { get; set; }
        //public ProviderViewModel ProviderViewModel{ get; set; }
        //public UtilisateurViewModel UtilisateurViewModel { get; set; }
    }
}
