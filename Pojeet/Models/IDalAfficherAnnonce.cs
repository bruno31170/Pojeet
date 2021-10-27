using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalAfficherAnnonce
    {
        CompteConsumer ObtientConsumer(int id);
        Annonce ObtientAnnonce(int id);
        List<Avis> ObtientAvis(int id);
    }
}
