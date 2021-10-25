﻿using Microsoft.AspNetCore.Http;
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
        public List<Conversation> ObtientToutesLesConversations(int id)
        {
            List<Conversation> listeConversations = _context.Conversation.Where(r => r.MessagerieId == id).Include(c => c.Messages).Include(c => c.Annonce).Include(c => c.Auteur_Message.Profil).ToList();
            return listeConversations;
        }

        public List<Message> ObtientTousLesMessages(int id)
        {
            List<Message> listeMessages = _context.Message.Where(r => r.ConversationId == id).Include(c => c.Profil).ToList();
            var messages = listeMessages.OrderBy(c => c.Id).ToList();
            return messages;
        }
        public Messagerie ObtientLaMessagerie(int id)
        {
            Messagerie messagerie = _context.Messagerie.Where(r => r.Id == id).Include(c => c.Profil).Include(c => c.Historique).FirstOrDefault();
            return messagerie;
        }

        public void AjouterMessage(string textmessage, int profilId, int conversationId)
        {

            Message message = new Message
            {
                message = textmessage,
                Date = DateTime.Now,
                ProfilId = profilId,
                ConversationId = conversationId
            };
            _context.Message.Add(message);
            _context.SaveChanges();
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

            CompteConsumer consumer = new CompteConsumer { MotDePasse = motDePasse, Pseudo = pseudo, Profil = profil };

            _context.CompteConsumer.Add(consumer);
            _context.SaveChanges();
            return consumer.Id;
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
            noteGlobale = noteGlobale / i;
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



        public int AjouterProvider(CompteConsumer compteConsumer, string iban, string bic, string titulaire, string documentIdentification, List<string> competence)
        {

            Rib rib = new Rib
            {
                Iban = iban,
                Bic = bic,
                TitulaireCompte = titulaire
            };

            CompteProvider Provider = new CompteProvider
            {
                CompteConsumerId = compteConsumer.Id,
                DocumentIdentification = documentIdentification,
                Rib = rib,
                Etat = 0,
                Competence = competence
            };


            _context.CompteProvider.Add(Provider);
            _context.SaveChanges();
            return Provider.Id;
        }

        public CompteProvider ObtenirHelper(int id)
        {
            return _context.CompteProvider.Where(c => c.CompteConsumerId == id).Include(c => c.Rib).FirstOrDefault();
        }


    }
}
