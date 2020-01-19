using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class Rejon
    {
        public int RejonId { get; set; }
        public string Nazwa { get; set; }
        public string Wojewodztwo { get; set; }


        public ICollection<Kurier> Kurierzy { get; set; }

        public Rejon()
        {
            this.Kurierzy = new Collection<Kurier>();
        }
    }
}
