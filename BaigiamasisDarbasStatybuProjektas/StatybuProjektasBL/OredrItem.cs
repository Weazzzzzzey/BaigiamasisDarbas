using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class OredrItem
    {
        public SudedamojiDalis SudedamojiDalis;
        public int Kiekis { get; private set; }

        public OredrItem(SudedamojiDalis sudedamojiDalis, int kiekis)
        {
            this.SudedamojiDalis = sudedamojiDalis;
            Kiekis = kiekis;
        }

        public decimal ItemPrise()
        {
            return SudedamojiDalis.SudedamosiosDaliesSavikaina * Kiekis;
        }

    }
}
