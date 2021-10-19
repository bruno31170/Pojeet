using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Avis 
    {
        public int Id { get; set; }
        public DateTime date { get; set; };
        public string commentaire { get; set; };
        public int note { get; set; };

        public int CompteConsumerId { get; set; };
        public virtual CompteConsumer CompteConsumer { get; set; };
}
}
