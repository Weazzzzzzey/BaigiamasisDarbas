using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class Klientas
    {
        public int KlientoID { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }

        public Klientas(int klientoID, string vardas, string pavarde)
        {
            KlientoID = klientoID;
            Vardas = vardas;
            Pavarde = pavarde;
        }
    }
}
