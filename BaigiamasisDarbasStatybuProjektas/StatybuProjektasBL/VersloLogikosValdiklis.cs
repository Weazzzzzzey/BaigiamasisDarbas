using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class VersloLogikosValdiklis
    {
        private EsamuDaliuRepositorycs TurimosDalys;
        private KlientuRepositorija ImonesKlientai;
        private OrdersRepository VisiOrderiai;
        private AtaskaiteliuGeneratorius Ataskaita;
        public VersloLogikosValdiklis(EsamuDaliuRepositorycs turimosDalys, KlientuRepositorija imonesKlientai, OrdersRepository visiOrderiai, AtaskaiteliuGeneratorius ataskaita)
        {
            TurimosDalys = turimosDalys;
            ImonesKlientai = imonesKlientai;
            VisiOrderiai = visiOrderiai;
            Ataskaita = ataskaita;
        }

        public void PratesimasDalims()
        {
            Console.WriteLine("Testi toliau spauskite ENTER");
            Console.ReadLine();
            ParodytiDaliuMeniu();
        }
        public void PratesimasUzsakymams()
        {
            Console.WriteLine("Testi toliau spauskite ENTER");
            Console.ReadLine();
            UzsakymuMeniu();
        }
        public void PratesimasAtaskaitai()
        {
            Console.WriteLine("Testi toliau spauskite ENTER");
            Console.ReadLine();
            AtaskaitosMeniu();
        }
        public void PratesimasKlientams()
        {
            Console.WriteLine("Testi toliau spauskite ENTER");
            Console.ReadLine();
            ParodytiKlientuMeniu();
        }
        public int AtliktiPatikra(int PasirinkimoMeniu)
        {
            var isNumeric = int.TryParse(Console.ReadLine(), out int n);
            if (isNumeric == true)
            {
                if (n >= 0 && n <= PasirinkimoMeniu)
                {
                    return n;
                }
                else return 999;
            }
            else return 999;
        }
        public decimal AtliktiPatikraSUDecimal(int PasirinkimoMeniu)
        {
            var isNumeric = decimal.TryParse(Console.ReadLine(), out decimal n);
            if (isNumeric == true)
            {
                if (n >= 0 && n <= PasirinkimoMeniu)
                {
                    return n;
                }
                else return 999;
            }
            else return 999;
        }
        public void ParodytiDaliuPasirinkimus()
        {
            Console.WriteLine("1 - Parodyti daliu sarasa.");
            Console.WriteLine("2 - Parodyti dali pagal saraso ID.");
            Console.WriteLine("3 - Prideti nauja dali.");
            Console.WriteLine("4 - istrinti dali is saraso.");
            Console.WriteLine("0 - Grizti i Pagrindini Meniu");
        }
        public void ParodytiDaliuSarasa()
        {
            Console.Clear();
            Console.WriteLine("ID Pavadinimas Savikaina");
            var dalys = TurimosDalys.Retrieve();
            foreach (var item in dalys)
            {
                Console.WriteLine("{0} {1} {2} Eur", item.SudedamosiosDaliesID, item.SudedamosiosDaliesPavadinimas, item.SudedamosiosDaliesSavikaina);
            }
            Console.WriteLine("\nTesti toliau spauskite Enter!");
            Console.ReadLine();
            ParodytiDaliuMeniu();
        }
        public void ParodytiDaliPagalID()
        {
            Console.Clear();
            Console.WriteLine("Iveskite prekes ID");
            int PrekesPasirinkimas = AtliktiPatikra(999);
            if (TurimosDalys.arYraToksIDSarase(PrekesPasirinkimas) != 999)
            {
                SudedamojiDalis vienaDalis = TurimosDalys.Retrieve(PrekesPasirinkimas);
                Console.WriteLine("{0} {1} {2} Eur", vienaDalis.SudedamosiosDaliesID, vienaDalis.SudedamosiosDaliesPavadinimas, vienaDalis.SudedamosiosDaliesSavikaina);
            }
            else Console.WriteLine("Tokio ID sarase Nera");

            PratesimasDalims();
        }
        public void PridetiNaujaPrekia()
        {
            Console.WriteLine("Iveskite prekes ID, pavadinima ir kaina");
            int ID = AtliktiPatikra(999);
            if (ID == 999)
            {
                Console.WriteLine("Dalis nebuvo prideta!");
                PratesimasDalims();
            }
            string Pavadinimas = Console.ReadLine();

            decimal Kaina = AtliktiPatikraSUDecimal(999);
            if (ID == 999)
            {
                Console.WriteLine("Dalis nebuvo prideta!");
                PratesimasDalims();
            }
            
            TurimosDalys.PridetiNaujaPrekia(ID, Pavadinimas, Kaina);

            PratesimasDalims();
        }
        public void IstrintiDaliIsSaraso()
        {
            Console.Clear();
            Console.WriteLine("Iveskite prekes ID, kuria norite istrinti.");
            int ID = AtliktiPatikra(999);
            if (TurimosDalys.arYraToksIDSarase(ID) != 999)
            {
                TurimosDalys.IstrintiIsSaraso(ID);
                Console.WriteLine("Dalis istrinta sekmingai");
            }
            else Console.WriteLine("Tokio ID sarase Nera");

            PratesimasDalims();
        }
        public void ParodytiDaliuMeniu()
        {
            Console.Clear();
            ParodytiDaliuPasirinkimus();
            int pasirinkimas = AtliktiPatikra(4);

            if (pasirinkimas == 1)
            {
                ParodytiDaliuSarasa();
            }
            else if (pasirinkimas == 2)
            {
                ParodytiDaliPagalID();
            }
            else if (pasirinkimas == 3)
            {
                PridetiNaujaPrekia();
            }
            else if (pasirinkimas == 4)
            {
                IstrintiDaliIsSaraso();
            }
            else if (pasirinkimas == 999)
            {
                ParodytiDaliuMeniu();
            }
            else if (pasirinkimas == 0)
            {
                PagrindinisMeniu();
            }
        }
        public void PaordytiKlientuPasirinkimus()
        {
            Console.WriteLine("1 - Parodyti Klientu Sarasa.");
            Console.WriteLine("2 - Parodyti Klienta pagal saraso ID.");
            Console.WriteLine("3 - Prideti nauja Klienta.");
            Console.WriteLine("4 - istrinti Klienta is saraso.");
            Console.WriteLine("0 - Gristi i pagrindini Meniu.");
        }
        public void ParodytiKlientuSarasa()
        {
            Console.Clear();
            var Klientai = ImonesKlientai.Retrieve();
            foreach (var item in Klientai)
            {
                Console.WriteLine("{0} {1} {2}", item.KlientoID, item.Vardas, item.Pavarde);
            }
            PratesimasKlientams();
        }
        public void ParodytiKlientaPagalID()
        {
            Console.Clear();

            Console.WriteLine("Iveskite Kliento ID");
            int klientoPasirinkimas = AtliktiPatikra(999);
            if (ImonesKlientai.arYraToksIDSarase(klientoPasirinkimas) != 999)
            {
                Klientas vienasKlientas = ImonesKlientai.Retrieve(klientoPasirinkimas);
                Console.WriteLine("{0} {1} {2}", vienasKlientas.KlientoID, vienasKlientas.Vardas, vienasKlientas.Pavarde);
            }
            else Console.WriteLine("Tokio ID sarase Nera");
            PratesimasKlientams();
        }
        public void PridetiNaujaKlienta()
        {
            Console.Clear();
            Console.WriteLine("Iveskite kliento ID, Varda ir Pavarde");
            int ID = AtliktiPatikra(999);
            if (ID == 999)
            {
                Console.WriteLine("Klientas nebuvo pridetas!");
                PratesimasDalims();
            }
            string Vardas = Console.ReadLine();
            string Pavarde = Console.ReadLine();
            ImonesKlientai.addNewClient(ID, Vardas, Pavarde);
            Console.WriteLine("Klientas pridetas sekmingai");

            PratesimasKlientams();
        }
        public void IstrintiKlientaIsSaraso()
        {
            Console.Clear();
            Console.WriteLine("Iveskite Kliento ID, kuria norite istrinti.");
            int ID = AtliktiPatikra(999);
            if (TurimosDalys.arYraToksIDSarase(ID) != 999)
            {
                ImonesKlientai.IstrintiIsSaraso(ID);
                Console.WriteLine("Dalis istrinta sekmingai");
            }
            else Console.WriteLine("Tokio ID sarase Nera");
            PratesimasKlientams();

        }
        public void ParodytiKlientuMeniu()
        {
            Console.Clear();
            PaordytiKlientuPasirinkimus();
            int pasirinkimas = AtliktiPatikra(4);

            if (pasirinkimas == 1)
            {
                ParodytiKlientuSarasa();
            }
            else if (pasirinkimas == 2)
            {
                ParodytiKlientaPagalID();
            }
            else if (pasirinkimas == 3)
            {
                PridetiNaujaKlienta();
            }
            else if (pasirinkimas == 4)
            {
                IstrintiKlientaIsSaraso();
            }
            else if (pasirinkimas == 999)
            {
                ParodytiKlientuMeniu();
            }
            else if (pasirinkimas == 0)
            {
                PagrindinisMeniu(); ;
            }
        }
        public void UzsakymuMeniuGalimybes()
        {
            Console.WriteLine("1 - Perziureti uzsakymus");
            Console.WriteLine("2 - Perziureti uzsakyma pagal ID");
            Console.WriteLine("3 - Perziureti uzsakyma pagal ID su Daliu Sarasu");
            Console.WriteLine("4 - Pakeisti uzsakymo, pagal ID, statusa");
            Console.WriteLine("5 - Prideti Nauja Uzsakyma");
            Console.WriteLine("6 - Prideti daliu uzsakymui");
            Console.WriteLine("7 - Istrinti Uzsakyma");
            Console.WriteLine("8 - Istrinti dalis uzsakyme");
            Console.WriteLine("0 - Gristi i Pagrindini Meniu");

        }
        public void ParodytiVisusUzsakymus()
        {
            Console.Clear();

            var VisiUzsakymai = VisiOrderiai.PerziuretiVisusUzsakymus();
            foreach (var item in VisiUzsakymai)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} Eur", item.OrderID, item.Uzsakovas.Vardas, item.Uzsakovas.Pavarde, item.OrderDate.ToShortDateString(),item.Statusas,item.OrderPrice());
            }
            PratesimasUzsakymams();
        }
        public void ParodytiUzsakymusPagalID()
        {
            Console.Clear();
            Console.WriteLine("Iveskite uzsakymo ID");
            int UzsakymoID = AtliktiPatikra(999);
            
            if (VisiOrderiai.arYraToksIDSarase(UzsakymoID) != 999)
            {
                Console.WriteLine("ID Vardas Pavarde UzsakymoData Kaina");
                var viensUzsakymas = VisiOrderiai.PerziuretiUzsakymaPagalOrderID(UzsakymoID);
                Console.WriteLine("{0} {1} {2} {3} {4} Eur", viensUzsakymas.OrderID, viensUzsakymas.Uzsakovas.Vardas, viensUzsakymas.Uzsakovas.Pavarde, viensUzsakymas.OrderDate.ToShortDateString(), viensUzsakymas.OrderPrice());
            }
            else Console.WriteLine("Tokio ID sarase Nera");
            PratesimasUzsakymams();
        }
        public void ParodytiUzsakymusPagalIDSuDaliuSarasu()
        {
            Console.Clear();
            Console.WriteLine("Iveskite uzsakymo ID");
            int UzsakymoID = AtliktiPatikra(999);
            if (VisiOrderiai.arYraToksIDSarase(UzsakymoID) != 999)
            {
                Console.WriteLine("ID Vardas Pavarde UzsakymoData Kaina");
                var viensUzsakymas = VisiOrderiai.PerziuretiUzsakymaPagalOrderID(UzsakymoID);
                Console.WriteLine("{0} {1} {2} {3} {4} Eur", viensUzsakymas.OrderID, viensUzsakymas.Uzsakovas.Vardas, viensUzsakymas.Uzsakovas.Pavarde, viensUzsakymas.OrderDate.ToShortDateString(), viensUzsakymas.OrderPrice());
                var dalys = viensUzsakymas.perkamosDalysSuKiekiu;
                Console.WriteLine("Kiekis Pavadinimas Savikaina ID");
                foreach (var item in dalys)
                {
                    Console.WriteLine("{0} {1} {2} Eur | {3}", item.Kiekis, item.SudedamojiDalis.SudedamosiosDaliesPavadinimas, item.SudedamojiDalis.SudedamosiosDaliesSavikaina, item.SudedamojiDalis.SudedamosiosDaliesID);
                }
            }
            else Console.WriteLine("Tokio ID sarase Nera");
            PratesimasUzsakymams();
        }
        public void PakeistiUzsakymoStatusa()
        {
            Console.Clear();
            Console.WriteLine("Iveskite uzsakymo ID ir Statuso ID");
            int UzsakymoID = AtliktiPatikra(999);
            if (VisiOrderiai.arYraToksIDSarase(UzsakymoID) != 999)
            {
                int StatusoID = AtliktiPatikra(999);
                if ( StatusoID > -1 && StatusoID < 3)
                {
                    VisiOrderiai.PakeistiStatusa(UzsakymoID, StatusoID);
                    Console.WriteLine("Pakeistas statuas sekmingai!");
                }
                Console.WriteLine("Statusas neatitinka kriteriju");
            }
            else Console.WriteLine("Negalimas ID");

            PratesimasUzsakymams();
        }
        public void PridetiNaujaUzsakyma()
        {
            Console.Clear();
            Console.WriteLine("Iveskite orderioID ID ir Uzsakovo ID");
            
            int orderioID = AtliktiPatikra(999);
            int uzsakovoID = AtliktiPatikra(999);
            Console.WriteLine(VisiOrderiai.PridetiNaujaUzsakyma(orderioID, uzsakovoID)); 
            
            PratesimasUzsakymams();
        }
        public void PridetiDaliuUzsakymui()
        {
            Console.Clear();
            Console.WriteLine("Iveskite Uzsakymo ID, dalies ID ir kieki");
            int orderioID = AtliktiPatikra(999);
            int daliesID = AtliktiPatikra(999);
            int daliesKiekis = AtliktiPatikra(999);

            if (VisiOrderiai.arYraToksIDSarase(orderioID) != 999)
            {
                if (VisiOrderiai.pridetiDaliUsakymui(orderioID, daliesID, daliesKiekis) == true)
                {
                    Console.WriteLine("Dalys pridetos");
                }
                else Console.WriteLine("Netinkamas Daliu iD arba Kiekis");
            }
            else Console.WriteLine("Tokio uzsakymo ID nera");
                
            
            PratesimasUzsakymams();
        }
        public void IstrintiUzsakyma()
        {
            Console.Clear();
            Console.WriteLine("Iveskite Uzsakymo ID, kuri norite istrinti.");
            int ID = AtliktiPatikra(999);
            if (ID == 999)
            {
                Console.WriteLine("Blogas ID");
                PratesimasUzsakymams();
            }

            if (VisiOrderiai.IstrintiUzsakyma(ID) == true)
            {
                Console.WriteLine("Uzsakymas buvo Istrintas");
            }
            else Console.WriteLine("Trinamas ID nebuvo rastas");
            
            PratesimasUzsakymams();
        }
        public void IstrintiTamTikraDali()
        {
            Console.Clear();
            Console.WriteLine("Iveskite Uzsakymo ID ir trinamos dalies ID.");
            int orderID = AtliktiPatikra(999);
            int daliesID = AtliktiPatikra(999);
            if (VisiOrderiai.IstrintiDaliPagal(orderID, daliesID) == true)
            {
                Console.WriteLine("Sekmingai istrinta");
            }
            else Console.WriteLine("Istrinti nepavyko");
            
            PratesimasUzsakymams();
        }
        public void UzsakymuMeniu()
        {
            Console.Clear();
            UzsakymuMeniuGalimybes();
            VisiOrderiai.PerziuretiVisusUzsakymus();
            int pasirinkimas = AtliktiPatikra(8);

            if (pasirinkimas == 1)
            {
                ParodytiVisusUzsakymus();
            }
            else if (pasirinkimas == 2)
            {
                ParodytiUzsakymusPagalID();
            }
            else if (pasirinkimas == 3)
            {
                ParodytiUzsakymusPagalIDSuDaliuSarasu();
            }
            else if (pasirinkimas == 4)
            {
                PakeistiUzsakymoStatusa();
            }
            else if (pasirinkimas == 5)
            {
                PridetiNaujaUzsakyma();
            }
            else if (pasirinkimas == 6)
            {
                PridetiDaliuUzsakymui();
            }
            else if (pasirinkimas == 7)
            {
                IstrintiUzsakyma();
            }
            else if (pasirinkimas == 8)
            {
                IstrintiTamTikraDali();
            }
            else if (pasirinkimas == 999)
            {
                UzsakymuMeniu();
            }
            else if (pasirinkimas == 0)
            {
                PagrindinisMeniu();
            }
        }
        public void ParodytiAtaskaitosMeniu()
        {
            Console.WriteLine("1 - Parodyti uzsakymus pagal pradeta Statusa");
            Console.WriteLine("2 - Parodyti uzsakymus pagal vykdoma Statusa");
            Console.WriteLine("3 - Parodyti uzsakymus pagal baigta Statusa");
            Console.WriteLine("4 - Parodyti vieno uzsakymo pilna isvestine");
            Console.WriteLine("5 - Apskaiciuoti uzsakymu kaina pagal Pradeta Statusa");
            Console.WriteLine("6 - Apskaiciuoti uzsakymu kaina pagal Vykdoma Statusa");
            Console.WriteLine("7 - Apskaiciuoti uzsakymu kaina pagal Baigta Statusa");
            Console.WriteLine("0 - Grizsti i Pagrindini Meniu");
        }
        public void ParodytiPradetusUzsakymus()
        {
            Console.Clear();
            Console.WriteLine("ID Vardas Pavarde Data");
            var vykdomi = Ataskaita.PagamintiAtaskaitaPagalStatusaKatikPradeti();
            foreach (var item in vykdomi)
            {
                Console.WriteLine("{0} {1} {2} {3}",item.orderID, item.klientoVardas, item.klientoPavarde,item.orderioData);
            }
            PratesimasAtaskaitai();
        }
        public void ParodytiVykdomusUzsakymus()
        {
            Console.Clear();
            Console.WriteLine("ID Vardas Pavarde Data");
            var vykdomi = Ataskaita.PagamintiAtaskaitaPagalStatusaVykdomi();
            foreach (var item in vykdomi)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.orderID, item.klientoVardas, item.klientoPavarde, item.orderioData);
            }
            PratesimasAtaskaitai();
        }
        public void ParodytiBaigusUzsakymus()
        {
            Console.Clear();
            Console.WriteLine("ID Vardas Pavarde Data");
            var vykdomi = Ataskaita.PagamintiAtaskaitaPagalStatusaBaigti();
            foreach (var item in vykdomi)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.orderID, item.klientoVardas, item.klientoPavarde, item.orderioData);
            }
            PratesimasAtaskaitai();
        }
        public void paskaiciuotiOrderiuSumaPradeti()
        {
            Console.WriteLine("Bendra suma: {0} Eur", Ataskaita.ApskaiciuotiVisuOrderiuKainaPagalPradetuStatusa());
            PratesimasAtaskaitai();
        }
        public void paskaiciuotiOrderiuSumaVykdomi()
        {
            Console.WriteLine("Bendra suma: {0} Eur", Ataskaita.ApskaiciuotiVisuOrderiuKainaPagalVykdomuStatusa());
            PratesimasAtaskaitai();
        }
        public void paskaiciuotiOrderiuSumaBaigti()
        {
            Console.WriteLine("Bendra suma: {0} Eur",Ataskaita.ApskaiciuotiVisuOrderiuKainaPagalBaigtuStatusa());
            PratesimasAtaskaitai();
        }
        public void UzsakymoIsvestine() //////
        {
            Console.Clear();
            Console.WriteLine("Iveskite Uzsakymo ID.");
            int orderID = Convert.ToInt32(AtliktiPatikra(999));
        
            Console.WriteLine(Ataskaita.UzsakymoIsvestine(orderID));

            PratesimasAtaskaitai();
        }
        public void AtaskaitosMeniu()
        {
            Console.Clear();
            ParodytiAtaskaitosMeniu();
            int pasirinkimas = AtliktiPatikra(8);

            if (pasirinkimas == 1)
            {
                ParodytiPradetusUzsakymus();
            }
            else if (pasirinkimas == 2)
            {
                ParodytiVykdomusUzsakymus();
            }
            else if (pasirinkimas == 3)
            {
                ParodytiBaigusUzsakymus();
            }
            else if (pasirinkimas == 4)
            {
                UzsakymoIsvestine();
            }
            else if (pasirinkimas == 5)
            {
                paskaiciuotiOrderiuSumaPradeti();
            }
            else if (pasirinkimas == 6)
            {
                paskaiciuotiOrderiuSumaVykdomi();
            }
            else if (pasirinkimas == 7)
            {
                paskaiciuotiOrderiuSumaBaigti();
            }
            else if (pasirinkimas == 999)
            {
                AtaskaitosMeniu();
            }
            else if (pasirinkimas == 0)
            {
                PagrindinisMeniu();
            }
        }
        public void ParodytiPagrindiniMeniuPasirinkimus()
        {
            Console.WriteLine("1 - Daliu Meniu");
            Console.WriteLine("2 - Klientu Meniu");
            Console.WriteLine("3 - Uzsakymu Meniu");
            Console.WriteLine("4 - Ataskaitu Meniu");
            Console.WriteLine("0 - Pabaigti Darba");
        }
        public void PagrindinisMeniu()
        {
            Console.Clear();
            ParodytiPagrindiniMeniuPasirinkimus();
            int pasirinkimas = AtliktiPatikra(4);
            
            if (pasirinkimas == 1)
            {
                ParodytiDaliuMeniu();
            }
            else if (pasirinkimas == 2)
            {
                ParodytiKlientuMeniu();
            }
            else if (pasirinkimas == 3)
            {
                UzsakymuMeniu();
            }
            else if (pasirinkimas == 4)
            {
                AtaskaitosMeniu();
            }
            else if (pasirinkimas == 999)
            {
                PagrindinisMeniu();
            }
            else if (pasirinkimas == 0)
            {
                Console.Clear();
                Console.WriteLine("Geros Dienos!");
                Console.WriteLine("Isjungti langa spauskite Enter.");
            }
        }
    }
}
