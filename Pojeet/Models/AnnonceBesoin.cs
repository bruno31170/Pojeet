using System;
namespace Pojeet.Models
{
    public class AnnonceBesoin
    {
        public string Id { get; set; }
        public String TitreAnnonce { set; get; }
        public String Description { set; get; }
        public DateTime DateParution { set; get; }
        public String Localisation { set; get; }
        public DateTime DateButoir { set; get; }
        public int Prix { set; get; }
        public String CategorieAnnonce { get; set; }
        public Type TypeAnnonce { get; set; }

        public enum Type
        {
            Besoin,
            Service
        }
    }
}
