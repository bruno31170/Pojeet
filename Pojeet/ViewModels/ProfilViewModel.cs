using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.ViewModels
{
    public class ProfilViewModel
    {
        public CompteConsumer CompteConsumer { get; set; }
        public List<Annonce> Annonce { get; set; }
        public CompteProvider CompteProvider { get; set; }
        public Annonce Anonce { get; set; }
        public Recherche Recherche { get; set; }
        public NombreAnnonce NombreAnnonce { get; set; }
        public CategorieRecherche CategorieDeRecherche { get; set; }
        public CategorieAnnonce CategorieDeAnnonce { get; set; }

    }
    public enum CategorieRecherche
    {
        Réparation,
        Pièce,
        Location
    }
    public enum TypeAnnonce
    {
        Besoin,
        Service
    }
}
