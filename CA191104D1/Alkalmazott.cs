using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191104D1
{
    class Alkalmazott
    {
        public string Nev { get; set; }
        public string OS { get; set; }
        public DateTime Szul { get; set; }
        public string Orszag { get; set; }

        public int Eletkor => DateTime.Now.Year - this.Szul.Year;

        public Alkalmazott(string sor)
        {
            var t = sor.Split(';');
            Nev = t[0];
            OS = t[1];
            Szul = DateTime.Parse(t[2]);
            Orszag = t[3];
        }
    }
}
