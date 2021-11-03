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
        public DbSet<Aide> Aide { get; set; }
        public DbSet<MessagerieConversation> MessagerieConversation { get; set; }
        public DbSet<Virement> Virement { get; set; }
        public DbSet<NotificationTransaction> Notification { get; set; }
        public DbSet<NotificationMessagerie> NotificationMessagerie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            //optionsBuilder.UseMySql("server=localhost;user id=root;password=root;port=8889;database=Projet2");

            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=Projet2");
            //optionsBuilder.UseMySql("server=localhost;user id=root;password=123456789;database=Projet2");


        }

        public void InitializeDb()
        {

            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();


            //CONSUMER
            this.CompteConsumer.AddRange(
            new CompteConsumer
            {
                Id = 1,
                Pseudo = "Consumer",
                MotDePasse = Dal.EncodeMD5("consumerConsumer"),
                ProfilId = 1,
                DateCreationCompte = new DateTime(2021, 07, 04, 12, 1, 10)

            },
             new CompteConsumer
             {
                 Id = 2,
                 Pseudo = "tata",
                 MotDePasse = Dal.EncodeMD5("tatata"),
                 ProfilId = 2,
                 DateCreationCompte = new DateTime(2021, 09, 28, 12, 1, 10)
             },
             new CompteConsumer
             {
                 Id = 3,
                 Pseudo = "Evgeniia",
                 MotDePasse = Dal.EncodeMD5("123456"),
                 ProfilId = 3,
                 DateCreationCompte = new DateTime(2021, 10, 15, 12, 1, 10)
             },
             new CompteConsumer
             {
                 Id = 4,
                 Pseudo = "Bruno",
                 MotDePasse = Dal.EncodeMD5("123456"),
                 ProfilId = 4,
                 DateCreationCompte = new DateTime(2021, 10, 28, 12, 1, 10)
             },
             new CompteConsumer
             {
                 Id = 5,
                 Pseudo = "BricoloDuDimanche",
                 MotDePasse = Dal.EncodeMD5("bricolo"),
                 ProfilId = 5,
                 DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
             },
             new CompteConsumer
             {
                 Id = 6,
                 Pseudo = "CocoLaBricole",
                 MotDePasse = Dal.EncodeMD5("cococo"),
                 ProfilId = 6,
                 DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
             },
             new CompteConsumer
             {
                 Id = 7,
                 Pseudo = "EricDu11",
                 MotDePasse = Dal.EncodeMD5("eric11"),
                 ProfilId = 7,
                 DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
             },
              new CompteConsumer
              {
                  Id = 8,
                  Pseudo = "TomTom",
                  MotDePasse = Dal.EncodeMD5("tomtom"),
                  ProfilId = 8,
                  DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
              },
               new CompteConsumer
               {
                   Id = 9,
                   Pseudo = "MaeMae",
                   MotDePasse = Dal.EncodeMD5("maemae"),
                   ProfilId = 9,
                   DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
               },
                new CompteConsumer
                {
                    Id = 10,
                    Pseudo = "Paulo",
                    MotDePasse = Dal.EncodeMD5("paulopaulo"),
                    ProfilId = 10,
                    DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
                },
                new CompteConsumer
                {
                    Id = 11,
                    Pseudo = "stephbreton",
                    MotDePasse = Dal.EncodeMD5("stephbreton"),
                    ProfilId = 11,
                    DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
                },
                 new CompteConsumer
                 {
                     Id = 12,
                     Pseudo = "sylvie",
                     MotDePasse = Dal.EncodeMD5("sylvie"),
                     ProfilId = 12,
                     DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
                 },
                 new CompteConsumer
                 {
                     Id = 13,
                     Pseudo = "Super-Bricolo",
                     MotDePasse = Dal.EncodeMD5("000000"),
                     ProfilId = 13,
                     DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10)
                 }
            );


            //GESTIONNAIRE 
            this.GestionnairePlateforme.AddRange(
                new GestionnairePlateforme
                {
                    Id = 1,
                    Nom = "Bruno",
                    Prenom = "Boulet",
                    Pseudo = "Bruno",
                    MotDePasse = Dal.EncodeMD5("123456")
                });

           

            //PROFIL
            this.Profil.AddRange(
            new Profil
            {
                Id = 1,
                Description = "Besoin d'aide pour entrenir ma voiture",
                Nom = "CONSUMER",
                Prenom = "consumer",
                DateDeNaissance = "05/03/1993",
                Adresse = "Boulevard Rocheplatte",
                Ville = "Orléans",
                CodePostal = "45000",
                Pays = 0,
                Mail = "consumerConsumer@gmail.com",
                NumeroTelephone = 687555634,
                Photo = "Eric.png",
                NoteMoyenne = 2
            },
            new Profil
            {
                Id = 2,
                Description = "Lorum ipsum",
                Nom = "Le Pillouer",
                Prenom = "Cécile",
                DateDeNaissance = "12/12/1990",
                Adresse = "Boulevard Rocheplatte",
                Ville = "Paris",
                CodePostal = "45000",
                Pays = 0,
                Mail = "cecileLepillouer@gmail.com",
                NumeroTelephone = 687555652,
                Photo = "Sylvie.png",
                NoteMoyenne = 4
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
                NoteMoyenne = 3,
                Photo = "avatar-femme.jpg"
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
                Photo = "Avatar-Bruno.jpg"

            },
             new Profil
             {
                 Id = 5,
                 Description = "Passioné par le bricolage et l'automobile. Recemment retraité j'ai du temps pour vous aider dans vos réparation !",
                 Nom = "Danner",
                 Prenom = "Jean-Paul",
                 DateDeNaissance = "12/09/1949",
                 Adresse = "51 Rue Frédéric Chopin",
                 Ville = "Vesoul",
                 CodePostal = "70000",
                 Pays = 0,
                 Mail = "jpBricolo@orange.fr",
                 NumeroTelephone = 625744022,
                 Photo = "jeanpaul.png"
             },
              new Profil
              {
                  Id = 6,
                  Description = "Garagiste de profession, vous pouvez avoir confiance en moi !",
                  Nom = "Dumas",
                  Prenom = "Corinne",
                  DateDeNaissance = "12/12/1969",
                  Adresse = "93 Place du Jeu de Paume",
                  Ville = "VILLEFRANCHE-SUR-SAÔNE",
                  CodePostal = "69400",
                  Pays = 0,
                  Mail = "coco@gmail.fr",
                  NumeroTelephone = 625767431,
                  Photo = "Corinne.png"
              },
              new Profil
              {
                  Id = 7,
                  Description = "",
                  Nom = "Lessard",
                  Prenom = "Eric",
                  DateDeNaissance = "12/01/1982",
                  Adresse = "54 Rue Marie De Médicis",
                  Ville = "Carcassonne",
                  CodePostal = "11000",
                  Pays = 0,
                  Mail = "erci.lessard@yahoo.fr",
                  NumeroTelephone = 625766598,
                  Photo = "Eric.png"
              },
               new Profil
               {
                   Id = 8,
                   Description = "Recemment diplômé d'un CAP mécanique je suis à votre disposition pour tout type de service",
                   Nom = "Ouellet",
                   Prenom = "Thomas",
                   DateDeNaissance = "12/01/1995",
                   Adresse = "42 Place Charles de Gaulle",
                   Ville = "VILLENAVE-D'ORNON",
                   CodePostal = "33140",
                   Pays = 0,
                   Mail = "thomas.mecanic@yahoo.fr",
                   NumeroTelephone = 625766565,
                   Photo = "Thomas.png"
               },
                new Profil
                {
                    Id = 9,
                    Description = "",
                    Nom = "Dufresnes",
                    Prenom = "Maëlys",
                    DateDeNaissance = "12/01/1999",
                    Adresse = "	65 rue Beauvau",
                    Ville = "Marseille",
                    CodePostal = "13002",
                    Pays = 0,
                    Mail = "maemae13@yahoo.fr",
                    NumeroTelephone = 625766576,
                    Photo = "Maëlys.png"
                },
                new Profil
                {
                    Id = 10,
                    Description = "",
                    Nom = "Martin",
                    Prenom = "Paul",
                    DateDeNaissance = "12/01/1990",
                    Adresse = "19 rue de la Hulotais",
                    Ville = "Saint-Quentin",
                    CodePostal = "02100",
                    Pays = 0,
                    Mail = "paulo@yahoo.fr",
                    NumeroTelephone = 625766554,
                    Photo = "Paul.png"
                },
                 new Profil
                 {
                     Id = 11,
                     Description = "",
                     Nom = "Breton",
                     Prenom = "Stéphanie",
                     DateDeNaissance = "12/01/1978",
                     Adresse = "66 rue des Coudriers",
                     Ville = "Muret",
                     CodePostal = "31600",
                     Pays = 0,
                     Mail = "bretonstephanie@yahoo.fr",
                     NumeroTelephone = 125766523,
                     Photo = "stephanie.png"
                 },
                 new Profil
                 {
                     Id = 12,
                     Description = "",
                     Nom = "Riquier",
                     Prenom = "Sylvie",
                     DateDeNaissance = "12/07/1974",
                     Adresse = "107 rue Goya",
                     Ville = "LE PERREUX-SUR-MARNE",
                     CodePostal = "94170",
                     Pays = 0,
                     Mail = "riquier@yahoo.fr",
                     NumeroTelephone = 125766523,
                     Photo = "Sylvie.png"
                 },
                 new Profil
                 {
                     Id = 13,
                     Description = "",
                     Nom = "Paul",
                     Prenom = "Dupont",
                     DateDeNaissance = "12/09/1994",
                     Adresse = "52 Av. Chandon",
                     Ville = "Gennevilliers",
                     CodePostal = "92230",
                     Pays = 0,
                     Mail = "PaulDupont@gmail.com",
                     NumeroTelephone = 665235408,
                     Photo = "avatar6.png"
                 }
                );

            //CompteHelper
            this.CompteProvider.AddRange(
                new CompteProvider
                {
                    Id = 1,
                    CompteConsumerId = 2,
                    DocumentIdentification = "cniTEst.png",
                    RibId = 1,
                    Etat = Etat.Valide,
                    Competence = "Moteur,Pneu",
                    DateCreationCompte = new DateTime(2021, 09, 23, 12, 1, 10),
                },
                new CompteProvider
                {
                    Id = 2,
                    CompteConsumerId = 5,
                    DocumentIdentification = "cniTEst.png",
                    RibId = 2,
                    Etat = Etat.Valide,
                    Competence = "Habitacle,Pneu",
                    DateCreationCompte = new DateTime(2021, 10, 15, 12, 1, 10),
                },
                 new CompteProvider
                 {
                     Id = 3,
                     CompteConsumerId = 7,
                     DocumentIdentification = "cniTEst.png",
                     RibId = 3,
                     Etat = Etat.DemandeEnCours,
                     Competence = "Moteur,Pneu, Nettoyage, Habitacle",
                     DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10),
                 },
                  new CompteProvider
                  {
                      Id = 4,
                      CompteConsumerId = 6,
                      DocumentIdentification = "cniTEst.png",
                      RibId = 4,
                      Etat = Etat.DemandeEnCours,
                      Competence = "Moteur,Pneu,Habitacle",
                      DateCreationCompte = new DateTime(2021, 10, 29, 12, 1, 10),
                  }
             );

            //RIB
            this.Rib.AddRange(
                new Rib
                {
                    Id = 1,
                    TitulaireCompte = "Le Pillouer",
                    Iban = "FR56789899878766567878998",
                    Bic = "VDHDBHBD66567",
                },
                 new Rib
                 {
                     Id = 2,
                     TitulaireCompte = "Durand",
                     Iban = "FR56789899878766567878998",
                     Bic = "VDHDBHBD66567",
                 },
                 new Rib
                 {
                     Id = 3,
                     TitulaireCompte = "Dumas",
                     Iban = "FR567898998787665678878789",
                     Bic = "VDHDBHHHG6567",
                 },
                  new Rib
                  {
                      Id = 4,
                      TitulaireCompte = "Lessard",
                      Iban = "FR56789899878766567888745",
                      Bic = "GHYFHVHHG6567",
                  }
                );



            //ANNONCE
            this.Annonce.AddRange(
            new Annonce
            {
                Id = 1,
                TypeDeAnnonce = TypeAnnonce.Service,
                TitreAnnonce = "Entretien et nettoyage de voiture",
                Description = "Propose le nettoyage interieur / extérieur de votre véhicule, le diagnostic,la réparation mécanique et l'entretien général (sauf carrosserie) tte marque automobile,. Possibilité de déplacement à  domicile.. à  partir de 25eur/heure..",
                DateParution = new DateTime(2021, 05, 01, 12, 1, 10),
                Localisation = "31000",
                DateButoir = DateTime.Today,
                Prix = 25,
                CategorieDeAnnonce = CategorieAnnonce.Location,
                ProfilId = 7,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "batterie.jpg"

            },

            new Annonce
            {
                Id = 2,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Louer une remorque",
                Description = "Je cherche à louer une remorque pour évacuer des déchets végétaux, très peu de kms entre la maison et la déchetterie. Location du 29 au 30 november. Remerciements.",
                DateParution = new DateTime(2021, 11, 01, 12, 1, 10),
                Localisation = "32000",
                DateButoir = DateTime.Today,
                Prix = 45,
                CategorieDeAnnonce = CategorieAnnonce.Location,
                ProfilId = 13,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "location-remorque.jpg"
            },

            new Annonce
            {
                Id = 3,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Achète 4 pneu de 4x4",
                Description = "Pneu en très bonne état",
                DateParution = new DateTime(2021, 02, 20, 12, 1, 10),
                Localisation = "33000",
                DateButoir = DateTime.Today,
                Prix = 100,
                CategorieDeAnnonce = CategorieAnnonce.Pièce,
                ProfilId = 3,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "visseuse.jpg"
            },
            new Annonce
            {
                Id = 4,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Recherche un mécanicien",
                Description = "Bonjour, Je cherche une personne qui puisse changer le démarreur de ma 308 année 2009. J'ai déjà acheté la pièce il faut seulement surélever la voiture, retirer l'ancien démarreur et mettre le nouveau. C'est assez urgent",
                DateParution = new DateTime(2021, 07, 20, 12, 1, 10),
                Localisation = "13000",
                DateButoir = DateTime.Today,
                Prix = 50,
                CategorieDeAnnonce = CategorieAnnonce.Réparation,
                ProfilId = 6,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "radiateur.jpg"


            },
            new Annonce
            {
                Id = 5,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Recherche krik",
                Description = "Un krik simple pour changer ma roue",
                DateParution = new DateTime(2021, 09, 20, 12, 1, 10),
                Localisation = "13000",
                DateButoir = DateTime.Today,
                Prix = 10,
                CategorieDeAnnonce = CategorieAnnonce.Location,
                ProfilId = 13,

                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "krik.jpg"


            },
             new Annonce
             {
                 Id = 6,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Service reparation",
                 Description = "Bonjour je propose mes services en qualité de mécanicien, pour tout ce qui est vidange, remplacement de plaquettes de freins, remplacement de courroies etc... n'hésitez pas à me contacter",
                 DateParution = new DateTime(2021, 08, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 25,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 3,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "essuisGlace.jpg"

             },
             new Annonce
             {
                 Id = 7,
                 TypeDeAnnonce = TypeAnnonce.Besoin,
                 TitreAnnonce = "Location de roue de secours",
                 Description = "Pour voiture commune",
                 DateParution = new DateTime(2021, 07, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 20,
                 CategorieDeAnnonce = CategorieAnnonce.Location,
                 ProfilId = 1,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "roueSecour.jpg"

             },
             new Annonce
             {
                 Id = 8,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Vend pare-brise Fiat picasso",
                 Description = "Pare brise neuf",
                 DateParution = new DateTime(2021, 04, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 40,
                 CategorieDeAnnonce = CategorieAnnonce.Pièce,
                 ProfilId = 4,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "parebrise.jpg"

             },
             new Annonce
             {
                 Id = 9,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Réparation/changement de pot d'echappement",
                 Description = "Tout type de véhicule",
                 DateParution = new DateTime(2021, 01, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 20,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,

                 ProfilId = 5,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "pot.jpg"

             },
             new Annonce
             {
                 Id = 10,
                 TypeDeAnnonce = TypeAnnonce.Besoin,
                 TitreAnnonce = "Loue test anti-pollution",
                 Description = "Pour éviter les mauvaises surprise lors du contrôle technique",
                 DateParution = new DateTime(2021, 04, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 20,
                 CategorieDeAnnonce = CategorieAnnonce.Location,
                 ProfilId = 1,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "test.jpg"

             },
             new Annonce
             {
                 Id = 11,
                 TypeDeAnnonce = TypeAnnonce.Besoin,
                 TitreAnnonce = "Changement poignée porte",
                 Description = "Voiture modèle Clio 3",
                 DateParution = new DateTime(2021, 08, 20, 12, 1, 10),
                 Localisation = "31000",
                 DateButoir = DateTime.Today,
                 Prix = 30,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 13,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "poignee.jpg"

             },
            new Annonce
            {
                Id = 12,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Recherche croix démonte pneu",
                Description = "Pour une camionette",
                DateParution = new DateTime(2021, 06, 20, 12, 1, 10),
                Localisation = "32000",
                DateButoir = DateTime.Today,
                Prix = 10,
                CategorieDeAnnonce = CategorieAnnonce.Location,
                ProfilId = 8,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "croix.jpg"

            },
            new Annonce
            {
                Id = 13,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Achète Auto radio",
                Description = "Etat : Fonctionnel",
                DateParution = new DateTime(2021, 04, 20, 12, 1, 10),
                Localisation = "33000",
                DateButoir = DateTime.Today,
                Prix = 100,
                CategorieDeAnnonce = CategorieAnnonce.Pièce,
                ProfilId = 3,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "autoradio.jpg"
            },
            new Annonce
            {
                Id = 14,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Changement ceinture conducteur",
                Description = "Elle a était abimée au fil des ans",
                DateParution = new DateTime(2021, 02, 20, 12, 1, 10),
                Localisation = "13000",
                DateButoir = DateTime.Today,
                Prix = 50,
                CategorieDeAnnonce = CategorieAnnonce.Réparation,
                ProfilId = 10,

                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "ceinture.jpg"

            },
            new Annonce
            {
                Id = 15,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Recherche boule de remorque",
                Description = "Pour transporter une caravane",
                DateParution = new DateTime(2021, 08, 20, 12, 1, 10),
                Localisation = "13000",
                DateButoir = DateTime.Today,
                Prix = 20,
                CategorieDeAnnonce = CategorieAnnonce.Location,
                ProfilId = 4,

                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "boule.png"

            },
             new Annonce
             {
                 Id = 16,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Propose vidange",
                 Description = "Tout type de véhicule",
                 DateParution = new DateTime(2021, 10, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 30,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 5,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "vidange.jpg"

             },
             new Annonce
             {
                 Id = 17,
                 TypeDeAnnonce = TypeAnnonce.Besoin,
                 TitreAnnonce = "Location de voiture",
                 Description = "Pas plus de 2 jours",
                 DateParution = new DateTime(2021, 09, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 100,
                 CategorieDeAnnonce = CategorieAnnonce.Location,
                 ProfilId = 1,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "location.jpg"

             },
             new Annonce
             {
                 Id = 18,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Vend capo Fiat panda",
                 Description = "Capo neuf",
                 DateParution = new DateTime(2021, 08, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 40,
                 CategorieDeAnnonce = CategorieAnnonce.Pièce,
                 ProfilId = 4,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "capotfiatpanda.jpg"


             },
             new Annonce
             {
                 Id = 19,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Réparation/changement pare-brise arriere",
                 Description = "Tout type de véhicule",
                 DateParution = new DateTime(2021, 01, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 35,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 3,

                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "changementParebriseArriere.jpg"

             },
             new Annonce
             {
                 Id = 20,
                 TypeDeAnnonce = TypeAnnonce.Besoin,
                 TitreAnnonce = "Loue desosseur de voiture",
                 Description = "Pour démonter une voiture",
                 DateParution = new DateTime(2021, 02, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 20,
                 CategorieDeAnnonce = CategorieAnnonce.Location,
                 ProfilId = 1,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "pince.jpg"


             },
             new Annonce
             {
                 Id = 21,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Changement du volant",
                 Description = "Voiture modèle Renault espace",
                 DateParution = new DateTime(2021, 03, 20, 12, 1, 10),
                 Localisation = "31000",
                 DateButoir = DateTime.Today,
                 Prix = 30,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 2,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "volant.jpg"

             },

            new Annonce
            {
                Id = 22,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Recherche fauteuil arrière",
                Description = "Modèle clio 4",
                DateParution = new DateTime(2021, 04, 20, 12, 1, 10),
                Localisation = "32000",
                DateButoir = DateTime.Today,
                Prix = 10,
                CategorieDeAnnonce = CategorieAnnonce.Location,
                ProfilId = 11,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "siege.jpg"

            },

            new Annonce
            {
                Id = 23,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Achète une roue de camionette",
                Description = "Pneu en très bonne état",
                DateParution = new DateTime(2021, 05, 20, 12, 1, 10),
                Localisation = "33000",
                DateButoir = DateTime.Today,
                Prix = 100,
                CategorieDeAnnonce = CategorieAnnonce.Pièce,
                ProfilId = 11,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "roueCamionette.jpg"
            },
            new Annonce
            {
                Id = 24,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Changement reservoir lave glace",
                Description = "Modèle renault 5",
                DateParution = new DateTime(2021, 06, 20, 12, 1, 10),
                Localisation = "13000",
                DateButoir = DateTime.Today,
                Prix = 50,
                CategorieDeAnnonce = CategorieAnnonce.Réparation,
                ProfilId = 10,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "laveglace.jpg"


            },
            new Annonce
            {
                Id = 25,
                TypeDeAnnonce = TypeAnnonce.Besoin,
                TitreAnnonce = "Recherche polisseuse de carrosserie",
                Description = "Pour une jolie voiture",
                DateParution = new DateTime(2021, 07, 20, 12, 1, 10),
                Localisation = "13000",
                DateButoir = DateTime.Today,
                Prix = 10,
                CategorieDeAnnonce = CategorieAnnonce.Location,
                ProfilId = 5,
                EtatAnnonce = EtatAnnonce.Validé,
                Photo = "polisseuse.jpg"


            },


             new Annonce
             {
                 Id = 26,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Propose réparation carroserie enfoncé",
                 Description = "Seulement pour des voiture",
                 DateParution = new DateTime(2021, 08, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 60,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 7,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "enfonce.jpeg"


             },
             new Annonce
             {
                 Id = 27,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Location de remorque",
                 Description = "Taille standard",
                 DateParution = new DateTime(2021, 09, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 50,
                 CategorieDeAnnonce = CategorieAnnonce.Location,
                 ProfilId = 6,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "remorque.jpg"


             },
             new Annonce
             {
                 Id = 28,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Vend épave de voiture",
                 Description = "Modele inconnu",
                 DateParution = new DateTime(2021, 10, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 300,
                 CategorieDeAnnonce = CategorieAnnonce.Pièce,
                 ProfilId = 4,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "epave.jpg"


             },
             new Annonce
             {
                 Id = 29,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Réparation/changement de bougie d'allumage",
                 Description = "Tout type de véhicule",
                 DateParution = new DateTime(2021, 04, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 35,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 7,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "bougie.jpg"


             },
             new Annonce
             {
                 Id = 30,
                 TypeDeAnnonce = TypeAnnonce.Service,
                 TitreAnnonce = "Réparation pédale conducteur",
                 Description = "Pour tout type de voiture",
                 DateParution = new DateTime(2021, 06, 20, 12, 1, 10),
                 Localisation = "13000",
                 DateButoir = DateTime.Today,
                 Prix = 20,
                 CategorieDeAnnonce = CategorieAnnonce.Réparation,
                 ProfilId = 12,
                 EtatAnnonce = EtatAnnonce.Validé,
                 Photo = "pedale.jpg"


             });


            //CONSUMER
            /*  this.CompteConsumer.AddRange(
              new CompteConsumer
              {
                  Id = 1,
                  Pseudo = "Toto",
                  MotDePasse = Dal.EncodeMD5("lolilol"),
                  ProfilId = 1,
                  DateCreationCompte = new DateTime(2021, 10, 04, 12, 1, 10)

              },
               new CompteConsumer
               {
                   Id = 2,
                   Pseudo = "tata",
                   MotDePasse = Dal.EncodeMD5("tatata"),
                   ProfilId = 2,
                   DateCreationCompte = new DateTime(2021, 10, 28, 12, 1, 10)
               },
               new CompteConsumer
               {
                   Id = 3,
                   Pseudo = "Evgeniia",
                   MotDePasse = Dal.EncodeMD5("123456"),
                   ProfilId = 3,
                   DateCreationCompte = new DateTime(2021, 10, 15, 12, 1, 10)
               },
               new CompteConsumer
               {
                   Id = 4,
                   Pseudo = "Bruno",
                   MotDePasse = Dal.EncodeMD5("123456"),
                   ProfilId = 4,
                   DateCreationCompte = new DateTime(2021, 10, 28, 12, 1, 10)
               }
              );*/


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
            },
            new Message
            {
                Id = 5,
                Date = new DateTime(2021, 10, 03, 12, 1, 10),
                message = " Salut, Je suis interessé par votre annonce, pourriez vous me rendre le servie?",
                ProfilId = 1,
                ConversationId = 2
            },
            new Message
            {
                Id = 6,
                Date = new DateTime(2021, 10, 04, 12, 1, 10),
                message = " Salut, Oui bien sur, à 60 euros ça marche? ",
                ProfilId = 6,
                ConversationId = 2
            },
            new Message
            {
                Id = 7,
                Date = new DateTime(2021, 10, 05, 12, 1, 10),
                message = " Super, ça marche merci!",
                ProfilId = 1,
                ConversationId = 2
            },
             new Message
             {
                 Id = 8,
                 Date = new DateTime(2021, 11, 05, 12, 1, 10),
                 message = " Salut, Je peux vous rendre le service si vous voulez :)!",
                 ProfilId = 5,
                 ConversationId = 3
             },
             new Message
             {
                Id = 9,
                 Date = new DateTime(2021, 11, 05, 12, 1, 10),
                 message = " Ok vous êtes au entourages?",
                 ProfilId = 1,
                 ConversationId = 3
             });



            //CONVERSATION
            this.Conversation.AddRange(
            new Conversation
            {
                Id = 1,
                CompteConsumerId = 1,
                AnnonceId = 21,

            },
             new Conversation
             {
                 Id = 2,
                 CompteConsumerId = 1,
                 AnnonceId = 27,

             },
             new Conversation
             {
                 Id = 3,
                 CompteConsumerId = 5,
                 AnnonceId = 17,

             });
            //NotificationmESSAGERIE
            this.NotificationMessagerie.AddRange(
            new NotificationMessagerie
            {
                Id = 1,
                ConversationId = 1,
                ProfilId = 1,
                MessagesNonLus = 0,
            },
            new NotificationMessagerie
            {
                Id = 2,
                ConversationId = 1,
                ProfilId = 2,
                MessagesNonLus = 0,
            },
             new NotificationMessagerie
             {
                 Id = 3,
                 ConversationId = 2,
                 ProfilId = 1,
                 MessagesNonLus = 0,
             },
            new NotificationMessagerie
            {
                Id = 4,
                ConversationId = 2,
                ProfilId = 6,
                MessagesNonLus = 0,
            },
            new NotificationMessagerie
            {
                Id = 5,
                ConversationId = 3,
                ProfilId = 5,
                MessagesNonLus = 0,
            },
            new NotificationMessagerie
            {
                Id = 6,
                ConversationId = 3,
                ProfilId = 1,
                MessagesNonLus = 0,
            });


            this.Messagerie.AddRange(
            new Messagerie
            {
                Id = 1,
                ProfilId = 1
            },
            new Messagerie
            {
                Id = 2,
                ProfilId = 2
            },
            new Messagerie
            {
                Id = 3,
                ProfilId = 3
            },
             new Messagerie
             {
                 Id = 4,
                 ProfilId = 4
             },
              new Messagerie
              {
                  Id = 5,
                  ProfilId = 5
              },
             new Messagerie
             {
                 Id = 6,
                 ProfilId = 6
             });

            this.MessagerieConversation.AddRange(
            new MessagerieConversation
            {
                Id = 1,
                MessagerieId = 1,
                ConversationId = 1,
            },
            new MessagerieConversation
            {
                Id = 2,
                MessagerieId = 2,
                ConversationId = 1,
            },
            new MessagerieConversation
            {
                Id = 3,
                MessagerieId = 1,
                ConversationId = 2,
            },
            new MessagerieConversation
            {
                Id = 4,
                MessagerieId = 6,
                ConversationId = 2,
            },
            new MessagerieConversation
            {
                Id = 5,
                MessagerieId = 5,
                ConversationId = 3,
            },
            new MessagerieConversation
            {
                Id = 6,
                MessagerieId = 1,
                ConversationId = 3,
            }
           );

            //AIDE
            this.Aide.AddRange(
                new Aide
                {
                    Id = 1,
                    Date = new DateTime(2021, 10, 20, 12, 1, 10),
                    Nom = "Bruno",
                    Mail = "bruno.gmail",
                    Objet = "Litige avec un Helper",
                    Message = "Un helper est venue pour un service mais en reparant ma batterie, il m'a cassé un phare",
                    ProfilId = 1,
                    StatutAide = StatutAide.NonEnvoye
                },
                 new Aide
                 {
                     Id = 2,
                     Date = new DateTime(2021, 10, 11, 12, 1, 10),
                     Nom = "Stéphanie Breton",
                     Mail = "bretonstephanie@yahoo.fr",
                     Objet = "Devenir un Helper",
                     Message = "Bonjour. Quels documents dois-je vous envoyer pour que je puisse publier des annonces",
                     ProfilId = 11,
                     StatutAide = StatutAide.NonEnvoye
                 },
                 new Aide
                 {
                     Id = 3,
                     Date = new DateTime(2021, 09, 01, 12, 1, 10),
                     Nom = "Lessard Eric",
                     Mail = "erci.lessard@yahoo.fr",
                     Objet = "Paiement",
                     Message = "J'ai effectué un service pour Ines Guissouma le 2 novembre 2021 mais je ne vois pas encore le paiement. Merci d'avance",
                     ProfilId = 7,
                     StatutAide = StatutAide.Envoye
                 },
                 new Aide
                 {
                     Id = 4,
                     Date = new DateTime(2021, 10, 05, 12, 1, 10),
                     Nom = "Corinne Dumas",
                     Mail = "coco@gmail.fr",
                     Objet = "Mauvais service",
                     Message = "Bonjour. Je ne suis pas satisfaite du service que Thomas m'a fourni. Il n'est pas venu à l'heure prévue. Je veux que vous fassiez le remboursement. Merci",
                     ProfilId = 6,
                     StatutAide = StatutAide.NonEnvoye
                 },
                 new Aide
                 {
                     Id = 5,
                     Date = new DateTime(2021, 09, 29, 12, 1, 10),
                     Nom = "Sylvie Riquier",
                     Mail = "riquier@yahoo.fr",
                     Objet = "Paiment",
                     Message = "Bonjour. Puis-je payer par chèque pour le service rendu. Merci",
                     ProfilId = 12,
                     StatutAide = StatutAide.NonEnvoye
                 });



            //TRANSACTION

            this.Transactions.AddRange(
                new Transaction
                {
                    Reference = 123,
                    Date = new DateTime(2021, 01, 20, 12, 1, 10),
                    AnnonceId = 4,
                    Montant = 100,
                    MontantHelper = 95,
                    EtatTransaction = EtatTransaction.Valide,
                    ProfilId = 2

                },
            new Transaction
            {
                Reference = 125,
                Date = new DateTime(2021, 02, 27, 12, 1, 10),
                AnnonceId = 1,
                Montant = 50,
                MontantHelper = 47.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 4

            },
            new Transaction
            {
                Reference = 127,
                Date = new DateTime(2021, 03, 27, 01, 1, 10),
                AnnonceId = 3,
                Montant = 10.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 7
            },
            new Transaction
            {
                Reference = 128,
                Date = new DateTime(2021, 04, 09, 12, 1, 10),
                AnnonceId = 22,
                Montant = 40.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 6
            },
            new Transaction
            {
                Reference = 129,

                Date = new DateTime(2021, 10, 10, 12, 1, 10),

                AnnonceId = 19,
                Montant = 39.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 9
            },
            new Transaction
            {
                Reference = 130,
                Date = new DateTime(2021, 06, 10, 12, 1, 10),
                AnnonceId = 23,
                Montant = 155,
                EtatTransaction = EtatTransaction.En_attente,
                ProfilId = 5

            },
            new Transaction
            {
                Reference = 54,
                Date = new DateTime(2021, 07, 20, 12, 1, 10),
                AnnonceId = 18,
                Montant = 100.15,
                EtatTransaction = EtatTransaction.Valide,
                ProfilId = 3

            },
            new Transaction
            {
                Reference = 57,
                Date = new DateTime(2021, 08, 27, 12, 1, 10),
                AnnonceId = 15,
                Montant = 40.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 10

            },
            new Transaction
            {
                Reference = 58,
                Date = new DateTime(2021, 09, 27, 01, 1, 10),
                AnnonceId = 3,
                Montant = 200.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 11
            },
            new Transaction
            {
                Reference = 75,
                Date = new DateTime(2021, 10, 09, 12, 1, 10),
                AnnonceId = 20,
                Montant = 40.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 6
            },
            new Transaction
            {
                Reference = 74,
                Date = new DateTime(2021, 09, 10, 12, 1, 10),
                AnnonceId = 6,
                Montant = 39.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 7
            },
            new Transaction
            {
                Reference = 72,
                Date = new DateTime(2021, 08, 02, 12, 1, 10),
                AnnonceId = 3,
                Montant = 150,
                EtatTransaction = EtatTransaction.En_attente,
                ProfilId = 5

            },
            new Transaction
            {
                Reference = 402,
                Date = new DateTime(2021, 01, 20, 12, 1, 10),
                AnnonceId = 4,
                Montant = 20.15,
                EtatTransaction = EtatTransaction.Valide,
                ProfilId = 3

            },
            new Transaction
            {
                Reference = 555,
                Date = new DateTime(2021, 02, 27, 12, 1, 10),
                AnnonceId = 1,
                Montant = 5.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 8

            },
            new Transaction
            {
                Reference = 80,
                Date = new DateTime(2021, 01, 27, 01, 1, 10),
                AnnonceId = 8,
                Montant = 10.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 5
            },
            new Transaction
            {
                Reference = 444,
                Date = new DateTime(2021, 01, 09, 12, 1, 10),
                AnnonceId = 5,
                Montant = 40.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 3
            },
            new Transaction
            {
                Reference = 111,
                Date = new DateTime(2021, 03, 10, 12, 1, 10),
                AnnonceId = 2,
                Montant = 39.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 4
            },
            new Transaction
            {
                Reference = 1130,
                Date = new DateTime(2021, 06, 10, 12, 1, 10),
                AnnonceId = 12,
                Montant = 155,
                EtatTransaction = EtatTransaction.En_attente,
                ProfilId = 12

            },
            new Transaction
            {
                Reference = 254,
                Date = new DateTime(2021, 07, 20, 12, 1, 10),
                AnnonceId = 4,
                Montant = 100.15,
                EtatTransaction = EtatTransaction.Valide,
                ProfilId = 11

            },
            new Transaction
            {
                Reference = 587,
                Date = new DateTime(2021, 07, 27, 12, 1, 10),
                AnnonceId = 1,
                Montant = 40.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 6

            },
            new Transaction
            {
                Reference = 745,
                Date = new DateTime(2021, 08, 09, 12, 1, 10),
                AnnonceId = 5,
                Montant = 24,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 11
            },
            new Transaction
            {
                Reference = 764,
                Date = new DateTime(2021, 01, 10, 12, 1, 10),
                AnnonceId = 11,
                Montant = 39.5,
                EtatTransaction = EtatTransaction.Termine,
                ProfilId = 10
            },
            new Transaction
            {
                Reference = 772,
                Date = new DateTime(2021, 01, 10, 12, 1, 10),
                AnnonceId = 21,
                Montant = 150,
                EtatTransaction = EtatTransaction.En_attente,
                ProfilId = 9

            },
             new Transaction
             {
                 Reference = 773,
                 Date = new DateTime(2021, 10, 30, 12, 1, 10),
                 AnnonceId = 21,
                 Montant = 50,
                 EtatTransaction = EtatTransaction.Termine,
                 ProfilId = 1

             },
             new Transaction
             {
                 Reference = 774,
                 Date = new DateTime(2021, 11, 10, 12, 1, 10),
                 AnnonceId = 27,
                 Montant = 70,
                 EtatTransaction = EtatTransaction.En_attente,
                 ProfilId = 1

             });

            /*this.Paiement.AddRange(
           new Paiement
           {
               Id = 1,
               Date = new DateTime(2004, 11, 20, 12, 1, 10),
               TransactionMontant = 15,
               TransactionReference = 130,
               ProfilId = 3,
               StatutPaiement = StatutPaiement.Payé

           });*/


            this.Avis.AddRange(
           new Avis
           {
               Id = 1,
               date = new DateTime(2004, 11, 20, 12, 1, 10),
               commentaire = "Cécile est un bon locataire d outillage, il nous a rendu le materiel en bon etat et dans le temps convenue. Il est tres sympathique, je vous le recommande.",
               note = 4,
               CompteConsumerId = 4,
               ProfilId = 2
           },
            new Avis
            {
                Id = 2,
                date = new DateTime(2004, 11, 20, 12, 1, 10),
                commentaire = "Super service!",
                note = 5,
                CompteConsumerId = 5,
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
            },
            new Avis
            {
                Id = 4,
                date = new DateTime(2021, 10, 20, 12, 1, 10),
                commentaire = "Bien",
                note = 4,
                CompteConsumerId = 3,
                ProfilId = 13
            },
            new Avis
            {
                Id = 5,
                date = new DateTime(2021, 09, 09, 12, 1, 10),
                commentaire = "Ponctuelle et agréable, je recommande.",
                note = 4,
                CompteConsumerId = 1,
                ProfilId = 13
            },
            new Avis
            {
                Id = 6,
                date = new DateTime(2021, 09, 01, 12, 1, 10),
                commentaire = "Personnes très sympathiques et de confiance ! Je recommande ++ ",
                note = 5,
                CompteConsumerId = 10,
                ProfilId = 13
            },
            new Avis
            {
                Id = 7,
                date = new DateTime(2021, 09, 01, 12, 1, 10),
                commentaire = "Echange très sympathique avec Consumer, aucun problème à signaler :)",
                note = 5,
                CompteConsumerId = 11,
                ProfilId = 13
            },
            new Avis
            {
                Id = 8,
                date = new DateTime(2021, 08, 11, 12, 1, 10),
                commentaire = "Bien",
                note = 3,
                CompteConsumerId = 11,
                ProfilId = 13
            },
            new Avis
            {
                Id = 9,
                date = new DateTime(2021, 10, 01, 12, 1, 10),
                commentaire = "J'ai rendu le service à Consumer et il a été très sympatique.",
                note = 5,
                CompteConsumerId = 2,
                ProfilId = 1
            },
            new Avis
            {
                Id = 10,
                date = new DateTime(2021, 10, 05, 12, 1, 10),
                commentaire = "Correct.",
                note = 3,
                CompteConsumerId = 6,
                ProfilId = 1
            },
            new Avis
            {
                Id = 11,
                date = new DateTime(2021, 11, 01, 12, 1, 10),
                commentaire = "Personne très sympathique et tout s'est bien passé",
                note = 5,
                CompteConsumerId = 5,
                ProfilId = 1
            });



            this.SaveChanges();
        }
    }
}
