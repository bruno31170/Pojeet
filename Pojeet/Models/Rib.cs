using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Rib
    {
        public int Id { get; set; }

        [Display(Name = "Titulaire du compte")]
        public string TitulaireCompte { get; set; }

        [Display(Name = "IBAN")]
        public string Iban { get; set; }

        [Display(Name = "BIC")]
        public string Bic { get; set; }
    }
}
