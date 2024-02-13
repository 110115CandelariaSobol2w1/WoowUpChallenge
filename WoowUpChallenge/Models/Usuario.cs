using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoowUpChallenge.Interfaces;

namespace WoowUpChallenge.Models
{
    public class Usuario : IUsuario
    {
        public String Nombre { get; set; }
        public String Email { get; set; }
        public List<string> PreferenciasTemas { get; set; } = new List<string>();

        public static List<Usuario> registeredUsers = new List<Usuario>();

        public List<Alerta> AlertasUsuario { get; private set; } = new List<Alerta>();


        public void CreateUser(string nombre, string email)
        {
            try
            {
                if (!registeredUsers.Exists(x => x.Email == email))
                {
                    registeredUsers.Add(new Usuario { Nombre = nombre, Email = email });
                }
                else
                {
                    Console.WriteLine("El usuario ya existe");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
            }
                
        }

        public void SeleccionarPreferenciaTema(string tema)
        {
            if(!PreferenciasTemas.Contains(tema))
            {
                PreferenciasTemas.Add(tema);
            }
        }

        public void MarcarAlertaComoLeida(Alerta alerta)
        {
            alerta.MarcarComoLeida();
        }

        public void AsignarAlerta(Alerta alerta)
        {
            AlertasUsuario.Add(alerta);
        }

        public List<Alerta> ObtenerAlertasNoLeidasNoExpiradas()
        {
            return AlertasUsuario
            .Where(alerta => !alerta.Leida && (alerta.FechaExpiracion == null || alerta.FechaExpiracion > DateTime.Now))
            .OrderByDescending(alerta => alerta.Tipo)
            .ThenBy(alerta => alerta.Tipo == TipoAlerta.Urgente ? alerta.FechaCreacion : DateTime.MinValue)
            .ToList();

        }
    }
}
