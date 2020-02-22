using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class StatusuAtaskaitele
    {
        public int orderID { get; set; }
        public string klientoVardas { get; set; }
        public string klientoPavarde { get; set; }
        public string orderioData { get; set; }
        public OrdersRepository VisiImonesOrderiai { get; set; }

        public StatusuAtaskaitele(int orderID, string klientoVardas, string klientoPavarde, string orderioData)
        {
            this.orderID = orderID;
            this.klientoVardas = klientoVardas;
            this.klientoPavarde = klientoPavarde;
            this.orderioData = orderioData;
        }

    }
}
