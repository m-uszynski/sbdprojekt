using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Magazyn
    {
        public int MagazynId { get; set; }

        [DisplayName("Nazwa magazynu")]
        public string Nazwa { get; set; }
        [DisplayName("Ulica")]
        public string Ulica { get; set; }

        [DisplayName("Miasto")]
        public string Miasto { get; set; }
        [DisplayName("Kod pocztowy")]
        public string KodPocztowy { get; set; }


        public ICollection<Przesylka> Przesylki { get; set; }

        public Magazyn()
        {
            this.Przesylki = new Collection<Przesylka>();
        }
    }
}
