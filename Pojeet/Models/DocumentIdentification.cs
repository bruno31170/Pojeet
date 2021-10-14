using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DocumentIdentification
    {
        public int Id { get; set; }
        public enum Document
        {
            CarteIdentite,
            PermisConduire
        }
        public Image CarteIdentite { get; set; }

        public Image PermisConduire { get; set; }
    }
}
