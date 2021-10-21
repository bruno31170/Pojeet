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

            optionsBuilder.UseMySql("server=localhost;user id=root;password=root;port=8889;database=Projet2");

        }

        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.CompteConsumer.AddRange(
                new CompteConsumer
                {
                    Id = 1,
                    Pseudo = "Toto",
                    MotDePasse = Dal.EncodeMD5("tototo"),
                    ProfilId = 1,
                }
            );
            this.Profil.AddRange(
                new Profil
                {
                    Id = 1,
                    Nom = "durand",
                    Prenom = "Pierre",
                    DateDeNaissance = "01/01/2000",
                    Adresse = "Rue Charles de Gaulle",
                    Ville = "Paris",
                    CodePostal = "75001",
                    Pays = 0,
                    Mail = "test@gmail.com",
                    NumeroTelephone = 0123875433,
                    Description = "description",
                });
            this.SaveChanges();
        }
    }
}
