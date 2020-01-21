using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Przesylka
    {
        public int PrzesylkaId { get; set; }
        [DisplayName("Waga")]
        [RegularExpression(@"\d+(\.\d{1,3})?", ErrorMessage = "Maksymalnie trzy miejsca po przecinku")]
        public decimal Waga { get; set; }
        [DisplayName("Szerokość")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Maksymalnie dwa miejsca po przecinku")]
        public decimal Szerokosc { get; set; }
        [DisplayName("Wysokość")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Maksymalnie dwa miejsca po przecinku")]
        public decimal Wysokosc { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Maksymalnie dwa miejsca po przecinku")]
        [DisplayName("Długość")]
        public decimal Dlugosc { get; set; }
        [DisplayName("Nazwa magazynu")]
        public int MagazynId { get; set; }
        
        public Magazyn Magazyn { get; set; }
        [DisplayName("Rodzaj przesyłki")]
        public int RodzajPrzesylkiId { get; set; }
        [DisplayName("Rodzaj przesyłki")]
        public RodzajPrzesylki RodzajPrzesylki { get; set; }

        [DisplayName("Numer zamówienia")]
        public int ZamowienieId { get; set; }
        
        public Zamowienie Zamowienie { get; set; }
    }
}
