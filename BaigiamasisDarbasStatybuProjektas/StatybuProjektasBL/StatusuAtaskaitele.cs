using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    class StatusuAtaskaitele
    {
        public int orderID { get; set; }
        public string klientoVardas { get; set; }
        public string klientoPavarde { get; set; }
        public DateTime orderioData { get; set; }
        public int Statusas { get; set; }
        public OrdersRepository VisiImonesOrderiai { get; set; }

        public StatusuAtaskaitele(int orderID, string klientoVardas, string klientoPavarde, DateTime orderioData, int statusas)
        {
            this.orderID = orderID;
            this.klientoVardas = klientoVardas;
            this.klientoPavarde = klientoPavarde;
            this.orderioData = orderioData;
            Statusas = statusas;
        }

    }
}
