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
        public DbSet<AnnonceBesoin> AnnonceBesoin { get; set; }
        public DbSet<AnnonceService> AnnonceService { get; set; }
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
            /*this.CompteConsumer.AddRange(
                new CompteConsumer
                {
                    Id = 1,
                    Pseudo = "Toto",
                    MotDePasse = "lolilol"
                },
                new CompteConsumer
                {
                    Id = 2,
                    Pseudo = "Tata",
                    MotDePasse = "Kamoulox"
                }
            );*/
            this.SaveChanges();
        }
    }
}
