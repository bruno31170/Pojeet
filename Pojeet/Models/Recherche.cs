using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Recherche
    {
        public string Rechercher { get; set; }
        public string Localisation { get; set; }
        public TypeRecherche TypeDeRecherche { get; set; }
    }

    public enum TypeRecherche
    {
        Besoin,
        Service
    }
}
