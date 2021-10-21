using System;
using System.Collections.Generic;

namespace Pojeet.Models
{
	public class Messagerie
	{
		public int Id { get; set; }
		public virtual List<Conversation> Historique { get; set; }
	}
}

