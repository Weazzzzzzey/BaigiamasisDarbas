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
        public int AtliktiPatikra(int PasirinkimoMeniu)
        {
            var isNumeric = int.TryParse(Console.ReadLine(), out int n);
            if (n >= 0 && n <= PasirinkimoMeniu)
            {
                return n;
            }
            else return 0;
        }
        public void ParodytiDaliuPasirinkimus()
        {
            Console.WriteLine("1 - Parodyti daliu sarasa.");
            Console.WriteLine("2 - Parodyti dali pagal saraso ID.");
            Console.WriteLine("3 - Prideti nauja dali.");
            Console.WriteLine("4 - istrinti dali is saraso.");
        }
        public void ParodytiDaliuSarasa()
        {
            var dalys = TurimosDalys.Retrieve();
            foreach (var item in dalys)
            {
                Console.WriteLine("{0} {1} {2} Eur", item.SudedamosiosDaliesID, item.SudedamosiosDaliesPavadinimas, item.SudedamosiosDaliesSavikaina);
            }
        }
        public void ParodytiDaliPagalID()
        {
            Console.WriteLine("Iveskite prekes ID");
            int PrekesPasirinkimas = Convert.ToInt32(Console.ReadLine());
            SudedamojiDalis vienaDalis = TurimosDalys.Retrieve(PrekesPasirinkimas);
            Console.WriteLine("{0} {1} {2} Eur", vienaDalis.SudedamosiosDaliesID, vienaDalis.SudedamosiosDaliesPavadinimas, vienaDalis.SudedamosiosDaliesSavikaina);
        }
        public void PridetiNaujaPrekia()
        {
            Console.WriteLine("Iveskite prekes ID, pavadinima ir kaina");
            int ID = Convert.ToInt32(Console.ReadLine());
            string Pavadinimas = Console.ReadLine();
            decimal Kaina = Convert.ToDecimal(Console.ReadLine());
            TurimosDalys.PridetiNaujaPrekia(ID, Pavadinimas, Kaina);
        }
        public void IstrintiDaliIsSaraso()
        {
            Console.WriteLine("Iveskite prekes ID, kuria norite istrinti.");
            int ID = Convert.ToInt32(Console.ReadLine());
            TurimosDalys.IstrintiIsSaraso(ID);
        }
        public void ParodytiDaliuMeniu()
        {
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
            else if (pasirinkimas == 0)
            {
                ParodytiDaliuMeniu();
            }
        }
        public void PaordytiKlientuPasirinkimus()
        {
            Console.WriteLine("1 - Parodyti Klientu Sarasa.");
            Console.WriteLine("2 - Parodyti Klienta pagal saraso ID.");
            Console.WriteLine("3 - Prideti nauja Klienta.");
            Console.WriteLine("4 - istrinti Klienta is saraso.");
        }
        public void ParodytiKlientuSarasa()
        {
            var Klientai = ImonesKlientai.Retrieve();
            foreach (var item in Klientai)
            {
                Console.WriteLine("{0} {1} {2}", item.KlientoID, item.Vardas, item.Pavarde);
            }
        }
        public void ParodytiKlientaPagalID()
        {
            Console.WriteLine("Iveskite Kliento ID");
            int klientoPasirinkimas = Convert.ToInt32(Console.ReadLine());
            Klientas vienasKlientas = ImonesKlientai.Retrieve(klientoPasirinkimas);
            Console.WriteLine("{0} {1} {2}", vienasKlientas.KlientoID, vienasKlientas.Vardas, vienasKlientas.Pavarde);
        }
        public void PridetiNaujaKlienta()
        {
            Console.WriteLine("Iveskite kliento ID, Varda ir Pavarde");
            int ID = Convert.ToInt32(Console.ReadLine());
            string Vardas = Console.ReadLine();
            string Pavarde = Console.ReadLine();
            ImonesKlientai.addNewClient(ID, Vardas, Pavarde);
        }
        public void IstrintiKlientaIsSaraso()
        {
            Console.WriteLine("Iveskite Kliento ID, kuria norite istrinti.");
            int ID = Convert.ToInt32(Console.ReadLine());
            ImonesKlientai.IstrintiIsSaraso(ID);
        }
        public void ParodytiKlientuMeniu()
        {
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
            else if (pasirinkimas == 0)
            {
                ParodytiKlientuMeniu();
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

        }
        public void ParodytiVisusUzsakymus()
        {
            var VisiUzsakymai = VisiOrderiai.PerziuretiVisusUzsakymus();
            foreach (var item in VisiUzsakymai)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} Eur", item.OrderID, item.Uzsakovas.Vardas, item.Uzsakovas.Pavarde, item.OrderDate.ToShortDateString(),item.Statusas,item.OrderPrice());
            }
            UzsakymuMeniu();
        }
        public void ParodytiUzsakymusPagalID()
        {
            Console.WriteLine("Iveskite uzsakymo ID");
            int UzsakymoID = Convert.ToInt32(Console.ReadLine());
            var viensUzsakymas = VisiOrderiai.PerziuretiUzsakymaPagalOrderID(UzsakymoID);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} Eur", viensUzsakymas.OrderID, viensUzsakymas.Uzsakovas.Vardas, viensUzsakymas.Uzsakovas.Pavarde, viensUzsakymas.OrderDate, viensUzsakymas.Statusas, viensUzsakymas.OrderPrice());
            UzsakymuMeniu();
        }
        public void ParodytiUzsakymusPagalIDSuDaliuSarasu()
        {
            Console.WriteLine("Iveskite uzsakymo ID");
            int UzsakymoID = Convert.ToInt32(Console.ReadLine());
            var viensUzsakymas = VisiOrderiai.PerziuretiUzsakymaPagalOrderID(UzsakymoID);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} Eur", viensUzsakymas.OrderID, viensUzsakymas.Uzsakovas.Vardas, viensUzsakymas.Uzsakovas.Pavarde, viensUzsakymas.OrderDate, viensUzsakymas.Statusas, viensUzsakymas.OrderPrice());
            var dalys = viensUzsakymas.perkamosDalysSuKiekiu;
            foreach (var item in dalys)
            {
                Console.WriteLine("{0} {1} {2} Eur | {3}",item.Kiekis, item.SudedamojiDalis.SudedamosiosDaliesPavadinimas, item.SudedamojiDalis.SudedamosiosDaliesSavikaina, item.SudedamojiDalis.SudedamosiosDaliesID);
            }
            UzsakymuMeniu();
        }
        public void PakeistiUzsakymoStatusa()
        {
            Console.WriteLine("Iveskite uzsakymo ID ir Statuso ID");
            int UzsakymoID = Convert.ToInt32(Console.ReadLine());
            int StatusoID = Convert.ToInt32(Console.ReadLine());
            VisiOrderiai.PakeistiStatusa(UzsakymoID,StatusoID);
            UzsakymuMeniu();
        }
        public void PridetiNaujaUzsakyma()
        {
            Console.WriteLine("Iveskite orderioID ID ir Uzsakovo ID");
            int orderioID = Convert.ToInt32(Console.ReadLine());
            int uzsakovoID = Convert.ToInt32(Console.ReadLine());
            VisiOrderiai.PridetiNaujaUzsakyma(orderioID, uzsakovoID);
            UzsakymuMeniu();
        }
        public void PridetiDaliuUzsakymui()
        {
            Console.WriteLine("Iveskite Uzsakymo ID, dalies ID ir kieki");
            int orderioID = Convert.ToInt32(Console.ReadLine());
            int daliesID = Convert.ToInt32(Console.ReadLine());
            int daliesKiekis = Convert.ToInt32(Console.ReadLine());
            VisiOrderiai.pridetiDaliUsakymui(orderioID, daliesID, daliesKiekis);
            UzsakymuMeniu();
        }
        public void IstrintiUzsakyma()
        {
            Console.WriteLine("Iveskite Uzsakymo ID, kuri norite istrinti.");
            int ID = Convert.ToInt32(Console.ReadLine());
            VisiOrderiai.IstrintiUzsakyma(ID);
            UzsakymuMeniu();
        }
        public void IstrintiTamTikraDali()
        {
            Console.WriteLine("Iveskite Uzsakymo ID ir trinamos dalies ID.");
            int orderID = Convert.ToInt32(Console.ReadLine());
            int daliesID = Convert.ToInt32(Console.ReadLine());
            VisiOrderiai.IstrintiDaliPagal(orderID,daliesID);
            UzsakymuMeniu();
        }
        public void UzsakymuMeniu()
        {
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
            else if (pasirinkimas == 0)
            {
                UzsakymuMeniu();
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
        }
        
        public void ParodytiPradetusUzsakymus()
        {
            var vykdomi = Ataskaita.PagamintiAtaskaitaPagalStatusaKatikPradeti();
            foreach (var item in vykdomi)
            {
                Console.WriteLine("{0} {1} {2} {3}",item.orderID, item.klientoVardas, item.klientoPavarde,item.orderioData);
            }
        }

        public void ParodytiVykdomusUzsakymus()
        {
            var vykdomi = Ataskaita.PagamintiAtaskaitaPagalStatusaVykdomi();
            foreach (var item in vykdomi)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.orderID, item.klientoVardas, item.klientoPavarde, item.orderioData);
            }
        }

        public void ParodytiBaigusUzsakymus()
        {
            var vykdomi = Ataskaita.PagamintiAtaskaitaPagalStatusaBaigti();
            foreach (var item in vykdomi)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.orderID, item.klientoVardas, item.klientoPavarde, item.orderioData);
            }
        }

        public void paskaiciuotiOrderiuSumaPradeti()
        {
            Console.WriteLine(Ataskaita.ApskaiciuotiVisuOrderiuKainaPagalPradetuStatusa());
        }

        public void paskaiciuotiOrderiuSumaVykdomi()
        {
            Console.WriteLine(Ataskaita.ApskaiciuotiVisuOrderiuKainaPagalVykdomuStatusa()); 
        }

        public void paskaiciuotiOrderiuSumaBaigti()
        {
            Console.WriteLine(Ataskaita.ApskaiciuotiVisuOrderiuKainaPagalBaigtuStatusa());
        }

        public void UzsakymoIsvestine()
        {
            Console.WriteLine("Iveskite Uzsakymo ID.");
            int orderID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Ataskaita.UzsakymoIsvestine(orderID));
        }

        public void AtaskaitosMeniu()
        {
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
            else if (pasirinkimas == 8)
            {
                AtaskaitosMeniu();
            }
        }


        public void ParodytiPagrindiniMeniuPasirinkimus()
        {
            Console.WriteLine("1 - Daliu Meniu");
            Console.WriteLine("2 - Klientu Meniu");
            Console.WriteLine("3 - Uzsakymu Meniu");
            Console.WriteLine("4 - Ataskaitu Meniu");
        }
        public void PagrindinisMeniu()
        {
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
            else if (pasirinkimas == 0)
            {
                PagrindinisMeniu();
            }
        }

    }
}
