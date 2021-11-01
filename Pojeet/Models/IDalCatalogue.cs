using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalCatalogue : IDisposable
    {
        
        List<Annonce> ObtientAnnonce();

        CompteConsumer ObtientConsumer(int id);



        List<Annonce> RechercherAnnonce(ProfilViewModel uvm);
        Conversation Contact(int id1, int id2);
        List<CompteConsumer> ProfilsMieuxNotes();
    }
}
