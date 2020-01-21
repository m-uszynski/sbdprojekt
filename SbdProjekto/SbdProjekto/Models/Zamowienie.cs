using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Zamowienie
    {
        [DisplayName("Zamówienie")]
        public int ZamowienieId { get; set; }
        [DisplayName("Kurier")]
        public int KurierId { get; set; }

        public Kurier Kurier { get; set; }
        [DisplayName("Nadawca")]
        public int NadawcaId { get; set; }

        public Nadawca Nadawca { get; set; }
        [DisplayName("Odbiorca")]
        public int OdbiorcaId { get; set; }

        public Odbiorca Odbiorca { get; set; }
        [DisplayName("Data nadania")]
        public DateTime DataNadania { get; set; }
        [DisplayName("Data odbioru")]
        
        public DateTime? DataOdbioru { get; set; }


        public ICollection<Przesylka> Przesylki { get; set; }


        public Zamowienie()
        {
            this.Przesylki = new Collection<Przesylka>();
        }

    }
}
