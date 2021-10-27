using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.ViewModels
{
    public class ConsumerViewModel
    {
        public List<Transaction> ListeTransaction { get; set; }
        public CompteConsumer Consumer { get; set; }
        public Annonce annonce { get; set; }
    }
}
