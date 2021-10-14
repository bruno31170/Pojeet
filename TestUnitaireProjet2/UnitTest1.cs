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
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous créons un Consumer
                ctx.CreerConsumer("1234", "Yolo");

                // Nous vérifions que le Consumer a bien été créé
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
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous créons un Consumer
                int id = ctx.CreerConsumer("1234", "Yolo");

                // Nous modifions le Consumer grâce à notre nouvelle fonction
                ctx.ModifierConsumer(id, "99999", "Thomas");

                // nous vérifions que le Consumer a bien été modifié
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
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                ctx.DeleteCreateDatabase();
                // Nous créons un Consumer
                int id = ctx.CreerConsumer("1234", "Yolo");

                // Nous modifions le Consumer grâce à notre nouvelle fonction
                ctx.SuppressionConsumer(id);

                // nous vérifions que le Consumer a bien été modifié
                List<CompteConsumer> consumer = ctx.ObtientTousConsumer();
                Assert.NotNull(consumer);
                Assert.Empty(consumer);
            }
        }
    }
}
