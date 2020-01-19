using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Kurier
    {

        public int KurierId { get; set; }
        [DisplayName("Imię")]
        public string Imie { get; set; }
        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }
        [DisplayName("PESEL")]
        public string Pesel { get; set; }
        [DisplayName("Numer telefonu")]
        public string Telefon { get; set; }

        public int RejonId { get; set; }
        [DisplayName("Nazwa rejonu")]
        public Rejon Rejon { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; }


        public Kurier()
        {
            this.Zamowienia = new Collection<Zamowienie>();
        }
    }
}
