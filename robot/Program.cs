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
            List<UtasitasSorozat> utasitasSorozatok = new List<UtasitasSorozat>();

            string[] sorok = File.ReadAllLines(@"c:\tmp\19-04-10_robotosdi\program.txt");

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
            }
            catch (Exception)
            {
                Console.WriteLine("Nincs ilyen utasítássorozat!");
            }


            Console.ReadKey();
        }
    }
}
