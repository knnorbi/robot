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

        public int[] HovaJut()
        {
            int[] hely = new int[2];
            for (int i = 0; i < utasitasok.Count; i++)
            {
                switch (utasitasok[i])
                {
                    case Irany.Eszak:
                        hely[1]++; break;
                    case Irany.Kelet:
                        hely[0]++; break;
                    case Irany.Nyugat:
                        hely[0]--; break;
                    case Irany.Del:
                        hely[1]--; break;
                }
            }
            return hely;
        }

        static double MennyireMessze(int[] hely)
        {
            return Math.Sqrt(Math.Pow(hely[0], 2) + Math.Pow(hely[1], 2));
        }

        public int[] HolVanALegtavolabb()
        {
            int[] legmesszebb = new int[] { 0, 0 };
            int legmeszebbLepesszam = 0;
            int[] aktualisHely = new int[] { 0, 0 };
            for (int i = 0; i < utasitasok.Count; i++)
            {
                switch (utasitasok[i])
                {
                    case Irany.Eszak:
                        aktualisHely[1]++; break;
                    case Irany.Kelet:
                        aktualisHely[0]++; break;
                    case Irany.Nyugat:
                        aktualisHely[0]--; break;
                    case Irany.Del:
                        aktualisHely[1]--; break;
                }
                if(MennyireMessze(aktualisHely) > MennyireMessze(legmesszebb))
                {
                    legmesszebb = aktualisHely;
                    legmeszebbLepesszam = i + 1;
                }
            }
            return new int[] { legmesszebb[0], legmesszebb[1], legmeszebbLepesszam };
        }

    }
}
