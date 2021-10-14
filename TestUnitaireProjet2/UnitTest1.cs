using Pojeet.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestUnitaireProjet2
{
    public class UnitTest1
    {
        [Fact]
        public void Creation_Consumer_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la cr�ons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et cr�ons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous cr�ons un Consumer
                ctx.CreerConsumer("1234", "Yolo");

                // Nous v�rifions que le Consumer a bien �t� cr��
                List<CompteConsumer> consumer = ctx.ObtientTousConsumer();
                Assert.NotNull(consumer);
                Assert.Single(consumer);
                Assert.Equal("1234", consumer[0].MotDePasse);
                Assert.Equal("Yolo", consumer[0].Pseudo);
            }
        }

        [Fact]
        public void Modifier_Consumer_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la cr�ons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et cr�ons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous cr�ons un Consumer
                int id = ctx.CreerConsumer("1234", "Yolo");

                // Nous modifions le Consumer gr�ce � notre nouvelle fonction
                ctx.ModifierConsumer(id, "99999", "Thomas");

                // nous v�rifions que le Consumer a bien �t� modifi�
                List<CompteConsumer> consumer = ctx.ObtientTousConsumer();
                Assert.NotNull(consumer);
                Assert.Single(consumer);
                Assert.Equal("99999", consumer[0].MotDePasse);
                Assert.Equal("Thomas", consumer[0].Pseudo);
            }
        }

        [Fact]
        public void Suppression_Consumer_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la cr�ons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et cr�ons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous cr�ons un Consumer
                int id = ctx.CreerConsumer("1234", "Yolo");

                // Nous modifions le Consumer gr�ce � notre nouvelle fonction
                ctx.SuppressionConsumer(id);

                // nous v�rifions que le Consumer a bien �t� modifi�
                List<CompteConsumer> consumer = ctx.ObtientTousConsumer();
                Assert.NotNull(consumer);
                Assert.Empty(consumer);
            }
        }
    }
}
