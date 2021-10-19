using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Profil
    {
        public int Id { get; set; }


        //On peut metre [key] avant une propriété pour la définir comme clés principale
        public string Description { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "Le Nom doit être rempli.")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Le Prenom doit être rempli.")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "La Date de naissance doit être rempli.")]
        [Display(Name = "Date de naissance")]
        public string DateDeNaissance { get; set; }
        [Required(ErrorMessage = "L'Adresse doit être rempli.")]
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string Pays { get; set; }
        [Required(ErrorMessage = "Le Mail doit être rempli.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Le Numéros de téléphone doit être rempli.")]
        public int NumeroTelephone { get; set; }
        public byte[] Photo { get; set; }
    }

}
