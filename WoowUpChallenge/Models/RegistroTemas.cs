using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoowUpChallenge.Models
{
    public class RegistroTemas
    {
        public static List<string> temasRegistrados = new List<string>();

        public static void RegistrarTemas(string tema)
        {
            if(!temasRegistrados.Contains(tema))
            {
                temasRegistrados.Add(tema);
            }    
        }

        public static List<string> ObtenerTemasRegistrados()
        {
            return temasRegistrados;
        }
    }
}
