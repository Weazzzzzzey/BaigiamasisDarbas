using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    class EsamuDaliuRepositorycs
    {
        private List<SudedamojiDalis> sudedamosiosDalysIrKainorastis { get; set; }

        public EsamuDaliuRepositorycs()
        {
            sudedamosiosDalysIrKainorastis = new List<SudedamojiDalis>();
            KainorascioIpildymas();
        }

        public void KainorascioIpildymas()
        {
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(0,"Pamatas", 7500m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(1,"SonineSiena",2500m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(2,"Siena",5000m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(3,"Langai",99.99m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(4,"DideliLangai",130.99m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(5,"AukstoLubos",2000m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(6,"PalepesLubos",2300m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(7,"StogoKOnstrukcija",3000));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(8,"Sogas",700.99m));
            sudedamosiosDalysIrKainorastis.Add(new SudedamojiDalis(9,"SoninisStogas",350.99m));
        }

        public List<SudedamojiDalis> Retrieve()
        {
            return sudedamosiosDalysIrKainorastis;
        }
        public SudedamojiDalis Retrieve(int id)
        {
            foreach (var item in sudedamosiosDalysIrKainorastis)
            {
                if (item.SudedamosiosDaliesID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
