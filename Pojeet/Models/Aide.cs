using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Aide
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Mail { get; set; }
        public string Objet { get; set; }
        public string Message { get; set; }
        public int ProfilId { get; set; }
        public virtual Profil Profil { get; set; }

    }
}
