using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Profil
    {
        public int Id { get; set; }
        public int CompteConsumerId { get; set; }
        public virtual CompteConsumer CompteConsumer { get; set; }


        public string Descrition { get; set; }
        public string Competence { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateDeNaissance { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public int NumeroTelephone { get; set; }
        public Image Photo { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        public string TitreImage { get; set; }
        public byte ImageData { get; set; }
    }

}
