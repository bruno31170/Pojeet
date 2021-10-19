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
        public DateTime Date { get; set; }
        public string Commentaire { get; set; }
        public int Note { get; set; }

        public virtual CompteProvider CompteProvider { get; set; }
        public virtual CompteConsumer Auteur { get; set; }
        public virtual CompteConsumer CompteConsumer { get; set; }
        
        
        
    }
}
