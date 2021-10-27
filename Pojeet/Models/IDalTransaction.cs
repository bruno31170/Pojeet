using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalTransaction
    {
        List<Transaction> ObtientTransaction();
        List<CompteConsumer> ObtientConsumer();

        CompteConsumer ObtientCompteConsumer(int id);

        List<Transaction> ObtientTransaction(int id);

        Transaction ObtientUneTransaction(int reference);
        double ObtenirMargeBrute(int reference);
        double ObtenirReste(int reference);
        int ObtenirNbTransaction(int id);
        Paiement ObtenirPaiement(int reference);
    }
}
