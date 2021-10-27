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
        private IDalInbox dal;

        public InboxController()
        {
            this.dal = new DalInbox();
        }
        public IActionResult AfficherMessagerie(int id2, String MotCle)
        {
            int id = 0;
            Boolean authentifie = HttpContext.User.Identity.IsAuthenticated;
            if (authentifie)
            {
                CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                id = compteConsumer.ProfilId;
                Conversation Conversationid2 = new Conversation();
                List<Message> listeMessages = new List<Message>();
                List<Conversation> listeConversation = new List<Conversation>();
                Messagerie messagerie = new Messagerie();
                List<MessagerieConversation> messagerieConversation = new List<MessagerieConversation>();
                using (IDalInbox dal = new DalInbox())
                {
                    Boolean verif = dal.VerificationMessagerieVide(id);
                    if (verif == false)
                    {
                        messagerie = dal.ObtientLaMessagerie(id);
                        listeConversation = dal.ObtientLesConversations(messagerie.Id);
                        if (MotCle != null)
                        {
                            (id2, listeConversation) = dal.ObtientLesConversations(id, MotCle, messagerie);
                        }
                        if (id2 == 0)
                        {
                            id2 = dal.ObtientPremiereConversation(listeConversation);
                        }
                        Conversationid2 = dal.ObtientLaConversation(id2);
                        listeMessages = dal.ObtientTousLesMessages(id2);
                        messagerieConversation = dal.ObtientMessagerieConversation(id2);
                        return View(new InboxViewModel { Authentifie=authentifie, Conversation = Conversationid2, List2 = listeMessages, id1 = messagerie.Id, id2 = id2, Messagerie = messagerie, MessagerieConversation = messagerieConversation, List1 = listeConversation });
                    }
                    else
                    {
                        return RedirectToAction("MessagerieVide");
                    }
                }
            }
            return View();
        }
        public IActionResult MessagerieVide()
        {
            return View();
        }
            [HttpPost]
        public IActionResult RechercherConversation(int id2, String motCle)
        {
            return RedirectToAction("AfficherMessagerie", new {id2 = id2,MotCle=motCle });
        }

        [HttpPost]
        public IActionResult CreerMessage(int id2, Message nouveaumessage)
        {

            using (DalInbox ctx = new DalInbox())
            {
                ctx.AjouterMessage(nouveaumessage.message, nouveaumessage.ProfilId, nouveaumessage.ConversationId, false);
                return RedirectToAction("AfficherMessagerie", new {id2 = id2 });
            }
        }

        [HttpPost]
        public IActionResult CreateTransaction(int id2, Transaction nouvelleTransaction, Message nouveaumessage)
        {
            using (DalInbox ctx = new DalInbox())
            {
                String message1 = nouveaumessage.message + " Propose " + nouvelleTransaction.Montant + " euros";
                ctx.AjouterMessage(message1, nouveaumessage.ProfilId, nouveaumessage.ConversationId, true);
                ctx.CreerTransaction(nouvelleTransaction.Montant, nouvelleTransaction.AnnonceId, nouvelleTransaction.ProfilId);
                return RedirectToAction("AfficherMessagerie", new {id2 = id2 });


            }
        }

        [HttpPost]
        public IActionResult ActualiserTransaction(int id2, Transaction nouvelletransaction, Message nouveaumessage)
        {

            using (DalInbox ctx = new DalInbox())
            {
                String message1 = nouveaumessage.message + " accepte la proposition.";
                ctx.RemplacerMessage(nouveaumessage.Id, false);
                ctx.AjouterMessage(message1, nouveaumessage.ProfilId, nouveaumessage.ConversationId, false);
                ctx.CreerPaiement(nouvelletransaction.AnnonceId);
                ctx.CreerVirement(nouvelletransaction.AnnonceId);
                return RedirectToAction("AfficherMessagerie", new {id2 = id2 });
            }
        }

        [HttpPost]
        public IActionResult SupprimerTransaction(int id2, Transaction nouvelletransaction, Message nouveaumessage)
        {

            using (DalInbox ctx = new DalInbox())
            {
                String message1 = nouveaumessage.message + " refuse la proposition.";
                ctx.RemplacerMessage(nouveaumessage.Id, false);
                ctx.AjouterMessage(message1, nouveaumessage.ProfilId, nouveaumessage.ConversationId, false);
                ctx.SupprimerTransaction(nouvelletransaction.AnnonceId);
                return RedirectToAction("AfficherMessagerie", new {id2 = id2});
            }

        }
            [HttpPost]
            public IActionResult CreerConversation(int id)
            {
            Messagerie messagerie = new Messagerie();
            int idConversation = 0;
             using (DalInbox ctx = new DalInbox())
            {
                CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
                int id1 = compteConsumer.ProfilId;
                idConversation =ctx.CreerConversation(id1,id);
                messagerie = ctx.ObtientLaMessagerie(id1);
            }

             return RedirectToAction("AfficherMessagerie", new {id2=idConversation});
                

            }
        }
    
}
