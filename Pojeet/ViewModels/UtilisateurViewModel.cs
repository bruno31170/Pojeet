﻿using System;
using System.Collections.Generic;
using Pojeet.Models;

namespace Pojeet.ViewModels
{
    public class UtilisateurViewModel
    {
        public Recherche Recherche { get; set; }
        public CompteConsumer CompteConsumer { get; set; }
        public bool Authentifie { get; set; }
        public List<Annonce> Annonce { get; set; }
        public Annonce Anonce { get; set; }
        public Profil Profil { get; set; }
        
    }
}
