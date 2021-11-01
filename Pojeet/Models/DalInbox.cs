using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalInbox : IDalInbox
    {
        private BddContext _context;

        public DalInbox()
        {
            _context = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public List<CompteConsumer> ObtientTousConsumer()
        {
            return _context.CompteConsumer.Include(c => c.Profil).ToList();
        }
        public Conversation ObtientLaConversation(int id)
        {
            Conversation conv = _context.Conversation.Where(r => r.Id == id).Include(c => c.Messages).Include(c => c.Annonce).Include(c => c.Auteur_Message.Profil).FirstOrDefault();
            return conv;
        }

        public List<Message> ObtientTousLesMessages(int id)
        {
            List<Message> listeMessages = _context.Message.Where(r => r.ConversationId == id).Include(c => c.Profil).ToList();
            var messages = listeMessages.OrderBy(c => c.Id).ToList();
            return messages;
        }
        public List<Conversation> ObtientLesConversations(int id)
        {
            List<Conversation> listeConversations = new List<Conversation>();
            List<MessagerieConversation> ListeMessagerieConversation = _context.MessagerieConversation.Where(r => r.MessagerieId == id).Include(c => c.Conversation).Include(c => c.Conversation.Auteur_Message.Profil).Include(c => c.Conversation.Annonce.profil).ToList();
            foreach (var listeMessagerieConversation in ListeMessagerieConversation)
            { listeConversations.Add(listeMessagerieConversation.Conversation); }
            //listeConversations.OrderBy(c => c.DateCreation).ToList();
            return listeConversations;
        }

        public (int, List<Conversation>) ObtientLesConversations(int id, String motCle, Messagerie messagerie)
        {
            List<Conversation> listeConversations = new List<Conversation>();
            List<Conversation> listeConversationsRecherchees = new List<Conversation>();
            List<MessagerieConversation> ListeMessagerieConversation = _context.MessagerieConversation.Where(r => r.MessagerieId == id).Include(c => c.Conversation.Messages).Include(c => c.Conversation.Auteur_Message.Profil).Include(c => c.Conversation.Annonce.profil).ToList();
            foreach (var listeMessagerieConversation in ListeMessagerieConversation)
            {
                listeConversations.Add(listeMessagerieConversation.Conversation);
            }
            foreach (var conversation in listeConversations)
            {
                if (conversation.Annonce.ProfilId == messagerie.ProfilId)
                {
                    if (conversation.Auteur_Message.Profil.Prenom.Contains(motCle, StringComparison.OrdinalIgnoreCase) || conversation.Auteur_Message.Profil.Nom.Contains(motCle, StringComparison.OrdinalIgnoreCase))
                    {
                        listeConversationsRecherchees.Add(conversation);
                    }
                }
                else
                {
                    if (conversation.Annonce.profil.Prenom.Contains(motCle, StringComparison.OrdinalIgnoreCase) || conversation.Annonce.profil.Prenom.Contains(motCle, StringComparison.OrdinalIgnoreCase))
                    {
                        listeConversationsRecherchees.Add(conversation);
                    }
                }
            }
            int id2 = listeConversationsRecherchees.First().Id;
            //listeConversations.OrderBy(c => c.DateCreation).ToList();
            return (id2, listeConversationsRecherchees);
        }

        public Messagerie ObtientLaMessagerie(int id)
        {
            Messagerie messagerie = _context.Messagerie.Where(r => r.ProfilId == id).Include(c => c.Profil).FirstOrDefault();
            return messagerie;
        }

        public Boolean VerificationMessagerieVide(int id)
        {
            List<MessagerieConversation> messagerieconv = _context.MessagerieConversation.Where(x => x.Messagerie.ProfilId == id).ToList();
            return messagerieconv.Count() == 0;
        }

        public int ObtientPremiereConversation(List<Conversation> listeConversation)
        {
            int id = 0;
            id = listeConversation.First().Id;
            return (id);
        }

        public List<MessagerieConversation> ObtientMessagerieConversation(int id)
        {
            List<MessagerieConversation> messagerieConversation = _context.MessagerieConversation.Where(r => r.ConversationId == id).Include(r => r.Conversation).Include(r => r.Messagerie).ToList();
            return messagerieConversation;
        }


        public void AjouterMessage(string textmessage, int profilId, int conversationId, Boolean messageProposition)

        {
            Message message = new Message
            {
                message = textmessage,
                Date = DateTime.Now,
                ProfilId = profilId,
                ConversationId = conversationId,
                MessageProposition = messageProposition
            };
            _context.Message.Add(message);
            _context.SaveChanges();
            ActualiserNotificationMessagerie(profilId,conversationId);
        }

        public void AjouterNotificationMessagerie(int id1, int id2)
        {
            Conversation conversation = _context.Conversation.Where(c => c.Id == id2).Include(c => c.Annonce.profil).Include(c=>c.Auteur_Message).FirstOrDefault();
            NotificationMessagerie notificationMessagerie1 = new NotificationMessagerie
            {
                ConversationId = id2,
                ProfilId = conversation.Annonce.ProfilId,
                MessagesNonLus = 0,
                Profil=conversation.Annonce.profil,

            };

             NotificationMessagerie notificationMessagerie2 = new NotificationMessagerie
             {
                 ConversationId = id2,
                 ProfilId = conversation.Auteur_Message.ProfilId,
                 MessagesNonLus = 0,
                 Profil = conversation.Auteur_Message.Profil,

             };
        _context.NotificationMessagerie.Add(notificationMessagerie1);
        _context.NotificationMessagerie.Add(notificationMessagerie2);
         _context.SaveChanges();
        }

        public void ActualiserNotificationMessagerie(int id1, int id2)
        {
            Profil profil = _context.Messagerie.Where(c => c.ProfilId==id1).Include(c=> c.Profil).FirstOrDefault().Profil;
            Conversation conversation = _context.Conversation.Where(c => c.Id == id2).Include(c => c.Annonce.profil).Include(c=>c.Auteur_Message.Profil).FirstOrDefault();
            NotificationMessagerie notificationMessagerie = null;
            if (profil.Id == conversation.Auteur_Message.ProfilId)
            {
              notificationMessagerie = _context.NotificationMessagerie.Where(c => c.ProfilId == conversation.Annonce.ProfilId && c.ConversationId == id2).FirstOrDefault();
            }
            else
            {
               notificationMessagerie = _context.NotificationMessagerie.Where(c => c.ProfilId == conversation.Auteur_Message.ProfilId && c.ConversationId == id2).FirstOrDefault();
            }
            notificationMessagerie.MessagesNonLus = notificationMessagerie.MessagesNonLus + 1;
            _context.SaveChanges();
        }

        public void SupprimerNotification(int id1, int id2)
        {
            NotificationMessagerie notificationMessagerie = _context.NotificationMessagerie.Where(c => c.ProfilId == id1 && c.ConversationId == id2).FirstOrDefault();
            notificationMessagerie.MessagesNonLus = 0;
            _context.SaveChanges();

        }


        public void RemplacerMessage(int messageId, Boolean messageProposition)
        {
            Message message = _context.Message.Include(c => c.Profil).Where(c => c.Id == messageId).FirstOrDefault();

            if (message != null)
            {
                message.MessageProposition = messageProposition;
            };
        }


        public void Dispose()
        {
            _context.Dispose();
        }



       

      
        public void CreerMessagerie(int id)
        {
            Messagerie messagerie = new Messagerie()
            {
                ProfilId = id
            };
            _context.Messagerie.Add(messagerie);
            _context.SaveChanges();
        }




        public CompteConsumer ObtenirConsumer(int id)
        {
            //return this._context.CompteConsumer.Include(c => c.Profil).FirstOrDefault(c => c.Id == id);
            //return this._context.CompteConsumer.FirstOrDefault(u => u.Id == id);
            return _context.CompteConsumer.Where(c => c.Id == id).Include(c => c.Profil).Include(c => c.Profil.ListeAvis).Include(c=>c.Profil.notificationsMessagerie).FirstOrDefault();

        }

        public List<Avis> ObtenirListeAvis(int id)
        {
            Profil profil = ObtenirConsumer(id).Profil;
            return _context.Avis.Where(r => r.ProfilId == profil.Id).Include(c => c.CompteConsumer).Include(c => c.CompteConsumer.Profil).ToList();
        }

        public CompteConsumer ObtenirConsumer(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirConsumer(id);
            }
            return null;
        }

        public void CreerTransaction(double montant, int annonceId, int profilId)
        {

            Transaction transaction = new Transaction
            {
                Date = DateTime.Now,
                AnnonceId = annonceId,
                Montant = montant,
                MontantHelper = Math.Round(montant -(montant * 0.05) ,2),
                EtatTransaction = EtatTransaction.En_attente,
                ProfilId = profilId,
                Profil= _context.Profil.Where(c => c.Id ==profilId).FirstOrDefault(),
            
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public Profil IdentifierPayant(Transaction transaction)
        { 
            Profil profil = new Profil();
            if (_context.Annonce.Where(c=> c.Id==transaction.AnnonceId).FirstOrDefault().TypeDeAnnonce==TypeAnnonce.Besoin)
            {
                profil = transaction.Annonce.profil;
            }
            else
            {
                profil = transaction.Profil;
            }
            return profil;
        }
        public Transaction ObtientTransaction(int annonceId, int profilId)
        {
            Transaction transaction = _context.Transactions.Where(r => r.AnnonceId == annonceId && r.ProfilId == profilId).Include(r => r.Annonce).FirstOrDefault();
            return transaction;

        }
        public void CreerPaiement(int annonceId, int profilId)
        {
            Transaction transaction= ObtientTransaction(annonceId, profilId);
            Paiement paiement = new Paiement
            {
                Date = DateTime.Now,
                TransactionMontant = transaction.Montant,
                TransactionReference = transaction.Reference,
                StatutPaiement = StatutPaiement.Payé,
                ProfilId=IdentifierPayant(transaction).Id,
            };
            
            _context.Paiement.Add(paiement);

            transaction.EtatTransaction = EtatTransaction.Paye;

            _context.SaveChanges();
        }

        public int IdentifierRecepteur(Transaction transaction)
            
        {
            
            Annonce annonce = _context.Annonce.Where(c => c.Id == transaction.Annonce.Id).FirstOrDefault();
            int profilId = 0;
            if (annonce.TypeDeAnnonce == TypeAnnonce.Besoin)
            {
                profilId = transaction.ProfilId;
            }
            else
            {
                profilId = transaction.Annonce.ProfilId;
            }
            return profilId;
        }

        public void CreerVirement(int annonceId, int profilId)
        {
            Transaction transaction = _context.Transactions.Where(r => r.AnnonceId == annonceId && r.ProfilId == profilId).Include(r => r.Annonce).FirstOrDefault();
            Virement virement = new Virement
            {
                TransactionReference = transaction.Reference,
                StatutVirement = StatutVirement.NonEnvoyé,
                ProfilId = IdentifierRecepteur(transaction),
                VirementMontant=transaction.MontantHelper,
            };
            _context.Virement.Add(virement);
            _context.SaveChanges();
        }

        public void SupprimerTransaction(int annonceId)
        {
            _context.Transactions.RemoveRange(_context.Transactions.Where(r => r.AnnonceId == annonceId).FirstOrDefault());
            _context.SaveChanges();
        }

        public int CreerConversation(int id1, int id2)
        { 
            Conversation conversation = new Conversation
            {
                CompteConsumerId = _context.CompteConsumer.Where(r => r.ProfilId == id1).FirstOrDefault().Id,
                AnnonceId = id2,
                Annonce= _context.Annonce.Where(r => r.Id == id2).FirstOrDefault(),
            };
            _context.Conversation.Add(conversation);
            _context.SaveChanges();
            _context.MessagerieConversation.AddRange(
           new MessagerieConversation
           {
               MessagerieId = _context.Messagerie.Where(r => r.ProfilId == id1).FirstOrDefault().Id,
               ConversationId = conversation.Id
           },
            new MessagerieConversation
            {
                MessagerieId = conversation.Annonce.ProfilId,
                ConversationId = conversation.Id
            });
            _context.SaveChanges();
            return (conversation.Id);
        }

        public Conversation ObtenirConversationTransaction(int reference, int profilId)
        {
            Transaction transaction = _context.Transactions.Where(r => r.Reference == reference).FirstOrDefault();
            Annonce annonce= _context.Annonce.Where(r => r.Id == transaction.AnnonceId).FirstOrDefault();
            Conversation conversation = _context.Conversation.Where(c => c.Annonce.Id == transaction.Annonce.Id && (c.Auteur_Message.ProfilId==profilId || c.Annonce.ProfilId== profilId)).FirstOrDefault();
            return conversation;
        }

        public Transaction ObtenirTransaction(int id1, int id2)
        {
            Transaction transaction = _context.Transactions.Where(r => r.AnnonceId == id1 && r.ProfilId==id2).Include(r => r.Annonce).FirstOrDefault();
            return transaction;
        }
    }

    }

