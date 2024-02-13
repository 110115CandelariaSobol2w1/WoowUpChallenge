using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoowUpChallenge.Interfaces
{
    public interface IRegistroTemas
    {
        void RegistrarTemas(string tema);
        List<string> ObtenerTemasRegistrados();
    }
}
