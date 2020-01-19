using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Przesylka
    {
        public int PrzesylkaId { get; set; }

        public double Waga { get; set; }

        public double Szerokosc { get; set; }

        public double Wysokosc { get; set; }

        public double Dlugosc { get; set; }

        public int MagazynId { get; set; }

        public Magazyn Magazyn { get; set; }

        public int RodzajPrzesylkiId { get; set; }

        public RodzajPrzesylki RodzajPrzesylki { get; set; }

        public int ZamowienieId { get; set; }

        public Zamowienie Zamowienie { get; set; }
    }
}
