using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class InboxController : Controller
    {

        public IActionResult AfficherMessagerie(int id1, int id2)
        {
            List<Conversation> listeConversations = new List<Conversation>();
            List<Message> listeMessages = new List<Message>();

            using (IDal dal = new Dal())
            {
                listeConversations = dal.ObtientToutesLesConversations(id1);
                listeMessages = dal.ObtientTousLesMessages(id2);
            }
            return View(new MyViewModel { List1 = listeConversations, List2 = listeMessages, id1 = id1, id2 = id2 });
        }

        [HttpPost]
        public IActionResult AfficherMessagerie(Message nouveaumessage)
        {
            
            using (Dal ctx = new Dal())
            {
                ctx.AjouterMessage(nouveaumessage.message, nouveaumessage.ProfilId, nouveaumessage.ConversationId);
                return RedirectToAction("AfficherMessagerie", new { id1 = 1, id2 = 1 });
            }

        }

    }
}
