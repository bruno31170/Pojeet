using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pojeet.Models
{
    public class Profil
    {
        //On peut metre [key] avant une propriété pour la définir comme clés principale
        public int Id { get; set; }

        public string Description { get; set; }

        //[MaxLength(20)]
        //[Required(ErrorMessage = "Le Nom doit être rempli.")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        //[Required(ErrorMessage = "Le Prenom doit être rempli.")]
        [Display(Name = "Prenom")]
        public string Prenom { get; set; }

        //[Required(ErrorMessage = "La Date de naissance doit être rempli.")]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public string DateDeNaissance { get; set; }

        //[Required(ErrorMessage = "L'Adresse doit être rempli.")]
        [Display(Name = "Nom de la rue")]
        public string Adresse { get; set; }

        [Display(Name = "Ville")]
        public string Ville { get; set; }

        [Display(Name = "Code postal")]
        public string CodePostal { get; set; }

        //[Display(Name = "Pays")]
        //public string Pays { get; set; }

        //[Required(ErrorMessage = "Le Mail doit être rempli.")]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        //[Required(ErrorMessage = "Le Numéros de téléphone doit être rempli.")]
        [Display(Name = "Numéro de téléphone")]
        public int NumeroTelephone { get; set; }



        public Pays Pays { get; set; }

        public string Photo { get; set; }

    }

    public enum Pays
    {
        France,
        Suisse,
        Belgique


    }

}
