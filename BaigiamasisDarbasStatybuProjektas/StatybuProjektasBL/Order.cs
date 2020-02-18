using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    class Order
    {
        ImonesKlientai DabartniaiKlientai;
        EsamuDaliuRepositorycs esamuDaliuRepositorija;
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OredrItem> perkamosDalysSuKiekiu { get; set; }
        public int Statusas { get; set; }

        public Klientas Uzsakovas {get; set;}

        public Order(EsamuDaliuRepositorycs imonesDalys, int orderID, int uzsakovoID, List<OredrItem> uzsakymai, ImonesKlientai dabartniaiKlientai)
        {
            DabartniaiKlientai = dabartniaiKlientai;
            esamuDaliuRepositorija = imonesDalys;
            OrderID = orderID;
            Uzsakovas = DabartniaiKlientai.Retrieve(uzsakovoID);
            perkamosDalysSuKiekiu = uzsakymai;

            OrderDate = DateTime.Now;
            Statusas = 0;
        }
    
        public void PridetiDali(int daliesID, int daliuKiekis)
        {
            perkamosDalysSuKiekiu.Add(new OredrItem(esamuDaliuRepositorija.Retrieve(daliesID), daliuKiekis));
        }

        public void IstrintiDalis(int pasirinktaPreke)
        {
            perkamosDalysSuKiekiu.RemoveAt(pasirinktaPreke);
        }

        public List<OredrItem> Retrieve()
        {
            List<SudedamojiDalis> KlientoKainuSarasas = new List<SudedamojiDalis>();
            foreach (var item in perkamosDalysSuKiekiu)
            {
                KlientoKainuSarasas.Add(item.SudedamojiDalis);
            }
            return perkamosDalysSuKiekiu;
        }

        public decimal RetrievePrice()
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
