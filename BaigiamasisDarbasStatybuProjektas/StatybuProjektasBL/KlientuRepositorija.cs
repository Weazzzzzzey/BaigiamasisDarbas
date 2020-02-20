using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatybuProjektasBL
{
    public class KlientuRepositorija
    {
        private List<Klientas> Klientai;

        public KlientuRepositorija()
        {
            Klientai = new List<Klientas>();
            accesDataBase();
        }

        public void accesDataBase()
        {
            Klientai.Add(new Klientas(0, "Savi", "Ninkas"));
            Klientai.Add(new Klientas(1, "Rimtas", "Mafijozas"));
            Klientai.Add(new Klientas(2, "Vilniaus", "Savivaldybe"));
            Klientai.Add(new Klientas(3, "Aukstaitijos", "Pastatai"));
            Klientai.Add(new Klientas(4, "Zeimatijos", "Pastoges"));
            Klientai.Add(new Klientas(5, "Lentvario", "Dvarai"));
            Klientai.Add(new Klientas(6, "Kruonio", "Elektrine"));
            Klientai.Add(new Klientas(7, "Naujininku", "GarazuBendrija"));
        }
        
        public void addNewClient(int klientoID, string vardas, string pavarde)
        {
            Klientai.Add(new Klientas(klientoID,vardas,pavarde));
        }

        public List<Klientas> Retrieve()
        {
            return Klientai;
        }

        public Klientas Retrieve(int ID)
        {
            foreach (var isgautasKlientas in Klientai)
            {
                if (isgautasKlientas.KlientoID == ID)
                {
                    return isgautasKlientas;
                }
            }
            return null;
        }

    }
}
