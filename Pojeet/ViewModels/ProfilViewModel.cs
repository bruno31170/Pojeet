using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.ViewModels
{
    public class ProfilViewModel
    {
        public CompteConsumer CompteConsumer { get; set; }
        public List<Annonce> Annonce { get; set; }

    }
}
