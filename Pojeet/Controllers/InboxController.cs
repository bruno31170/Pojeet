using Microsoft.AspNetCore.Mvc;
using Pojeet.Models;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Controllers
{
    public class InboxController : Controller
    {
        private IDalInbox dalInbox;
        private IDal dal;
        public InboxController()
        {
            this.dalInbox = new DalInbox();
            this.dal = new Dal();
        }
        public IActionResult AfficherMessagerie(int id2, String MotCle)
        {
            int id = 0;
            Boolean authentifie = HttpContext.User.Identity.IsAuthenticated;
            if (authentifie)
            {
                CompteConsumer compteConsumer = dalInbox.ObtenirConsumer(HttpContext.User.Identity.Name);
                id = compteConsumer.ProfilId;
                Conversation Conversationid2 = new Conversation();
                List<Message> listeMessages = new List<Message>();
                List<Conversation> listeConversation = new List<Conversation>();
                Messagerie messagerie = new Messagerie();
                List<MessagerieConversation> messagerieConversation = new List<MessagerieConversation>();
                Transaction transaction = new Transaction();
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
                        listeConversation.Reverse();
                        Conversationid2 = dal.ObtientLaConversation(id2);
                        listeMessages = dal.ObtientTousLesMessages(id2);
                        messagerieConversation = dal.ObtientMessagerieConversation(id2);
                        dal.SupprimerNotification(id,id2);
                        transaction = dal.ObtientTransaction(Conversationid2.AnnonceId, Conversationid2.Auteur_Message.Id);
                        return View(new InboxViewModel { Authentifie = authentifie, Conversation = Conversationid2, List2 = listeMessages, id1 = messagerie.Id, id2 = id2, Messagerie = messagerie, MessagerieConversation = messagerieConversation, List1 = listeConversation, CompteConsumer = compteConsumer, NouvelleTransaction=transaction });
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
            return RedirectToAction("AfficherMessagerie", new { id2 = id2, MotCle = motCle });
        }

        [HttpPost]
        public IActionResult CreerMessage(int id1, int id2, Message nouveaumessage)
        {

            using (DalInbox ctx = new DalInbox())
            { 
                ctx.AjouterMessage(nouveaumessage.message, nouveaumessage.ProfilId, nouveaumessage.ConversationId, false);
                return RedirectToAction("AfficherMessagerie", new { id2 = id2 });
            }
        }

        [HttpPost]
        public IActionResult CreateTransaction(InboxViewModel ivm)
        {
            using (DalInbox ctx = new DalInbox())
            {
                String message1 = ivm.NouveauMessage.message + " Propose " + ivm.NouvelleTransaction.Montant + " euros";
                ctx.AjouterMessage(message1, ivm.NouveauMessage.ProfilId, ivm.NouveauMessage.ConversationId, true);
                ctx.CreerTransaction(ivm.NouvelleTransaction.Montant, ivm.NouvelleTransaction.AnnonceId, ivm.NouvelleTransaction.ProfilId);
            }
            using (Dal dal = new Dal())
            {
                Transaction transaction = dal.ObtientTransaction(ivm.NouvelleTransaction.AnnonceId, ivm.NouvelleTransaction.ProfilId);
                dal.ActualiserEtatTransaction(transaction.Reference, EtatTransaction.En_attente);
                if (transaction.Annonce.TypeDeAnnonce== Models.TypeAnnonce.Besoin)
                {
                    return RedirectToAction("AfficherMessagerie", new { id2 = ivm.id2 });
                }
                else
                {
                    PaiementViewModel viewModel = new PaiementViewModel { id = ivm.id2, Transaction = transaction, Message = null, Annonce=transaction.Annonce };
                    return View("Views/Paiement/PaiementPage.cshtml", viewModel);
                    //return RedirectToAction("Paiement", "PaiementPage", new { id2=ivm.id2, Transaction=transaction });
                }
            }
           
                
        }


        [HttpPost]
        public IActionResult ActualiserTransaction(int id, Transaction Transaction, Message Message)
        {

            using (DalInbox ctx = new DalInbox())
            {
                String message1 = Message.message + " accepte la proposition.";
                ctx.RemplacerMessage(Message.Id, false);
                ctx.AjouterMessage(message1, Message.ProfilId, Message.ConversationId, false);
                ctx.CreerPaiement(Transaction.AnnonceId, Transaction.ProfilId);
                ctx.CreerVirement(Transaction.AnnonceId, Transaction.ProfilId);
               
               
            }
            using (Dal dal = new Dal())
            {
                Transaction transaction = dal.ObtientTransaction(Transaction.AnnonceId, Transaction.ProfilId);
                dal.ActualiserEtatTransaction(transaction.Reference, EtatTransaction.Paye);
            }
            return RedirectToAction("AfficherMessagerie", new { id2 = id});
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
                return RedirectToAction("AfficherMessagerie", new { id2 = id2 });
            }

        }
        [HttpPost]
        public IActionResult CreerConversation(int id)
        {
            Messagerie messagerie = new Messagerie();
            int idConversation = 0;
            using (DalInbox ctx = new DalInbox())
            {
                CompteConsumer compteConsumer = dalInbox.ObtenirConsumer(HttpContext.User.Identity.Name);
                int id1 = compteConsumer.ProfilId;
                idConversation = ctx.CreerConversation(id1, id);
                messagerie = ctx.ObtientLaMessagerie(id1);
                ctx.AjouterNotificationMessagerie(id1, idConversation);
            }
           
            return RedirectToAction("AfficherMessagerie", new { id2 = idConversation });


        }

        public IActionResult RedirigerVersConversationAnnonce(int reference, int profilId)
        {
            Conversation conversation = new Conversation();
            using (DalInbox ctx = new DalInbox())
            {
                conversation = dalInbox.ObtenirConversationTransaction(reference, profilId);
            }
            return RedirectToAction("AfficherMessagerie", new { id2 = conversation.Id });
        }

    }
}
