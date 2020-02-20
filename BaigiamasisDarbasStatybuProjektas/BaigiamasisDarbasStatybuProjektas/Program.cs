using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatybuProjektasBL;

namespace BaigiamasisDarbasStatybuProjektas
{
    public class Pakrovimas
    {


       
        OrdersRepository VisiOrderiai = new OrdersRepository();
        
        public void PridetiNaujaOrderi(int UzsakymoNr, int uzsakovoID)
        {
            VisiOrderiai.PridetiNaujaUzsakyma(UzsakymoNr, uzsakovoID);
        }
        
        public void PappildytiKlientoDaliuSarasa(int dalis,int  daliesKiekis,int pasirinktasKlientas)
        {
            VisiOrderiai.pridetiDaliUsakymui(dalis,daliesKiekis,pasirinktasKlientas);
        }

        public void perziuretiVisus()
        {
            List < Order > visi = VisiOrderiai.PerziuretiVisusUzsakymus();
            foreach (var item in visi)
            {
                Console.WriteLine("{0}",item.OrderPrice());
                
                
            }
        }

        public void PerziuretiDaliuSarasa()
        {
            EsamuDaliuRepositorycs esamuDaliuRepositorycs = new EsamuDaliuRepositorycs();
            List<SudedamojiDalis> sudedamojiDalis =
                esamuDaliuRepositorycs.Retrieve();
            Console.WriteLine("ID  Kaina  Pavadinimas");
            foreach (var item in sudedamojiDalis)
            {
                Console.WriteLine("{0} {2} {1}",item.SudedamosiosDaliesID , item.SudedamosiosDaliesPavadinimas, item.SudedamosiosDaliesSavikaina);
            }
        }

        public void PerziuretiKlientuSarasa()
        {
            Console.Clear();
            KlientuRepositorija imonesKlientai = new KlientuRepositorija();
            List<Klientas> klientas = imonesKlientai.Retrieve();
            Console.WriteLine("ID  Vardas  Pavarde");
            foreach (var item in klientas)
            {
                Console.WriteLine("{0} {1} {2}",item.KlientoID, item.Vardas, item.Pavarde);
            }
        }

        public void ProgramaosPradzia()
        {
            Pasirinkimas();
            int pasirinkimas = Convert.ToInt32(Console.ReadLine());
            if(pasirinkimas == 1)
            {
                KlientuMeniu();
            }
            else if (pasirinkimas == 2)
            {
                PerziuretiDaliuSarasa();
            }
            
        }

        public void PridetiNaujaKlienta()
        {
            
        }

        public void KlientuMeniu()
        {
            Console.Clear();
            PasirinkimasKlientams();
            
            int pasirinkimas = Convert.ToInt32(Console.ReadLine());
            if (pasirinkimas == 1)
            {
                PerziuretiKlientuSarasa();
            }
            else if (pasirinkimas == 2)
            {
                PridetiNaujaOrderi(0,0);
            }
        }

        public void ImonesMeniu()
        {

        }
        public void PasirinkimasKlientams()
        {
            Console.WriteLine("1 - Perziureti imones klientus");
            Console.WriteLine("2 - Prideti nauja klienta");
        }

        public void Pasirinkimas()
        {
            Console.WriteLine("1 - Klientu meniu");
            Console.WriteLine("2 - Imones meniu");

        }


    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Pakrovimas pakrovimas = new Pakrovimas();
            //pakrovimas.ProgramaosPradzia();
            OrdersRepository ordersRepository = new OrdersRepository();
            
            ordersRepository.PerziuretiVisusUzsakymus();

            Console.ReadLine();
        }
    }
}
