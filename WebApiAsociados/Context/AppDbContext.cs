using Microsoft.EntityFrameworkCore;
using WebApiAsociados.Models;

namespace WebApiAsociados.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {
                    
        }
        public DbSet<Asociado> asociados { get; set; }

        public DbSet<Departamentos> departamentos { get; set; }

        public DbSet<Salarios> salarios { get; set; }

    }
}