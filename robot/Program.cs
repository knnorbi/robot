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
        static void TomoritettUtasitasokFajlba(string path, List<UtasitasSorozat> lista)
        {
            StreamWriter streamWriter = new StreamWriter(path);
            foreach (UtasitasSorozat us in lista)
            {
                streamWriter.WriteLine(us.Tomorit());
            }
            streamWriter.Close();
        }

        static void Main(string[] args)
        {
            List<UtasitasSorozat> utasitasSorozatok = new List<UtasitasSorozat>();

            string[] sorok = File.ReadAllLines(@"..\..\..\program.txt");

            for (int i = 1; i < sorok.Length; i++)
            {
                utasitasSorozatok.Add(new UtasitasSorozat(sorok[i]));
            }

            Console.WriteLine("2. feladat");
            Console.WriteLine("Kérek egy szamot:");
            int sorsz = -1;
            try
            {
                sorsz = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Számot!!!!!!!");
            }

            try
            {
                Console.Write("A " + sorsz + ". utasítássorozat ");
                Console.Write(utasitasSorozatok[sorsz].Egyszerusitheto ? "nem " : "");
                Console.WriteLine("egyszerűsíthető!");


                int[] hely = utasitasSorozatok[sorsz].HovaJut();
                Console.WriteLine("A origóhoz menni kell x=" + (-1 * hely[0]) + " y=" + (-1*hely[1]) + " lépést.");

                int[] messze = utasitasSorozatok[sorsz].HolVanALegtavolabb();
                Console.WriteLine("A legmesszebb x=" + messze[0] + " y=" + messze[1] + " helyen van, " + messze[2] + " távolságra.");
            }
            catch (Exception)
            {
                Console.WriteLine("Nincs ilyen utasítássorozat!");
            }

            for (int i = 0; i < utasitasSorozatok.Count; i++)
            {
                if (utasitasSorozatok[i].Energia <= 100)
                {
                    Console.WriteLine("A {0}. utasítássorozathoz elég a kis akkumulátor.", i);
                }
                else if (utasitasSorozatok[i].Energia <= 1000)
                {
                    Console.WriteLine("A {0}. utasítássorozathoz a nagy akkumulátor kell.", i);
                }
                else
                {
                    Console.WriteLine("A {0}. utasítássorozathoz nem elég a nagy akkumulátor sem.", i);
                }
            }

            TomoritettUtasitasokFajlba("ujprog.txt", utasitasSorozatok);

            Console.ReadKey();
        }
    }
}
