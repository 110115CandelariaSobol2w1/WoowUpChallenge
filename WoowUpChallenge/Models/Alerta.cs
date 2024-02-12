using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoowUpChallenge.Models

  /* - Se decidio no usar Herencia en este caso para no duplicar codigo innecesario, de esta manera el codigo
    es mas simple y claro.
    - Para los tipos de alerta se decidio usar un enum
    - Mejor Cumplimiento del Principio de Responsabilidad Unica */
{
    public enum TipoAlerta
    {
        Informativa,
        Urgente
    }
    public class Alerta
    {
        public string Tema { get; set; }
        public string Mensaje { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public TipoAlerta Tipo { get; set; }
        public bool Leida { get; private set; }
        public DateTime FechaCreacion { get; set; }

        public static List<Alerta> AlertasEnviadas { get; private set; } = new List<Alerta>();
        public Alerta(string tema, string mensaje, TipoAlerta tipo,DateTime fechaCreacion, DateTime? fechaExpiracion = null)
        {
            Tema = tema;
            Mensaje = mensaje;
            Tipo = tipo;
            FechaCreacion = DateTime.Now;
            FechaExpiracion = fechaExpiracion;
            Leida = false;

            try
            {
                if (RegistroTemas.ObtenerTemasRegistrados().Contains(tema))
                {
                    Tema = tema;
                }
                else
                {
                    throw new ArgumentException("el tema no esta registrado");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void MarcarComoLeida()
        {
            Leida = true;
        }

        public List<Usuario> EnviarAlerta(List<Usuario> usuarios)
        {
            List<Usuario> usuariosNotificados = new List<Usuario>();

            foreach(Usuario usuario in usuarios)
            {
                if (usuario.PreferenciasTemas.Contains(Tema))
                {
                    usuario.AsignarAlerta(this);
                    usuariosNotificados.Add(usuario);
                }
            }

            return usuariosNotificados;
        }

        public bool EnviarAlerta(Usuario destinatario)
        {
            if (destinatario.PreferenciasTemas.Contains(Tema))
            {
                destinatario.AsignarAlerta(this);
                return true;
            }

            return false;
        }

        public static List<Alerta> ObtenerAlertasNoExpiradasPorTema(string tema)
        {
            return AlertasEnviadas
            .Where(alerta => !alerta.Leida && alerta.Tema == tema && (alerta.FechaExpiracion == null || alerta.FechaExpiracion > DateTime.Now))
            .OrderByDescending(alerta => alerta.Tipo)
            .ThenBy(alerta => alerta.Tipo == TipoAlerta.Urgente ? alerta.FechaCreacion : DateTime.MinValue)
            .ToList();
        }

    }
}
