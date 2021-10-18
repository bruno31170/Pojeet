using System;
namespace Pojeet.Models
{
    public class AnnonceBesoin
    {
        public int Id { set; get; }
        public String TitreAnnonce { set; get; }
        public String Description { set; get; }
        public DateTime DateParution { set; get; }
        public String Localisation { set; get; }
        public DateTime DateButoir { set; get; }
    }
}
