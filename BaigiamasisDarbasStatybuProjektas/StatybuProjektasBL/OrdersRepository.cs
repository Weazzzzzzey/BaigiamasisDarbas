using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class OrdersRepository
    {
        private List<Order> VisiUzsakymai { get; set; }
        private EsamuDaliuRepositorycs TurimosDalys;
        private KlientuRepositorija ImonesKlientai;
        public OrdersRepository(EsamuDaliuRepositorycs turimosDalys, KlientuRepositorija imonesKlientai)
        {
            VisiUzsakymai = new List<Order>();
            TurimosDalys = turimosDalys;
            ImonesKlientai = imonesKlientai;
            SeniauPriimtiUzsakymai();
        }

        public int arYraToksIDSarase(int ID)
        {
            foreach (var item in VisiUzsakymai)
            {
                if (item.OrderID == ID)
                {
                    return ID;
                }
            }
            return 999;
        }

        private void SeniauPriimtiUzsakymai()
        {
            VisiUzsakymai.Add(new Order(TurimosDalys, 0, 1, ImonesKlientai));
            VisiUzsakymai.Add(new Order(TurimosDalys, 1, 3, ImonesKlientai));
            VisiUzsakymai.Add(new Order(TurimosDalys, 2, 6, ImonesKlientai));
            VisiUzsakymai.Add(new Order(TurimosDalys, 3, 1, ImonesKlientai));
            VisiUzsakymai.Add(new Order(TurimosDalys, 4, 5, ImonesKlientai));
            VisiUzsakymai.Add(new Order(TurimosDalys, 5, 4, ImonesKlientai));
            VisiUzsakymai.Add(new Order(TurimosDalys, 6, 7, ImonesKlientai));

            pridetiDaliUsakymui(0, 0, 1);
            pridetiDaliUsakymui(0, 2, 4);
            pridetiDaliUsakymui(0, 4, 4);
            pridetiDaliUsakymui(0, 8, 1);
            PakeistiStatusa(0, 0);

            pridetiDaliUsakymui(1, 0, 2);
            pridetiDaliUsakymui(1, 1, 2);
            pridetiDaliUsakymui(1, 2, 4);
            pridetiDaliUsakymui(1, 4, 8);
            pridetiDaliUsakymui(1, 5, 2);
            pridetiDaliUsakymui(1, 7, 2);
            pridetiDaliUsakymui(1, 8, 2);
            pridetiDaliUsakymui(1, 9, 2);
            PakeistiStatusa(1, 1);

            pridetiDaliUsakymui(2, 0, 1);
            pridetiDaliUsakymui(2, 2, 2);
            pridetiDaliUsakymui(2, 3, 2);
            pridetiDaliUsakymui(2, 7, 1);
            pridetiDaliUsakymui(2, 8, 1);
            PakeistiStatusa(2, 1);

            pridetiDaliUsakymui(4, 0, 1);
            pridetiDaliUsakymui(4, 1, 2);
            pridetiDaliUsakymui(4, 2, 2);
            pridetiDaliUsakymui(4, 3, 6);
            pridetiDaliUsakymui(4, 5, 1);
            pridetiDaliUsakymui(4, 7, 1);
            pridetiDaliUsakymui(4, 8, 2);
            pridetiDaliUsakymui(4, 9, 2);
            PakeistiStatusa(4, 1);

            pridetiDaliUsakymui(6, 0, 1);
            pridetiDaliUsakymui(6, 2, 2);
            pridetiDaliUsakymui(6, 8, 2);
            PakeistiStatusa(6, 2);
        }
        
        public string PridetiNaujaUzsakyma(int OrderioID, int UzsakovoID)
        {
            var klientas = ImonesKlientai.Retrieve(UzsakovoID);
            if (klientas != null)
            {
                VisiUzsakymai.Add(new Order(TurimosDalys, OrderioID, UzsakovoID, ImonesKlientai));
                return "Uzsakymas pridetas";
            }
            return "Uzsakymas nepridetas";
        }

        public bool pridetiDaliUsakymui(int orderID,int daliesID, int daliesKiekis)
        {
            if (daliesID == 999 || daliesKiekis == 999)
            {
                return false;
            }

            if (TurimosDalys.arYraToksIDSarase(daliesID) == 999)
            {
                return false;
            }
            

            for (int i = 0; i < VisiUzsakymai.Count(); i++)
            {
                if (VisiUzsakymai[i].OrderID == orderID)
                {
                    VisiUzsakymai[i].PridetiDali(daliesID, daliesKiekis);
                    return true;
                }
            }
            return false;
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

        public bool IstrintiDaliPagal(int OrderID, int DaliesID)
        {
            int indeksiukas = 0;
            int sarasuDydis = 0;
            for (int i = 0; i < VisiUzsakymai.Count; i++)
            {
                if (OrderID == VisiUzsakymai[i].OrderID)
                {
                    for (int j = 0; j < VisiUzsakymai[i].perkamosDalysSuKiekiu.Count; j++)
                    {
                        if (VisiUzsakymai[i].perkamosDalysSuKiekiu[j].SudedamojiDalis.SudedamosiosDaliesID == DaliesID)
                        {
                            indeksiukas = j;
                            sarasuDydis = VisiUzsakymai[i].perkamosDalysSuKiekiu.Count;
                        }
                        
                    }
                }
            }


            if(sarasuDydis > indeksiukas)
            {
                VisiUzsakymai[OrderID].perkamosDalysSuKiekiu.RemoveAt(indeksiukas);
                return true;
            }

            return false;
            
            
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

        public bool IstrintiUzsakyma(int trinamasUzsakymas)
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
            if (indexiukas == 0) 
            {
                return false;
            }
            return true;

        }
    }
}
