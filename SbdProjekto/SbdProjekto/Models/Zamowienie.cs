using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Zamowienie
    {
        public int ZamowienieId { get; set; }

        public int KurierId { get; set; }

        public Kurier Kurier { get; set; }

        public int NadawcaId { get; set; }

        public Nadawca Nadawca { get; set; }

        public int OdbiorcaId { get; set; }

        public Odbiorca Odbiorca { get; set; }

        public DateTime DataNadania { get; set; }

        public DateTime DataOdbioru { get; set; }


        public ICollection<Przesylka> Przesylki { get; set; }


        public Zamowienie()
        {
            this.Przesylki = new Collection<Przesylka>();
        }

    }
}
