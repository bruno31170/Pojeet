using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<CompteConsumer> ObtientTousConsumer();
        int CreerConsumer(string lieu, string telephone);
        void ModifierConsumer(int id, string lieu, string telephone);
        void SuppressionConsumer(int id);
    }
}
