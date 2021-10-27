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
           //optionsBuilder.UseMySql("server=localhost;user id=root;password=root;port=8889;database=Projet2");
            optionsBuilder.UseMySql("server=localhost;user id=root;password=123456789;database=Projet2");
        }


        public void InitializeDb()
        {

            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            //PROFIL
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
                Pays = 0,
                Mail = "inesguissouma@gmail.com",
                NumeroTelephone = 6875,
                Photo = "https://bootdey.com/img/Content/avatar/avatar3.png"
            },
            new Profil
            {
                Id = 2,
                Description = "Besoin",
                Nom = "Le Pillouer",
                Prenom = "Cécile",
                DateDeNaissance = "12/12/2020",
                Adresse = "Boulevard Rocheplatte",
                Ville = "Paris",
                CodePostal = "45000",
                Pays = 0,
                Mail = "CécileLepillouer@gmail.com",
                NumeroTelephone = 6257,
                Photo = "https://bootdey.com/img/Content/avatar/avatar5.png"
            },
            new Profil
            {
                Id = 3,
                Description = "",
                Nom = "Ikonnikova",
                Prenom = "Evgeniia",
                DateDeNaissance = "12/12/1985",
                Adresse = "3000 route de Greasque",
                Ville = "Gardanne",
                CodePostal = "13120",
                Pays = 0,
                Mail = "evgeniya@mail.ru",
                NumeroTelephone = 625785402,
                Photo = "https://bootdey.com/img/Content/avatar/avatar6.png"
            },
            new Profil
            {
                Id = 4,
                Description = "",
                Nom = "Boulet",
                Prenom = "Bruno",
                DateDeNaissance = "12/12/1995",
                Adresse = "30 Rue du Dr Charco",
                Ville = "Nanterre",
                CodePostal = "92000",
                Pays = 0,
                Mail = "bruno@gmail.com",
                NumeroTelephone = 62574402,
                Photo = "https://bootdey.com/img/Content/avatar/avatar4.png"
            });

            //ANNONCE
            this.Annonce.AddRange(
            new Annonce
            {
                Id = 1,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Changement batterie",
                Description = "voiture modèle Ford Fusion",
                DateParution = DateTime.Now,
                Localisation = "31000",
                DateButoir = DateTime.Today,
                Prix = 5,
                CategorieDeAnnonce = CategorieAnnonce.Carrosserie,
                ProfilId = 2,

            },

            new Annonce
            {
                Id = 2,
                TypeDeAnnonce = TypeAnnonce.Service,
                TitreAnnonce = "Changer pneu",
                Description = "Toute voiture",
                DateParution = DateTime.Now,
                Localisation = "32000",
                DateButoir = DateTime.Today,
                Prix = 50,
                CategorieDeAnnonce = CategorieAnnonce.Roue,
                ProfilId = 1,

            },

            new Annonce
            {
                Id = 3,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Changement essuie glace",
                Description = "voiture modèle Fiat Punto",
                DateParution = DateTime.Now,
                Localisation = "33000",
                DateButoir = DateTime.Today,
                Prix = 10,
                CategorieDeAnnonce = CategorieAnnonce.Carrosserie,
                ProfilId = 2,
            },
                new Annonce
                {
                    Id = 4,
                    TypeDeAnnonce = TypeAnnonce.Service,
                    TitreAnnonce = "Réparation voiture",
                    Description = "Je vous propose mes services pour l'entretien ( vidange avec filtres,...), passage à la valise sur tout type de voiture et changement de pièces automobile ( remplacement de pièces du train roulant, plaquettes,..), n'hésiter pas à me demander.",
                    DateParution = DateTime.Now,
                    Localisation = "13000",
                    DateButoir = DateTime.Today,
                    Prix = 50,
                    CategorieDeAnnonce = CategorieAnnonce.Roue,
                    ProfilId = 2,
                },
                new Annonce
                {
                    Id = 5,
                    TypeDeAnnonce = TypeAnnonce.Service,
                    TitreAnnonce = "Réparation voiture",
                    Description = "Je vous propose mes services pour l'entretien ( vidange avec filtres,...), passage à la valise sur tout type de voiture et changement de pièces automobile ( remplacement de pièces du train roulant, plaquettes,..), n'hésiter pas à me demander.",
                    DateParution = DateTime.Now,
                    Localisation = "92000",
                    DateButoir = DateTime.Today,
                    Prix = 40,
                    CategorieDeAnnonce = CategorieAnnonce.Roue,
                    ProfilId = 4,



                });

            //CONSUMER
            this.CompteConsumer.AddRange(
            new CompteConsumer
            {
                Id = 1,
                Pseudo = "Toto",
                MotDePasse = Dal.EncodeMD5("lolilol"),
                ProfilId = 1,
                statut = Models.CompteConsumer.Statut.Actif
            },
             new CompteConsumer
             {
                 Id = 2,
                 Pseudo = "tata",
                 MotDePasse = Dal.EncodeMD5("tatata"),
                 ProfilId = 2,
             },
             new CompteConsumer
             {
                 Id = 3,
                 Pseudo = "Evgeniia",
                 MotDePasse = Dal.EncodeMD5("123456"),
                 ProfilId = 3
             },
             new CompteConsumer
             {
                 Id = 4,
                 Pseudo = "Bruno",
                 MotDePasse = Dal.EncodeMD5("123456"),
                 ProfilId = 4
             }
            );

            //MESSAGE
            this.Message.AddRange(
            new Message
            {
                Id = 1,
                Date = new DateTime(2004, 11, 20, 12, 1, 10),
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

            },
            new Message
            {
                Id = 3,
                Date = new DateTime(2006, 11, 20, 12, 1, 10),
                message = " ok ",
                ProfilId = 1,
                ConversationId = 1
            },
            new Message
            {
                Id = 4,
                Date = new DateTime(2006, 11, 20, 12, 1, 10),
                message = " hey ",
                ProfilId = 2,
                ConversationId = 1
            });



            //CONVERSATION
            this.Conversation.AddRange(
            new Conversation
            {
                Id = 1,
                CompteConsumerId = 1,
                MessagerieId = 1,
                AnnonceId = 1

            });
            this.Messagerie.AddRange(
            new Messagerie
            {
                Id = 1,
                ProfilId = 2
            });




            //TRANSACTION

            this.Transactions.AddRange(
                new Transaction
                {
                    Reference = 123,
                    Date = new DateTime(2021, 11, 20, 12, 1, 10),
                    AnnonceId = 4,
                    Montant = 20.15,
                    EtatTransaction = EtatTransaction.Valide,
                    ProfilId = 3



                },
            new Transaction
            {
                Reference = 125,
                Date = new DateTime(2021, 11, 09, 12, 1, 10),
                AnnonceId = 4,
                Montant = 40.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 1
            },
            new Transaction
            {
                Reference = 127,
                Date = new DateTime(2021, 11, 09, 01, 1, 10),
                AnnonceId = 5,
                Montant = 20.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 1
            },
            new Transaction
            {
                Reference = 128,
                Date = new DateTime(2021, 08, 09, 12, 1, 10),
                AnnonceId = 5,
                Montant = 40.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 3
            },
            new Transaction
            {
                Reference = 129,
                Date = new DateTime(2021, 11, 10, 12, 1, 10),
                AnnonceId = 2,
                Montant = 39.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 4
            },
            new Transaction
            {
                Reference = 130,
                Date = new DateTime(2021, 11, 10, 12, 1, 10),
                AnnonceId = 3,
                Montant = 15,
                EtatTransaction = EtatTransaction.En_attente,
                ProfilId = 1

            });

            this.Avis.AddRange(
           new Avis
           {
               Id = 1,
               date = new DateTime(2004, 11, 20, 12, 1, 10),
               commentaire = "Cécile est un bon locataire d outillage, il nous a rendu le materiel en bon etat et dans le temps convenue. Il est tres sympathique, je vous le recommande.",
               note = 4,
               CompteConsumerId = 1,
               ProfilId = 2},
            new Avis
            {
                Id = 2,
                date = new DateTime(2004, 11, 20, 12, 1, 10),
                commentaire = "Super service!",
                note = 5,
                CompteConsumerId = 1,
                ProfilId = 2
            },
            new Avis
            {
                Id = 3,
                date = new DateTime(2004, 11, 20, 12, 1, 10),
                commentaire = "Bien",
                note = 4,
                CompteConsumerId = 3,
                ProfilId = 2
            });

            //RIB
            this.Rib.AddRange(
                new Rib
                {
                    Id = 1,
                    TitulaireCompte = "Le Pillouer",
                    Iban = "FR56789899878766567878998",
                    Bic = "VDHDBHBD66567",
                });

            //CompteHelper
            this.CompteProvider.AddRange(
                new CompteProvider
                {
                    Id = 1,
                    CompteConsumerId = 2,
                    DocumentIdentification = "jhehshkshefhskfhjksfd.pdf",
                    RibId = 1,
                    Etat = 0,
                });

            this.SaveChanges();
        }
    }
}
