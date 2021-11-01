using Pojeet.Models;
using System.Collections.Generic;

namespace Pojeet.ViewModels
{
    public class PaiementViewModel
    {
        public int id { get; set; }
        public Transaction Transaction { get; set; }
        public Message Message { get; set; }
        public Annonce Annonce { get; set; }
    }
}
