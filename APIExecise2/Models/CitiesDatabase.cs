using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APIExecise2.Models
{
    public class CitiesDatabase : DbContext
    {
        public CitiesDatabase(DbContextOptions<CitiesDatabase> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
    }
}
