using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbdProjekto.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Magazyn> Magazyny { get; set; }

        public DbSet<Przesylka> Przesylki { get; set; }

        public DbSet<RodzajPrzesylki> RodzajePrzesylek { get; set; }

        public DbSet<Odbiorca> Odbiorcy { get; set; }

        public DbSet<Zamowienie> Zamowienia { get; set; }

        public DbSet<Kurier> Kurierzy { get; set; }

        public DbSet<Nadawca> Nadawcy { get; set; }

        public DbSet<Rejon> Rejony { get; set; }

    }
}
