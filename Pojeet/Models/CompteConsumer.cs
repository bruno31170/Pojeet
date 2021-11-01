using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class CompteConsumer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le pseudo doit être rempli.")]
        [Display(Name = "Pseudo")]
        public string Pseudo { get; set; }

        [Required(ErrorMessage = "Le mot de passe doit être rempli.")]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }

        public int ProfilId { get; set; }
        //[Required]
        public virtual Profil Profil { get; set; }

        public DateTime DateCreationCompte { set; get; }
        //public int CompteProviderId { set; get; }
        //public virtual CompteProvider CompteProvider { get; set; }

        public enum Statut
        {
            Actif,
            Supprimé,
        }

    }
}
