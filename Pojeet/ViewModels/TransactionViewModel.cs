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
        public List<CompteProvider> listProvider { get; set; }
        public Annonce annonce { get; set; }
        public Argent Argent { get; set; }
        public Argent ArgentAnnee { get; set; }

        //Attention c'est très long c'est pour les comptes gestionnaire financier
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
        public List<CompteConsumer> CompteConsumerJanvier { get; set; }
        public List<CompteConsumer> CompteConsumerFevrier { get; set; }
        public List<CompteConsumer> CompteConsumerMars { get; set; }
        public List<CompteConsumer> CompteConsumerAvril { get; set; }
        public List<CompteConsumer> CompteConsumerMai { get; set; }
        public List<CompteConsumer> CompteConsumerJuin { get; set; }
        public List<CompteConsumer> CompteConsumerJuillet { get; set; }
        public List<CompteConsumer> CompteConsumerAout { get; set; }
        public List<CompteConsumer> CompteConsumerSeptembre { get; set; }
        public List<CompteConsumer> CompteConsumerOctobre { get; set; }
        public List<CompteConsumer> CompteConsumerNovembre { get; set; }
        public List<CompteConsumer> CompteConsumerDecembre { get; set; }
        public List<CompteConsumer> CompteConsumerTotal { get; set; }
        public List<CompteProvider> CompteProviderTotal { get; set; }

    }
}
