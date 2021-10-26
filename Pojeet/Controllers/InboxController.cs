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

        public IActionResult AfficherMessagerie(int id1, int id2, List<Conversation> List1)
        {
            Conversation Conversationid2 = new Conversation();
            List<Message> listeMessages = new List<Message>();
            List<Conversation> listeConversation = List1.ToList();
            Messagerie messagerie = new Messagerie();
            List<MessagerieConversation> messagerieConversation = new List<MessagerieConversation>();
            using (IDal dal = new Dal())
            {
                Conversationid2 = dal.ObtientLaConversation(id2);
                listeMessages = dal.ObtientTousLesMessages(id2);
                messagerie = dal.ObtientLaMessagerie(id1);
                messagerieConversation = dal.ObtientMessagerieConversation(id2);
                if  (listeConversation.Count==0)
                    {
                    listeConversation = dal.ObtientLesConversations(id1);
                }
            }
            return View(new MyViewModel { Conversation = Conversationid2, List2 = listeMessages, id1 = id1, id2 = id2, Messagerie = messagerie, MessagerieConversation = messagerieConversation, List1= listeConversation });
        }
       

        [HttpPost]
        public IActionResult RechercherConversation(int id1 ,int id2, String motCle)
        {
            List<Conversation> listeConv = new List<Conversation>();
            Messagerie messagerie = new Messagerie();
            using (IDal dal = new Dal())
            {
                messagerie = dal.ObtientLaMessagerie(id1);
                (id2,listeConv) = dal.ObtientLesConversations(id1, motCle, messagerie);
            }
            return RedirectToAction("AfficherMessagerie", new { id1 = id1, id2 = id2,List1=listeConv.ToList()});
        }





        [HttpPost]
        public IActionResult CreerMessage(Message nouveaumessage)
        {

            using (Dal ctx = new Dal())
            {
                ctx.AjouterMessage(nouveaumessage.message, nouveaumessage.ProfilId, nouveaumessage.ConversationId, false);
                return RedirectToAction("AfficherMessagerie", new { id1 = 2, id2 = 1 });
            }

        }

        [HttpPost]
        public IActionResult CreateTransaction(Transaction nouvelleTransaction, Message nouveaumessage)
        {
            using (Dal ctx = new Dal())
            {
                String message1 = nouveaumessage.message + " Propose " + nouvelleTransaction.Montant + " euros";
                ctx.AjouterMessage(message1, nouveaumessage.ProfilId, nouveaumessage.ConversationId, true);
                ctx.CreerTransaction(nouvelleTransaction.Montant, nouvelleTransaction.AnnonceId, nouvelleTransaction.ProfilId);
                return RedirectToAction("AfficherMessagerie", new { id1 = 2, id2 = 1 });


            }
        }

        [HttpPost]
        public IActionResult ActualiserTransaction(Transaction nouvelletransaction, Message nouveaumessage)
        {

            using (Dal ctx = new Dal())
            {
                String message1 = nouveaumessage.message + " accepte la proposition.";
                ctx.RemplacerMessage(nouveaumessage.Id, false);
                ctx.AjouterMessage(message1, nouveaumessage.ProfilId, nouveaumessage.ConversationId, false);
                ctx.CreerPaiement(nouvelletransaction.AnnonceId);
                return RedirectToAction("AfficherMessagerie", new { id1 = 2, id2 = 1 });
            }
        }

        [HttpPost]
        public IActionResult SupprimerTransaction(Transaction nouvelletransaction, Message nouveaumessage)
        {

            using (Dal ctx = new Dal())
            {
                String message1 = nouveaumessage.message + " refuse la proposition.";
                ctx.RemplacerMessage(nouveaumessage.Id, false);
                ctx.AjouterMessage(message1, nouveaumessage.ProfilId, nouveaumessage.ConversationId, false);
                ctx.SupprimerTransaction(nouvelletransaction.AnnonceId);
                return RedirectToAction("AfficherMessagerie", new { id1 = 2, id2 = 1 });


            }

        }
    }
}
