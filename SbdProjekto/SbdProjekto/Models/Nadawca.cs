using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Nadawca
    {
        public int NadawcaId { get; set; }
        [DisplayName("Imię")]
        public string Imie { get; set; }
        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }
        [DisplayName("Ulica")]
        public string Ulica { get; set; }
        [DisplayName("Miasto")]
        public string Miasto { get; set; }
        [DisplayName("Kod pocztowy")]
        public string KodPocztowy { get; set; }


        public ICollection<Zamowienie> Zamowienia { get; set; }

        public Nadawca()
        {
            this.Zamowienia = new Collection<Zamowienie>();
        }
    }
}
