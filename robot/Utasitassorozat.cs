using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robot
{
    /// <summary>
    /// Egy utasítássorozatot tároló publikus osztály.
    /// </summary>
    public class Utasitassorozat
    {
        /// <summary>
        /// Privát lista, mely az utasításokat tárolja.
        /// </summary>
        List<Irany> utasitasok;

        /// <summary>
        /// Létrehoz egy üres utasítássorozatot.
        /// </summary>
        public Utasitassorozat()
        {
            utasitasok = new List<Irany>();
        }

        /// <summary>
        /// Beolvas egy utasítássorzatot egy string-ből és eltárolja a listában.
        /// </summary>
        /// <param name="utasitasokString">Utasítássorozat string.</param>
        public Utasitassorozat(string utasitasokString) : this()
        {
            // Végig megyünk a string minden karakterén.
            for (int i = 0; i < utasitasokString.Length; i++)
            {
                // Megvizsgáljuk, hogy az adott karakter E, D, K vagy N és eltároljuk a megfelelő
                // enumeráció értéket a listában.
                switch (utasitasokString[i])
                {
                    case 'E': utasitasok.Add(Irany.E); break;
                    case 'D': utasitasok.Add(Irany.D); break;
                    case 'K': utasitasok.Add(Irany.K); break;
                    case 'N': utasitasok.Add(Irany.N); break;
                }
            }
        }

        /// <summary>
        /// Igazat ad,  ha az utasitassorozat egyszerűsíthető.
        /// </summary>
        public bool Egyszerusitheto
        {
            get
            {
                // Végigmegyünk az utasításokon az elejétől az utolsó előttiig.
                for (int i = 0; i < utasitasok.Count - 1; i++)
                {
                    // Ha találunk egy olyan utasítást, aminek a rákövetkező elem az
                    // ellentkezője, akkor visszaadunk igazat.
                    if (utasitasok[i] == Irany.D && utasitasok[i + 1] == Irany.E)
                        return true;
                    if (utasitasok[i] == Irany.K && utasitasok[i + 1] == Irany.N)
                        return true;
                    if (utasitasok[i] == Irany.N && utasitasok[i + 1] == Irany.K)
                        return true;
                    if (utasitasok[i] == Irany.E && utasitasok[i + 1] == Irany.D)
                        return true;
                }

                // Ha nem találtunk egyet sem, akkor visszaadunk hamisat.
                return false;
            }
        }

        /// <summary>
        /// Visszaadja, hogy az utasitassorozat végén hova jut a robot.
        /// </summary>
        /// <returns>A végső koordináta.</returns>
        public Koordinata HovaJut()
        {
            // Létrehozunk egy új Koordinata az origóban.
            Koordinata hely = new Koordinata(0, 0);

            // Végigmegyünk az összes utasításon.
            for (int i = 0; i < utasitasok.Count; i++)
            {
                // Minden utasításnál a megfelelő irányba mozgatjuk a Koordinátát.
                hely.Mozgat(utasitasok[i]);
            }
            // Visszaadjuk a végő helyet.
            return hely;
        }

        /// <summary>
        /// Visszadja, hogy a robot hol volt a legtávolabb az origótól, és a
        /// referenciaként átadott paraméterben, hogy hanyadik lépés után.
        /// </summary>
        /// <param name="lepesekSzama">Hány lépés után volt a legtávolabb.</param>
        /// <returns>A legtávolabbi pont koordinátája.</returns>
        public Koordinata HolVanALegtavolabb(ref int lepesekSzama)
        {
            // Feltétlezzünk, hogy a legtávolabbi pont az origó.
            Koordinata legmesszebb = new Koordinata(0, 0); ;
            // Eltároljuk az akutális helyet
            Koordinata akutalisHely = new Koordinata(0, 0);

            // Végigmegyünk az összes lépésen.
            for (int i = 0; i < utasitasok.Count; i++)
            {
                // Minden utasításnál a megfelelő irányba mozgatjuk a Koordinátát.
                akutalisHely.Mozgat(utasitasok[i]);

                // Megnézzük, hogy messzebb van-e, mint az idáigi legtávolabbi pont.
                if(akutalisHely.MennyireMesszeAzOrigotol() > legmesszebb.MennyireMesszeAzOrigotol())
                {
                    // Ha igen, akkor eltároljuk, hogy ez az idáigi legmeszebbi hely.
                    legmesszebb = new Koordinata(akutalisHely);
                    lepesekSzama = i + 1;
                }
            }

            return legmesszebb;
        }

        /// <summary>
        /// Publikus tulajdonság, amely megadja, hogy mennyi energiába tellik végrehajtani
        /// az utasítássorozatot.
        /// </summary>
        public int Energia
        {
            get
            {
                // Kezdeti enegia, mert az első lépés 2 energiába kerül.
                int energia = 1;
                // Előző irány, kezdetben az első.
                Irany irany = utasitasok[0];

                // Végigmegyünk az utasitasokon.
                for (int i = 0; i < utasitasok.Count; i++)
                {
                    // Minden lépés egy energiába kerül.
                    energia++;
                    // Ha az aktuális utasítás nem egyezik az előző iránnyal, akkor 
                    // plusz kettő energia.
                    if (utasitasok[i] != irany)
                    {
                        energia += 2;
                    }
                    // Firssítjük az irányt.
                    irany = utasitasok[i];
                }
                return energia;
            }
        }

        /// <summary>
        /// Betömoríti az utasítássorozatot.
        /// </summary>
        /// <returns>Tömorített utasítássorozat.</returns>
        public string Tomorit()
        {
            // Kezdetben a tömörített utasítássorozat üres.
            string tomoritett = "";

            // Végigmegyünk az utasításokon.
            for (int i = 0; i < utasitasok.Count; i++)
            {
                // Eltráoljuk az akutális irányt
                Irany aktualis = utasitasok[i];

                // j index, ami az i utáni elemre mutat.
                int j = i + 1;
                // Cikluas amíg a j nem indexel túl és a j-edik elem megegyezik az i-edikkel.
                while(j < utasitasok.Count && aktualis == utasitasok[j])
                {
                    // Növeljük a j értékét.
                    j++;
                }

                // Ha a j értéke nem egyezik meg az i+1-gyek, akkor találunk még ugyanolyan
                // utasítást.
                if(j != i + 1)
                {
                    // Beleírjuk, hogy mennyit.
                    tomoritett += j - i;
                    // i értékét j-re állítjuk, hogy a j+1-edik elemtől folytatódjon.
                    i = j - 1;
                }
                // Beleírjuk az irány betűjét.
                tomoritett += aktualis.ToString();
            }

            return tomoritett;
        }

        /// <summary>
        /// Statikus privát segédfüggvény, hogy egy karakter szám e.
        /// </summary>
        /// <param name="c">Karakter.</param>
        /// <returns>Szám-e.</returns>
        public static bool SzamE(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }

        /// <summary>
        /// Statikus metódus, ami kitömöríti az utasítássorozatot.
        /// </summary>
        /// <param name="tomoritett">Tömorített utasítássorozat.</param>
        /// <returns>Kitömörített utasítássorozat.</returns>
        public static string Kitomorit(string tomoritett)
        {
            // A kitömrített string kezdetben üres.
            string kitomoritve = "";

            // Végimegyünk az összes karakteren.
            for (int i = 0; i < tomoritett.Length; i++)
            {
                // Megnézzünk, hogy szám-e.
                if(SzamE(tomoritett[i]))
                {
                    // Ha igen, akkor megkeressük az összeset.

                    // Eltároljuk az első karakter.
                    string darabString = tomoritett[i].ToString();
                    // Index a következő karakterre.
                    int j = i + 1;
                    while(j < tomoritett.Length && SzamE(tomoritett[j]))
                    {
                        // Amíg a karakter szám hozzáadjuk a stringhez.
                        darabString += tomoritett[j].ToString();
                        j++;
                    }

                    // Átalakítjuk számmá.
                    int darab = int.Parse(darabString);
                    // Beleírunk ennyi darab karaktert a kimeneti stringbe.
                    for (int k = 0; k < darab; k++)
                    {
                        // A j index pont a következő karakteren fog állni, ami a betűt mutatja.
                        kitomoritve += tomoritett[j];
                    }
                    // i-t j-re állítjuk, hogy a j+1-gyel folyatódjon a külső ciklus.
                    i = j;
                }
                // Ha nem szám.
                else
                {
                    // Beleírjuk az i-edik karaktert.
                    kitomoritve += tomoritett[i];
                }
            }

            return kitomoritve;
        }
    }
}
