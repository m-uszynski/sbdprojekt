using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class RodzajPrzesylki
    {
        public int RodzajPrzesylkiId { get; set; }
        [DisplayName("Typ przesyłki")]
        public string Typ { get; set; }
        [DisplayName("Cena")]
        public double Cena { get; set; }

        public ICollection<Przesylka> Przesylki { get; set; }


        public RodzajPrzesylki()
        {

            this.Przesylki = new Collection<Przesylka>();
        }
    }
}
