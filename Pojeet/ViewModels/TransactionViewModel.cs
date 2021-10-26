using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.ViewModels
{
    public class TransactionViewModel
    {

        public List<Transaction> Transaction { get; set; }

        public List<CompteConsumer> listConsumer { get; set; }
        public CompteConsumer consumer { get; set; }
        public Annonce annonce { get; set; }
        public List<Transaction> listeTransaction { get; set; }
    }
}
