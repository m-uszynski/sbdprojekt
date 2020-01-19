using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Magazyn
    {
        public int MagazynId { get; set; }

        public string Nazwa { get; set; }

        public string Ulica { get; set; }


        public string Miasto { get; set; }

        public string KodPocztowy { get; set; }


        public ICollection<Przesylka> Przesylki { get; set; }

        public Magazyn()
        {
            this.Przesylki = new Collection<Przesylka>();
        }
    }
}
