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
    public class UserTest
    {
        [TestMethod]
        public void CreateUser_Should_Add_New_User_When_Not_Exists()
        {
            // Arrange
            string testName = "Candelaria Sobol";
            string testEmail = "candelariasobol@example.com";

            Usuario usuario = new Usuario();
            // Act
            usuario.CreateUser(testName, testEmail);

            // Assert
            Assert.IsTrue(Usuario.registeredUsers.Any(u => u.Nombre == testName && u.Email == testEmail));
        }

        [TestMethod]
        public void CreateUser_Should_Not_Add_User_When_Already_Exists()
        {
            // Arrange
            string testName = "Candelaria Sobol";
            string testEmail = "candelariasobol@example.com";

            Usuario usuario = new Usuario();

            usuario.CreateUser(testName, testEmail);

            // Act
            usuario.CreateUser(testName, testEmail);

            // Assert
            Assert.AreEqual(1, Usuario.registeredUsers.Count(u => u.Nombre == testName && u.Email == testEmail));
        }

        [TestMethod]
        public void SeleccionarPreferenciaTema_Should_Add_New_Topic_When_Not_Exists()
        {
            // Arrange
            Usuario usuario = new Usuario { Nombre = "Candelaria", Email = "candelaria@example.com" };
            string tema = "testTema";

            // Act
            usuario.SeleccionarPreferenciaTema(tema);

            // Assert
            Assert.IsTrue(usuario.PreferenciasTemas.Contains(tema));
        }

        [TestMethod]
        public void SeleccionarPreferenciaTema_Should_Not_Add_Topic_When_Already_Exists()
        {
            // Arrange
            Usuario usuario = new Usuario { Nombre = "Candelaria", Email = "candelaria@example.com" };
            string tema = "testTema";

            // Act
            usuario.SeleccionarPreferenciaTema(tema);

            usuario.SeleccionarPreferenciaTema(tema);

            // Assert
            Assert.AreEqual(1, usuario.PreferenciasTemas.Count(t => t == tema));
        }

        [TestMethod]
        public void ObtenerAlertasNoLeidasNoExpiradas_Should_Return_Correct_Alerts()
        {
            // Arrange
            RegistroTemas nuevoTema = new RegistroTemas();
            nuevoTema.RegistrarTemas("Tema1");
            nuevoTema.RegistrarTemas("Tema2");
            nuevoTema.RegistrarTemas("Tema3");

            Usuario usuario = new Usuario();
            Alerta alerta1 = new Alerta("Tema1", "Mensaje1", TipoAlerta.Informativa, DateTime.Now);
            Alerta alerta2 = new Alerta("Tema2", "Mensaje2", TipoAlerta.Urgente, DateTime.Now.AddMinutes(+10));
            Alerta alerta3 = new Alerta("Tema3", "Mensaje3", TipoAlerta.Urgente, DateTime.Now.AddMinutes(+9));

            usuario.AsignarAlerta(alerta1);
            usuario.AsignarAlerta(alerta2);
            usuario.AsignarAlerta(alerta3);

            // Act
            List<Alerta> resultado = usuario.ObtenerAlertasNoLeidasNoExpiradas();

            // Assert
            CollectionAssert.AreEqual(new List<Alerta> { alerta2, alerta3, alerta1 }, resultado);
        }
    }
}
