using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoowUpChallenge.Interfaces;

namespace WoowUpChallenge.Models
{
    public class RegistroTemas : IRegistroTemas
    {
        public static List<string> temasRegistrados = new List<string>();

        public void RegistrarTemas(string tema)
        {
            if(!temasRegistrados.Contains(tema))
            {
                temasRegistrados.Add(tema);
            }    
        }

        public List<string> ObtenerTemasRegistrados()
        {
            return temasRegistrados;
        }
    }
}
