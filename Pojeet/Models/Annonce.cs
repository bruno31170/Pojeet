using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pojeet.Models
{
    
    public class Annonce
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Le type d'annonce doit être renseigné.")]
        public TypeAnnonce TypeDeAnnonce { set; get; }

        [Required(ErrorMessage = "Le titre de l'annonce doit être renseigné.")]
        [MaxLength(50)]
        public string TitreAnnonce { set; get; }

        [Required(ErrorMessage = "La descritpion doit être renseigné.")]
        [MaxLength(300)]
        public string Description { set; get; }
        
        public DateTime DateParution { set; get; }

        [Required(ErrorMessage = "Le département doit être renseigné.")]
        [MaxLength(5)]
        public string Localisation { set; get; }

        [Required(ErrorMessage = "La date butoir doit être renseigné.")]
        public DateTime DateButoir { set; get; }
        public int Prix { set; get; }

        [Required(ErrorMessage = "La catégorie de l'annonce doit être renseigné.")]
        public CategorieAnnonce CategorieDeAnnonce { get; set; }

        public string Photo { get; set; }

        public int ProfilId { get; set; }
        public virtual Profil profil { get; set; }

        public EtatAnnonce EtatAnnonce { get; set; }
    }

    public enum EtatAnnonce
    {
        Envoyé,
        Validé,
        Supprimé
    }
    public enum TypeAnnonce
    {
        Besoin,
        Service
    }

    public enum CategorieAnnonce
    {
        Réparation,
        Pièce,
        Location
    }


}
