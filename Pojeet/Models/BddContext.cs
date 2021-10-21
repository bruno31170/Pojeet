using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class BddContext : DbContext
    {
        public DbSet<CompteConsumer> CompteConsumer { get; set; }
        public DbSet<CompteProvider> CompteProvider { get; set; }
        public DbSet<DocumentIdentification> DocumentIdentification { get; set; }
        public DbSet<Profil> Profil { get; set; }
        public DbSet<Annonce> Annonce { get; set; }
        public DbSet<GestionnairePlateforme> GestionnairePlateforme { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Messagerie> Messagerie { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Avis> Avis { get; set; }


        public DbSet<Rib> Rib { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Paiement> Paiement { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            
            optionsBuilder.UseMySql("server=localhost;user id=root;password=123456789;database=Projet2");


        }
        public void InitializeDb()
        {


           this.Database.EnsureDeleted();
           this.Database.EnsureCreated();
            this.Profil.AddRange(
                new Profil



                {
                    Id = 1,
                    Description = "Mécanicien",
                    Nom = "Guissouma",
                    Prenom = "Ines",
                    DateDeNaissance = "12/12/2020",
                    Adresse = "Boulevard Rocheplatte",
                    Ville = "Orléans",
                    CodePostal = "45000",
                    Pays = "France",
                    Mail = "inesguissouma@gmail.com",
                    NumeroTelephone=6875,
                    Photo= "https://bootdey.com/img/Content/avatar/avatar3.png"
                },
                new Profil
                {
                    Id = 2,
                    Description = "Besoin",
                    Nom = "LePillouer",
                    Prenom = "Cécile",
                    DateDeNaissance = "12/12/2020",
                    Adresse = "Boulevard Rocheplatte",
                    Ville = "Orléans",
                    CodePostal = "45000",
                    Pays = "France",
                    Mail = "CécileLepillouer@gmail.com",
                    NumeroTelephone = 6257,
                    Photo = "https://bootdey.com/img/Content/avatar/avatar5.png"
                });
            this.CompteConsumer.AddRange(
                new CompteConsumer
                {
                    Id = 1,
                    Pseudo = "Toto",
                    MotDePasse = "lolilol",
                    ProfilId = 1,
                    statut = Models.CompteConsumer.Statut.Actif
                }
            ) ;
            this.Message.AddRange(
            new Message
            {
                Id = 1,
                Date = new DateTime(2005, 11, 20, 12, 1, 10),
                message = "Bonjour, je pourrais vous rendre le service que vous demandez ce weekend,êtes vous d'accord?",
                ProfilId = 1,
                ConversationId = 1
            },
            new Message
            {
                Id = 2,
                Date = new DateTime(2005, 11, 20, 12, 1, 10),
                message = " Bonjour, oui bien sûr, vous demander combien ? ",
                ProfilId = 2,
                ConversationId = 1
            }); 
            this.Conversation.AddRange(
            new Conversation
            {
                Id = 1,
                CompteConsumerId = 1,
                MessagerieId = 1

            }) ;
            this.Messagerie.AddRange(
            new Messagerie
            {
                Id = 1

            });

            this.Annonce.AddRange(
                new Annonce
                {
                    Id = 1,
                    TypeDeAnnonce = 0,
                    TitreAnnonce = "Titre",
                    Description = "Blablabla",
                    DateParution = new DateTime(2021, 11, 20, 12, 1, 10),
                    Localisation = "13000",
                    DateButoir = new DateTime(2021, 11, 20, 12, 1, 10),
                    Prix = 100,
                    CategorieDeAnnonce = 0,
                    ProfilId = 1,





                });

            this.Transactions.AddRange(
                new Transaction
                {
                    Reference = 123,
                    Date = new DateTime(2021, 11, 20, 12, 1, 10),
                    AnnonceId = 1,
                    Montant = 20.15,
                    EtatTransaction = 0

                }); 



            this.SaveChanges();
        }
    }
}
