using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalProfil : IDisposable
    {
        
        List<Annonce> ObtientAnnonceProfil(int profilId);

        CompteConsumer ObtientConsumer(int id);

        List<Annonce> ObtientAnnonce();
    }
}
