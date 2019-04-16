using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot
{
    /// <summary>
    /// Osztály egy koordináta reprezenálására.
    /// </summary>
    public class Koordinata
    {
        public int x;
        public int y;

        /// <summary>
        /// Konstruktor, paraméterül várja a koordináta helyét.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        public Koordinata(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Konstruktor, paraméterül vár egy koordinátát.
        /// </summary>
        /// <param name="koordinata">Koordináta.</param>
        public Koordinata(Koordinata koordinata)
        {
            x = koordinata.x;
            y = koordinata.y;
        }

        /// <summary>
        /// Mmetódus, amely visszaadja, a koordináta
        /// milyen messze van az origótól.
        /// </summary>
        /// <returns>A koordináta távolsága az origótól.</returns>
        public double MennyireMesszeAzOrigotol()
        {
            // Pitagorasz
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        /// <summary>
        /// Metódus koordináta mozgatására, a megadott irányba.
        /// </summary>
        /// <param name="irany">Mozgatás iránya.</param>
        public void Mozgat(Irany irany)
        {
            switch (irany)
            {
                case Irany.E:
                    y++; break;
                case Irany.K:
                    x++; break;
                case Irany.N:
                    x--; break;
                case Irany.D:
                    y--; break;
            }
        }
    }
}
