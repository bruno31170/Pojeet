using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalLaisserAvis
    {
        Profil ObtientProfil(int id);
        void EnregistrerAvis(Avis avis);
        void ActualiserNoteGlobale(Avis avis);
        void SuprimerNotification(Avis avis);
        bool TransactionExistante(int id1, int id2);
    }
}
