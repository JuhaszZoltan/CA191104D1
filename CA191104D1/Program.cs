using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191104D1
{
    
    class Program
    {
        static List<Alkalmazott> szabaduszok;
        static void Main(string[] args)
        {
            Beolvas();
            Arany();
            Orszagok();
            Belgak();
            LegAndroid();
            OrszagPIos();
            Console.ReadKey();
        }

        private static void OrszagPIos()
        {
            var dic = new Dictionary<string, int>();

            foreach (var a in szabaduszok)
            {
                if (a.OS == "IOS")
                {
                    if (!dic.ContainsKey(a.Orszag))
                    {
                        dic.Add(a.Orszag, 1);
                    }
                    else dic[a.Orszag]++;
                }
            }

            var sw = new StreamWriter("eredmeny.txt");
            foreach (var kvp in dic)
            {
                sw.WriteLine("{0, -11} {1}", kvp.Key, kvp.Value);
            }
            sw.Close();
        }

        private static void LegAndroid()
        {
            var max = new Alkalmazott("-;-;2019-11-04;-");
            var min = new Alkalmazott("-;-;0001-01-01;-");

            foreach (var a in szabaduszok)
            {
                if(a.OS == "Android" && a.Eletkor > max.Eletkor)
                {
                    max = a;
                }
                if(a.OS == "Android" && a.Eletkor < min.Eletkor)
                {
                    min = a;
                }
            }

            Console.WriteLine($"Legfiatalabb: {min.Nev} ({min.Eletkor} éves)");
            Console.WriteLine($"Legöregebb: {max.Nev} ({max.Eletkor} éves)");
        }

        private static void Belgak()
        {
            var belgak = new List<Alkalmazott>();
            foreach (var a in szabaduszok)
            {
                if (a.Orszag == "Belgium") belgak.Add(a);
            }

            for (int i = 0; i < belgak.Count - 1; i++)
            {
                for (int j = i + 1; j < belgak.Count; j++)
                {
                    if(belgak[i].Szul < belgak[j].Szul)
                    {
                        var b = belgak[i];
                        belgak[i] = belgak[j];
                        belgak[j] = b;
                    }
                }
            }
            Console.Write("\n");
            foreach (var b in belgak)
            {
                Console.WriteLine("{0, -15} {1:0}", b.Nev, (DateTime.Now - b.Szul).TotalDays / 365);
            }
        }

        private static void Orszagok()
        {
            var orszagok = new List<string>();

            foreach (var a in szabaduszok)
            {
                if (!orszagok.Contains(a.Orszag)) orszagok.Add(a.Orszag);
            }

            foreach (var o in orszagok)
            {
                Console.Write($"{o}, ");
            }
        }

        private static void Arany()
        {
            int ios = 0;
            int and = 0;
            int win = 0;

            foreach (var a in szabaduszok)
            {
                if (a.OS == "Android") and++;
                else if (a.OS == "IOS") ios++;
                else win++;
            }

            Console.WriteLine($"win: {win / (float)szabaduszok.Count * 100}%");
            Console.WriteLine($"ios: {ios / (float)szabaduszok.Count * 100}%");
            Console.WriteLine($"and: {and / (float)szabaduszok.Count * 100}%");


        }

        private static void Beolvas()
        {
            szabaduszok = new List<Alkalmazott>();
            var sr = new StreamReader("adatok.csv");
            while (!sr.EndOfStream)
            {
                szabaduszok.Add(new Alkalmazott(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
