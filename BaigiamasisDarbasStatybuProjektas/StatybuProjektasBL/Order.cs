using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class Order
    {
        KlientuRepositorija DabartniaiKlientai;
        EsamuDaliuRepositorycs esamuDaliuRepositorija;
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> perkamosDalysSuKiekiu { get; set; }
        public int Statusas { get; set; }

        public Klientas Uzsakovas {get; set;}

        public Order(EsamuDaliuRepositorycs imonesDalys, int orderID, int uzsakovoID, KlientuRepositorija dabartniaiKlientai)
        {
            DabartniaiKlientai = dabartniaiKlientai;
            esamuDaliuRepositorija = imonesDalys;
            OrderID = orderID;
            Uzsakovas = DabartniaiKlientai.Retrieve(uzsakovoID);
            perkamosDalysSuKiekiu = new List<OrderItem>() ;

            OrderDate = DateTime.Now;
            Statusas = 0;
        }
    
        public void PridetiDali(int daliesID, int daliuKiekis)
        {
            perkamosDalysSuKiekiu.Add(new OrderItem(esamuDaliuRepositorija.Retrieve(daliesID), daliuKiekis));
        }

        public void IstrintiDalis(int daliesID)
        {
            int daliesPozicija = 0;
            for (int i = 0; i < perkamosDalysSuKiekiu.Count(); i++)
            {
                if (perkamosDalysSuKiekiu[i].SudedamojiDalis.SudedamosiosDaliesID == daliesID)
                {
                    daliesPozicija = i;
                    break;
                }
            }
            perkamosDalysSuKiekiu.RemoveAt(daliesPozicija);
        }

       

        public decimal OrderPrice()
        {
            decimal kainele = 0;
            foreach (var item in perkamosDalysSuKiekiu)
            {
                kainele = kainele + item.ItemPrise();
            }

            return kainele;
        }

    }
}
