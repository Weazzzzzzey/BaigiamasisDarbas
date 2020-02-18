using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class SudedamojiDalis
    {
        public int SudedamosiosDaliesID { get; set; }
        public string SudedamosiosDaliesPavadinimas { get; set; }
        public decimal SudedamosiosDaliesSavikaina { get; set; }

        public SudedamojiDalis(int sudedamosiosDaliesID, string sudedamosiosDaliesPavadinimas, decimal sudedamosiosDaliesSavikaina)
        {
            SudedamosiosDaliesID = sudedamosiosDaliesID;
            SudedamosiosDaliesPavadinimas = sudedamosiosDaliesPavadinimas;
            SudedamosiosDaliesSavikaina = sudedamosiosDaliesSavikaina;
        }

    }
}
