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
    public class AlertaTest
    {
        [TestMethod]
        public void EnviarAlerta_Should_Send_Alert_To_Users_With_Correct_Preferences()
        {
            // Arrange
            Usuario usuario1 = new Usuario { Nombre = "Candelaria", Email = "candelaria@example.com" };
            Usuario usuario2 = new Usuario { Nombre = "Luciano", Email = "luciano@example.com" };
            Usuario usuario3 = new Usuario { Nombre = "Lazaro", Email = "lazaro@example.com" };

            RegistroTemas.RegistrarTemas("Salud");

            usuario1.SeleccionarPreferenciaTema("Salud");
            usuario2.SeleccionarPreferenciaTema("Salud");
            usuario3.SeleccionarPreferenciaTema("Musica");

            List<Usuario> usuarios = new List<Usuario> { usuario1, usuario2, usuario3 };

            Alerta nuevaAlerta = new Alerta("Salud", "Nuevos casos de Covid", TipoAlerta.Urgente, DateTime.Now);


            // Act
            List<Usuario> usuariosNotificados = nuevaAlerta.EnviarAlerta(usuarios);


            // Assert
            CollectionAssert.AreEquivalent(new List<Usuario> { usuario1, usuario2 }, usuariosNotificados);
            CollectionAssert.DoesNotContain(usuariosNotificados, usuario3 );

        }

        [TestMethod]
        public void EnviarAlerta_Should_Send_Alert_To_One_User_With_Correct_Preferences()
        {
            // Arrange
            RegistroTemas.RegistrarTemas("Salud");

            Usuario destinatarioConPreferencia = new Usuario { Nombre = "Candelaria", Email = "candelaria@example.com" };
            destinatarioConPreferencia.SeleccionarPreferenciaTema("Salud");

            Usuario destinatarioSinPreferencia = new Usuario { Nombre = "Luciano", Email = "luciano@example.com" };

            Alerta nuevaAlerta = new Alerta("Salud", "Nuevos casos de Covid", TipoAlerta.Urgente, DateTime.Now);

            // Act
            bool alertaEnviada1 = nuevaAlerta.EnviarAlerta(destinatarioConPreferencia);
            bool alertaEnviada2 = nuevaAlerta.EnviarAlerta(destinatarioSinPreferencia);

            // Assert
            Assert.IsTrue(alertaEnviada1, "La alerta deberia enviarse al usuario con preferencia");
            Assert.IsFalse(alertaEnviada2, "La alerta no deberia enviarse al usuario sin preferencia");
        }

        [TestMethod]
        public void MarcarComoLeida_Should_Mark_The_Alert_As_Read()
        {
            // Arrange
            RegistroTemas.RegistrarTemas("Salud");

            Alerta nuevaAlerta = new Alerta("Salud", "Nuevos casos de Covid", TipoAlerta.Urgente, DateTime.Now);

            // Act
            nuevaAlerta.MarcarComoLeida();

            // Assert
            Assert.IsTrue(nuevaAlerta.Leida, "La alerta deberia estar marcada como leida");
        }

    }
}
