using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pojeet.Models
{
	public class Message
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string message { get; set; }


	
		public int ProfilId { get; set; }
		public virtual Profil Profil { get; set; }

		public int ConversationId { get; set; }
		public virtual Conversation Conversation { get; set; }
	}

}