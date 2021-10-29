using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.ViewModels
{
    public class GPViewModel
    {
        public bool Authentifie { get; set; }
        public string ErrorMessage { get; set; }
        public GestionnairePlateforme gestionnairePlatforme { get; set; }
    }
}
