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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=Projet2");
        }
        public void InitializeDb()
        {
            //this.Database.EnsureDeleted();
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
