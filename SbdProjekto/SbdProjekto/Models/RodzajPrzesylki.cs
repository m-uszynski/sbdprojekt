using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class RodzajPrzesylki
    {
        public int RodzajPrzesylkiId { get; set; }

        public string Typ { get; set; }

        public double Cena { get; set; }

        public ICollection<Przesylka> Przesylki { get; set; }


        public RodzajPrzesylki()
        {

            this.Przesylki = new Collection<Przesylka>();
        }
    }
}
