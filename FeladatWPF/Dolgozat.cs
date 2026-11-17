using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeladatWPF
{
    public class Dolgozat
    {
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public int Pontszam { get; set; }

        public Dolgozat(string nev, int eletkor, int pontszam)
        {
            Nev = nev;
            Eletkor = eletkor;
            Pontszam = pontszam;
        }
    }
}