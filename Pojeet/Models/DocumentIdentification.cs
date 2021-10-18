using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DocumentIdentification
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public Document Document { get; set; }
    }
    public enum Document
    {
        CarteIdentite,
        PermisConduire
    }
}
