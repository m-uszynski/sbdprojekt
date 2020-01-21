using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Podaj dwa miejsca po przecinku")]
        public decimal Cena { get; set; }

        public ICollection<Przesylka> Przesylki { get; set; }


        public RodzajPrzesylki()
        {

            this.Przesylki = new Collection<Przesylka>();
        }
    }
}
