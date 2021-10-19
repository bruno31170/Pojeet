using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public int auteur_id;
        public List<Message> Messages;
    }
}
