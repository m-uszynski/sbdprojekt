using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Odbiorca
    {
        public int OdbiorcaId { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string Ulica { get; set; }

        public string Miasto { get; set; }

        public string KodPocztowy { get; set; }


        public ICollection<Zamowienie> Zamowienia { get; set; }


        public Odbiorca()
        {
            this.Zamowienia = new Collection<Zamowienie>();
        }
    }
}
