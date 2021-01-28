using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Obuwie> Obuwie { get; set; }

        public DbSet<Klient> Klient { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }




    }
}
