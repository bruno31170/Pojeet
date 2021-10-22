using System;
using System.Collections.Generic;
using Pojeet.Models;

namespace Pojeet.ViewModels
{
    public class UtilisateurViewModel
    {
        public CompteConsumer CompteConsumer { get; set; }
        public bool Authentifie { get; set; }
        public List<Annonce> Annonce { get; set; }
        public List<Avis> ListeAvis { get; set; }
        public int NoteGlobale { get; set; }
    }
}
