using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Odbiorca
    {
        public int OdbiorcaId { get; set; }
        [DisplayName("Imię")]
        public string Imie { get; set; }

        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }
        [DisplayName("Ulica")]
        public string Ulica { get; set; }
        [DisplayName("Miasto")]
        public string Miasto { get; set; }
        [DisplayName("Kod pocztowy")]
        [DataType(DataType.PostalCode)]
        public string KodPocztowy { get; set; }


        public ICollection<Zamowienie> Zamowienia { get; set; }


        public Odbiorca()
        {
            this.Zamowienia = new Collection<Zamowienie>();
        }
    }
}
