using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Przesylka
    {
        public int PrzesylkaId { get; set; }
        [DisplayName("Waga")]
        public double Waga { get; set; }
        [DisplayName("Szerokość")]
        public double Szerokosc { get; set; }
        [DisplayName("Wysokość")]
        public double Wysokosc { get; set; }
        [DisplayName("Długość")]
        public double Dlugosc { get; set; }

        public int MagazynId { get; set; }
        [DisplayName("Nazwa magazynu")]
        public Magazyn Magazyn { get; set; }

        public int RodzajPrzesylkiId { get; set; }
        [DisplayName("Rodzaj przesyłki")]
        public RodzajPrzesylki RodzajPrzesylki { get; set; }

        [DisplayName("Numer zamówienia")]
        public int ZamowienieId { get; set; }
        
        public Zamowienie Zamowienie { get; set; }
    }
}
