using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class OrdersRepository
    {
        public List<Order> VisiUzsakymai { get; set; }
       

        public OrdersRepository()
        {
            VisiUzsakymai = new List<Order>();
        }

        
        public void PridetiNaujaUzsakyma(int OrderioID, int UzsakovoID)
        {
            VisiUzsakymai.Add(new Order(new EsamuDaliuRepositorycs(), OrderioID,UzsakovoID, new KlientuRepositorija()));
        }

        public void pridetiDaliUsakymui(int orderID,int daliesID, int daliesKiekis)
        {
            for (int i = 0; i < VisiUzsakymai.Count(); i++)
            {
                if (VisiUzsakymai[i].OrderID == orderID)
                {
                    VisiUzsakymai[i].PridetiDali(daliesID, daliesKiekis);
                }
            }
            
        }


        public List<Order> PerziuretiVisusUzsakymus()
        {
            return VisiUzsakymai;
        }

        public Order PerziuretiUzsakymaPagalOrderID(int orderID)
        {
            foreach (var item in VisiUzsakymai)
            {
                if (item.OrderID == orderID)
                {
                    return item;
                }
            }
            return null;
        }

        public void PakeistiStatusa(int ID, int StatusoID)
        {

            for (int i = 0; i < VisiUzsakymai.Count; i++)
            {
                if (VisiUzsakymai[i].OrderID == ID)
                {
                    VisiUzsakymai[i].Statusas = StatusoID;
                }
            }

        }

        public void IstrintiUzsakyma(int trinamasUzsakymas)
        {
            int indexiukas = 0;
            for (int i = 0; i < VisiUzsakymai.Count; i++)
            {
                if (VisiUzsakymai[i].OrderID == trinamasUzsakymas)
                {
                    indexiukas = i;
                }
            }

            VisiUzsakymai.RemoveAt(indexiukas);

        }
    }
}
