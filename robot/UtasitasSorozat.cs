using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot
{
    public class UtasitasSorozat
    {
        List<Irany> utasitasok;

        public UtasitasSorozat()
        {
            utasitasok = new List<Irany>();
        }

        public UtasitasSorozat(string utasitasokString)
        {
            utasitasok = new List<Irany>();
            for (int i = 0; i < utasitasokString.Length; i++)
            {
                switch (utasitasokString[i])
                {
                    case 'E': utasitasok.Add(Irany.Eszak); break;
                    case 'D': utasitasok.Add(Irany.Del); break;
                    case 'K': utasitasok.Add(Irany.Kelet); break;
                    case 'N': utasitasok.Add(Irany.Nyugat); break;
                }
            }
        }

        public bool Egyszerusitheto
        {
            get
            {
                for (int i = 0; i < utasitasok.Count - 1; i++)
                {
                    if (utasitasok[i] == Irany.Del && utasitasok[i + 1] == Irany.Eszak)
                        return true;
                    if (utasitasok[i] == Irany.Kelet && utasitasok[i + 1] == Irany.Nyugat)
                        return true;
                    if (utasitasok[i] == Irany.Nyugat && utasitasok[i + 1] == Irany.Kelet)
                        return true;
                    if (utasitasok[i] == Irany.Eszak && utasitasok[i + 1] == Irany.Del)
                        return true;
                }

                return false;
            }
        }

    }
}
