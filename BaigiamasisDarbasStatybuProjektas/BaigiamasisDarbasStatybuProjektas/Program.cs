using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatybuProjektasBL;

namespace BaigiamasisDarbasStatybuProjektas
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            EsamuDaliuRepositorycs TurimosDalys = new EsamuDaliuRepositorycs();
            KlientuRepositorija ImonesKlientai = new KlientuRepositorija();
            OrdersRepository UzsakymuRepositorija = new OrdersRepository(TurimosDalys, ImonesKlientai);
            AtaskaiteliuGeneratorius ataskaitos = new AtaskaiteliuGeneratorius(UzsakymuRepositorija);
            VersloLogikosValdiklis valdiklis = new VersloLogikosValdiklis(
                TurimosDalys, 
                ImonesKlientai,
                UzsakymuRepositorija,
                ataskaitos );
            valdiklis.PagrindinisMeniu();

            Console.ReadLine();
        }
    }
}
