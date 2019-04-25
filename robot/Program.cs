using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace robot
{
    class Program
    {
    
        static void Main(string[] args)
        {
            #region 1. feladat
            // Létrehozunk egy listát, amely az utasítássorozatokat tárolja.
            List<Utasitassorozat> utasitassorozatok = new List<Utasitassorozat>();

            // Beolvassuk egy string tömbe a bemeneti fájl összes sorát.
            string[] sorok = File.ReadAllLines(@"..\..\..\program.txt");

            // Végigmegyünk az összes sorok (kivéve az elsőn), és minden sorból
            // létrehozunk egy Utasítássorozat osztálypéldánt, melyet hozzáadunk a listához.
            for (int i = 1; i < sorok.Length; i++)
            {
                utasitassorozatok.Add(new Utasitassorozat(sorok[i]));
            }

            // Ellenőrizzük, hogy volt-e utasítás a fájlban. Ha nem, kilépünk a programból.
            if(utasitassorozatok.Count == 0)
            {
                Console.WriteLine("A bementi fájl nem tartalmaz utasításokat!");
                Console.ReadKey();
                return;
            }
            #endregion

            #region 2. feladat
            // Bekérünk a felhasználótól egy utasítássorozat sorszámot.
            Console.WriteLine("Írj be egy utasítássorozat sorszámot!");
            string bekert = Console.ReadLine();

            // Megpróbáljuk int-é alakítani.
            int sorszam = -1;
            try
            {
                sorszam = int.Parse(bekert);
            }
            // Ha nem számot írt be.
            catch (FormatException)
            {
                Console.WriteLine("Csak számot írhatsz be!");
            }
            // Ha túl nagy számot írt be.
            catch (OverflowException)
            {
                Console.WriteLine("Túl nagy a szám!");
            }
            // Végezetül, mindenképp.
            finally
            {
                // Ellenőrizzük, hogy létezik-e ez a sorszám.
                if (sorszam < 0 || sorszam >= utasitassorozatok.Count)
                {
                    sorszam = 0;
                    Console.WriteLine("A kiválasztott sorszám nem létezik. Automatikusan kiválasztok egy létezőt!");
                }

                Console.WriteLine("A kiválasztott sorsám: {0}", sorszam);
            }
            #endregion

            #region 2.a feladat
            Console.WriteLine("--- 2.a feladat ---");

            // Az Utasitassorozat Egyszerusithető tulajdonságát felhasználva kiijuk, hogy
            // a kiválasztott utasítássorozat egyszerűsíthető-e.
            Console.WriteLine("A {0}. számú utasítássorozat {1}egyszerűsíthető.", sorszam, utasitassorozatok[sorszam].Egyszerusitheto ? "" : "nem ");
            #endregion

            #region 2.b feladat
            Console.WriteLine("--- 2.b feladat ---");

            // Az Utasitassorozat HovaJut metódusát felhasználva kiírjuk, hogy merre kell menni
            // vissza az origó felé.
            int ED = (-1) * utasitassorozatok[sorszam].HovaJut().y;
            int KN = (-1) * utasitassorozatok[sorszam].HovaJut().x;

            Console.WriteLine("{0} lépést kell tenni az ED, {1} lépést a KN tengely mentén.", ED, KN);
            #endregion

            #region 2.c feladat
            Console.WriteLine("--- 2.c feladat ---");

            // Az Utasitassorozat HolVanALegtavolabb metódusát felhasználva kiírjuk, hogy
            // hány lépés után került a legmesszebb a robot, és hogy ehhez hány lépést kellett
            // megtennie.
            int lepesszam = 0;
            Koordinata hely = utasitassorozatok[sorszam].HolVanALegtavolabb(ref lepesszam);
            double tavolsag = hely.MennyireMesszeAzOrigotol();
            tavolsag = Math.Round(tavolsag, 3);

            Console.WriteLine("A robot {0} lépés után volt a legmesszebb, {1} távolságra.", lepesszam, tavolsag);
            #endregion

            #region 3. feladat
            Console.WriteLine("--- 3. feladat ---");

            // Végigmegyünk az utasításokon és kiírjuk az energiaszükségletüket az 
            // Energia tulajdonságot felhasználva.
            for (int i = 0; i < utasitassorozatok.Count; i++)
            {
                Console.WriteLine("{0} {1}", i, utasitassorozatok[i].Energia);
            }
            #endregion

            #region 4. feladat
            Console.WriteLine("--- 4. feladat ---");

            // Kiírjuk az utasítássorozatokat tömörítve egy fájlba, az Utasítassorozat
            // Tomorit medódusát felhasználva.

            // StreamWriter példányosítása
            StreamWriter streamWriter = new StreamWriter(@"..\..\..\ujprog.txt");

            // Végigmenyünk az összes utasítássorozaton.
            foreach (Utasitassorozat utasitassorozat in utasitassorozatok)
            {
                streamWriter.WriteLine(utasitassorozat.Tomorit());
            }

            streamWriter.Close();
            #endregion

            #region 5. feladat
            Console.WriteLine("--- 5. feladat ---");

            // Bekérünk egy tömörített utasítássorozatot.
            Console.WriteLine("Írj be egy tömörített utasítássorozatot!");
            string tomoritett = Console.ReadLine();

            //Kiírjuk kitömorítve az Utasitassorozat osztály statikus Kitomorit metódusa segítségével
            Console.WriteLine(Utasitassorozat.Kitomorit(tomoritett));
            #endregion

            Console.ReadKey();
        }
    }
}
