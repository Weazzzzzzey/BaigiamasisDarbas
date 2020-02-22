using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class AtaskaiteliuGeneratorius
    {
        
        public OrdersRepository ImonesOrderiuHardas { get; private set; }
        
        public AtaskaiteliuGeneratorius( OrdersRepository Hardas)
        {
            
            this.ImonesOrderiuHardas = Hardas;
        }

        public string UzsakymoIsvestine(int OrderioID)
        {
            string OrderioDydis = "";
            List<Order> visiImonesOrderiai = ImonesOrderiuHardas.PerziuretiVisusUzsakymus();
            List<OrderItem> visosDalys = visiImonesOrderiai[OrderioID].GautiVisasDalis();
            string Vardas = visiImonesOrderiai[OrderioID].Uzsakovas.Vardas;
            string Pavarde = visiImonesOrderiai[OrderioID].Uzsakovas.Pavarde;
            decimal BendraSuma = visiImonesOrderiai[OrderioID].OrderPrice();
            OrderioDydis = $"{OrderioID} {Vardas} {Pavarde} {BendraSuma} \n";
            Console.WriteLine("ID Pavadinimas Savikaina Kiekis GalutineKaina");
            foreach (var item in visosDalys)
            {
                OrderioDydis = OrderioDydis + $"{item.SudedamojiDalis.SudedamosiosDaliesID} {item.SudedamojiDalis.SudedamosiosDaliesPavadinimas} {item.SudedamojiDalis.SudedamosiosDaliesSavikaina} {item.Kiekis} {item.ItemPrise()} Eur\n";
            }
            return OrderioDydis;
        }

        public List<StatusuAtaskaitele> PagamintiAtaskaitaPagalStatusaKatikPradeti()
        {
            return PagamintiAtaskaitaPagalStatusa(0);
        }

        public List<StatusuAtaskaitele> PagamintiAtaskaitaPagalStatusaVykdomi()
        {
            return PagamintiAtaskaitaPagalStatusa(1);
        }

        public List<StatusuAtaskaitele> PagamintiAtaskaitaPagalStatusaBaigti()
        {
            return PagamintiAtaskaitaPagalStatusa(2);
        }

        public decimal ApskaiciuotiVisuOrderiuKainaPagalPradetuStatusa()
        {
            return BendrojiSumaVisuOrderiu(0);
        }

        public decimal ApskaiciuotiVisuOrderiuKainaPagalVykdomuStatusa()
        {
            return BendrojiSumaVisuOrderiu(1);
        }

        public decimal ApskaiciuotiVisuOrderiuKainaPagalBaigtuStatusa()
        {
            return BendrojiSumaVisuOrderiu(2);
        }


        public decimal BendrojiSumaVisuOrderiu(int statusas)
        {
            decimal BendraSuma = 0;
            List<Order> visiImonesOrderiai = ImonesOrderiuHardas.PerziuretiVisusUzsakymus();
            foreach (var item in visiImonesOrderiai)
            {
                if (item.Statusas  == statusas)
                {
                    BendraSuma = BendraSuma + item.OrderPrice();
                }
            }
            return BendraSuma;
        }

        private List<StatusuAtaskaitele> PagamintiAtaskaitaPagalStatusa(int statusas)
        {
            List<Order> visiImonesOrderiai = ImonesOrderiuHardas.PerziuretiVisusUzsakymus();
            List<StatusuAtaskaitele> pagalStatusa = new List<StatusuAtaskaitele>();
            foreach (var item in visiImonesOrderiai)
            {
                if (item.Statusas == statusas)
                {
                    pagalStatusa.Add(new StatusuAtaskaitele(item.OrderID, item.Uzsakovas.Vardas, item.Uzsakovas.Pavarde, item.OrderDate.ToShortDateString()));
                }
            }

            return pagalStatusa;
        }
    }
}
