using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoowUpChallenge.Models;

namespace WoowUpChallenge.Interfaces
{
    public interface IUsuario
    {
        void CreateUser(string nombre, string email);
        void SeleccionarPreferenciaTema(string tema);
        void MarcarAlertaComoLeida(Alerta alerta);
        void AsignarAlerta(Alerta alerta);
        List<Alerta> ObtenerAlertasNoLeidasNoExpiradas();
    }
}
