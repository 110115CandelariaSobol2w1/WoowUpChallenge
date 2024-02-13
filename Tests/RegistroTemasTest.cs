using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoowUpChallenge.Models;

namespace Tests
{
    [TestClass]
    public class RegistroTemasTest
    {
        [TestMethod]
        public void RegistrarTema_should_register_new_topic()
        {
            // Arrange
            string tema = "Salud";

            // Act
            RegistroTemas nuevoTema = new RegistroTemas();
            nuevoTema.RegistrarTemas(tema);

            // Assert
            CollectionAssert.Contains(nuevoTema.ObtenerTemasRegistrados(), tema);

        }

        [TestMethod]
        public void RegistrarTema_should_not_register_duplicate_topic()
        {
            // Arrange
            string tema = "TemaExistente";

            // Act
            RegistroTemas nuevoTema = new RegistroTemas();
            nuevoTema.RegistrarTemas(tema);
            nuevoTema.RegistrarTemas(tema);

            // Assert
            Assert.AreEqual(1, nuevoTema.ObtenerTemasRegistrados().Count(t => t == tema));

        }
    }
}
