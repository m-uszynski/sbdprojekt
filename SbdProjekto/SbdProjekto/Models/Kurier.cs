using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Kurier
    {
        public int KurierId { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string Pesel { get; set; }

        public string Telefon { get; set; }

        public int RejonId { get; set; }

        public Rejon Rejon { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; }


        public Kurier()
        {
            this.Zamowienia = new Collection<Zamowienie>();
        }
    }
}
