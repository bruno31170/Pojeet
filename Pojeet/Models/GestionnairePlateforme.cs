using System;
using System.ComponentModel.DataAnnotations;

namespace Pojeet.Models
{
    public class GestionnairePlateforme
    {
        public short Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }

        [Required(ErrorMessage = "Le pseudo doit être rempli.")]
        [Display(Name = "Pseudo")]
        public string Pseudo { get; set; }

        [Required(ErrorMessage = "Le mot de passe doit être rempli.")]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }

        //TODO méthode pour valider ou refuser un compte consumer

        //TODO methode pour créer des services dans le catalogue de service location vente service
    }
}
