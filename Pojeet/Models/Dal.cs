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
    public class Dal : IDal
    {
        private BddContext _context;

        public Dal()
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
            MessagerieConversation messagerieConversation = _context.MessagerieConversation.Where(r => r.Messagerie.ProfilId == id).Include(c => c.Messagerie.Profil).FirstOrDefault();
            return messagerieConversation.Messagerie;
        }

        public Boolean VerificationMessagerieVide(int id)
        {
            MessagerieConversation messagerieconv = _context.MessagerieConversation.SingleOrDefault(x => x.Messagerie.ProfilId == id);
            return messagerieconv == null;
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



        // pour l'authentification
        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "HelpMyCar" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
        public CompteConsumer Authentifier(string pseudo, string password)
        {
            string motDePasse = EncodeMD5(password);
            CompteConsumer user = this._context.CompteConsumer.Include(c => c.Profil).Where(u => u.Pseudo == pseudo && u.MotDePasse == motDePasse).FirstOrDefault();
            return user;
        }


        public int AjouterConsumer(string motdepasse, string pseudo, string nom, string prenom, string dateNaissance,
           string adresse, string ville, string code_postal, Pays pays, string mail, int numeroTelephone, string description, IFormFile photo)
        {
            string motDePasse = EncodeMD5(motdepasse);

            Profil profil = new Profil
            {
                Nom = nom,
                Prenom = prenom,
                DateDeNaissance = dateNaissance,
                Adresse = adresse,
                Ville = ville,
                CodePostal = code_postal,
                Pays = pays,
                Mail = mail,
                NumeroTelephone = numeroTelephone,
                Description = description,

            };

            if (photo != null)
            {
                profil.Photo = photo.FileName;
            }

            CompteConsumer consumer = new CompteConsumer { MotDePasse = motDePasse, Pseudo = pseudo, Profil = profil, DateInscription = DateTime.Now };

            _context.CompteConsumer.Add(consumer);
            _context.SaveChanges();
            return consumer.Id;
        }
        public void CreerMessagerie(int id)
        {
            Messagerie messagerie = new Messagerie()
            {
                ProfilId = id
            };
            _context.Messagerie.Add(messagerie);
            //_context.SaveChanges();
        }

        public void ModifierConsumer(int id, string pseudo, string nom, string prenom, string dateNaissance,
          string adresse, string ville, string code_postal, Pays pays, string mail, int numeroTelephone, string description, IFormFile photo)
        {
            CompteConsumer consumer = _context.CompteConsumer.Include(c => c.Profil).Where(c => c.Id == id).FirstOrDefault();

            if (consumer != null)
            {
                consumer.Pseudo = pseudo;
                consumer.Profil.Nom = nom;
                consumer.Profil.Prenom = prenom;
                consumer.Profil.DateDeNaissance = dateNaissance;
                consumer.Profil.Adresse = adresse;
                consumer.Profil.Ville = ville;
                consumer.Profil.CodePostal = code_postal;
                consumer.Profil.Pays = pays;
                consumer.Profil.Mail = mail;
                consumer.Profil.NumeroTelephone = numeroTelephone;
                consumer.Profil.Description = description;
                _context.SaveChanges();
            }

            if (photo != null)
            {
                consumer.Profil.Photo = photo.FileName;
                _context.SaveChanges();
            }
            else if (photo == null)
            {
                consumer.Profil.Photo = consumer.Profil.Photo;
                _context.SaveChanges();
            }


        }

        public void SuppressionConsumer(int id)
        {
            CompteConsumer consumer = _context.CompteConsumer.Find(id);
            if (consumer != null)
            {
                _context.CompteConsumer.Remove(consumer);
                _context.SaveChanges();
            }
        }

        public CompteConsumer ObtenirConsumer(int id)
        {
            //return this._context.CompteConsumer.Include(c => c.Profil).FirstOrDefault(c => c.Id == id);
            //return this._context.CompteConsumer.FirstOrDefault(u => u.Id == id);
            return _context.CompteConsumer.Where(c => c.Id == id).Include(c => c.Profil).Include(c => c.Profil.ListeAvis).FirstOrDefault();

        }

        public List<Avis> ObtenirListeAvis(int id)
        {
            Profil profil = ObtenirConsumer(id).Profil;
            return _context.Avis.Where(r => r.ProfilId == profil.Id).Include(c => c.CompteConsumer).Include(c => c.CompteConsumer.Profil).ToList();
        }
        public int ObtenirNoteGlobale(int id)
        {
            List<Avis> listeAvis = ObtenirConsumer(id).Profil.ListeAvis;
            int i = 0;
            int noteGlobale = 0;
            foreach (Avis avis in listeAvis)
            {
                noteGlobale = (noteGlobale + avis.note);
                i++;
            }
            if (i != 0)
            {
                noteGlobale = noteGlobale / i;
            }

            return noteGlobale;

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


        public int AjouterProvider(CompteConsumer compteConsumer, string iban, string bic, string titulaire, IFormFile photo, List<string> competence)
        {

            string StringCompetence = string.Join(",", competence);

            Rib rib = new Rib
            {
                Iban = iban,
                Bic = bic,
                TitulaireCompte = titulaire
            };

            CompteProvider Provider = new CompteProvider
            {
                CompteConsumerId = compteConsumer.Id,
                Rib = rib,
                Etat = 0,
                Competence = StringCompetence
            };

            if (photo != null)
            {
                Provider.DocumentIdentification = photo.FileName;
            }

            _context.CompteProvider.Add(Provider);
            _context.SaveChanges();
            return Provider.Id;
        }

        public CompteProvider ObtenirHelper(int id)
        {
            return _context.CompteProvider.Where(c => c.CompteConsumerId == id).Include(c => c.Rib).FirstOrDefault();
        }
        public CompteProvider ObtenirHelper(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirHelper(id);
            }
            return null;

        }


        public void CreerPaiement(int annonceId)
        {
            Transaction transaction = _context.Transactions.Where(r => r.AnnonceId == annonceId).FirstOrDefault();
            Paiement paiement = new Paiement
            {
                Date = DateTime.Now,
                TransactionMontant = transaction.Montant,
                TransactionReference = transaction.Reference,
            };
            _context.Paiement.Add(paiement);
            _context.SaveChanges();
        }

        public List<Transaction> ObtientTransaction(int id)
        {
            List<Transaction> listeTransaction = this._context.Transactions.Where(c => c.ProfilId == id).Include(c => c.Profil).Include(c => c.Annonce.profil).ToList();
            return listeTransaction;
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
                Annonce = _context.Annonce.Where(r => r.Id == id2).FirstOrDefault()
            };
            _context.Conversation.Add(conversation);
            _context.SaveChanges();
            _context.MessagerieConversation.AddRange(
           new MessagerieConversation
           {
               MessagerieId = ObtientLaMessagerie(id1).Id,
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

    }

}

