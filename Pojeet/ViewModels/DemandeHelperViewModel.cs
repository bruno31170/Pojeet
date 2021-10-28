using System;
using System.Collections.Generic;
using Pojeet.Models;

namespace Pojeet.ViewModels
{
    public class DemandeHelperViewModel
    {
        public CompteConsumer CompteConsumer { get; set; }
        public List<CompteConsumer> ListConsumer { get; set; }
        public CompteProvider CompteProvider { get; set; }
        public List<CompteProvider> listProvider { get; set; }
    }
}
