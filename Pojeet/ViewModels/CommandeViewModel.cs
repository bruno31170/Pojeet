using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.ViewModels
{
    public class CommandeViewModel
    {
        public CompteConsumer CompteConsumer { get; set; }
        public Transaction Transaction { get; set; }
        public Paiement Paiement { get; set; }
        public Virement Virement { get; set; }
        public double MargeBrute { get; set; }
        public double Reste { get; set; }
        public int NbTransaction { get; set; }
        public int id1 { get; set; }
        public int id2 { get; set; }
        public List<Transaction> ListetransactionMois { get; set; }
        public List<Transaction> ListetransactionJour { get; set; }
        public List<Transaction> Listetransaction { get; set; }
        public Argent Argent { get; set; }
        public List<CompteConsumer> listConsumer { get; set; }
    }
}
