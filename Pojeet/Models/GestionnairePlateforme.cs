using System;
namespace Pojeet.Models
{
    public class GestionnairePlateforme
    {
        public short GestionairePlateforme_Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String CategorieAnnonce { get; set; } // enumération 

        //TODO méthode pour valider ou refuser un compte consumer

        //TODO methode pour créer des services dans le catalogue de service location vente service
    }
}
