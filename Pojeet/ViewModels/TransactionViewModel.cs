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
        public List<Transaction> TransactionTotale { get; set; }
        public List<CompteConsumer> listConsumer { get; set; }
        public Annonce annonce { get; set; }
        public Argent Argent { get; set; }
        public Argent ArgentAnnee { get; set; }

        //Attention c'est très long c'est pour les comptes comptabilité
        public List<Transaction> TransactionJanvier { get; set; }
        public List<Transaction> TransactionFevrier { get; set; }
        public List<Transaction> TransactionMars { get; set; }
        public List<Transaction> TransactionAvril { get; set; }
        public List<Transaction> TransactionMai { get; set; }
        public List<Transaction> TransactionJuin { get; set; }
        public List<Transaction> TransactionJuillet { get; set; }
        public List<Transaction> TransactionAout { get; set; }
        public List<Transaction> TransactionSeptembre { get; set; }
        public List<Transaction> TransactionOctobre { get; set; }
        public List<Transaction> TransactionNovembre { get; set; }
        public List<Transaction> TransactionDecembre { get; set; }
        public Argent ArgentJanvier { get; set; }
        public Argent ArgentFevrier { get; set; }
        public Argent ArgentMars { get; set; }
        public Argent ArgentAvril { get; set; }
        public Argent ArgentMai { get; set; }
        public Argent ArgentJuin { get; set; }
        public Argent ArgentJuillet { get; set; }
        public Argent ArgentAout { get; set; }
        public Argent ArgentSeptembre { get; set; }
        public Argent ArgentOctobre { get; set; }
        public Argent ArgentNovembre { get; set; }
        public Argent ArgentDecembre { get; set; }
    }
}
