using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class OrderItem
    {
        public SudedamojiDalis SudedamojiDalis;
        public int Kiekis { get; private set; }

        public OrderItem(SudedamojiDalis sudedamojiDalis, int kiekis)
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
