using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoowUpChallenge.Models;

namespace WoowUpChallenge.Interfaces
{
    public interface IAlerta
    {
        void MarcarComoLeida();
        List<Usuario> EnviarAlerta(List<Usuario> usuarios);
        bool EnviarAlerta(Usuario destinatario);
        List<Alerta> ObtenerAlertasNoExpiradasPorTema(string tema);
    }
}
