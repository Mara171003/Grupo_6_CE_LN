using Microsoft.EntityFrameworkCore;

namespace Grupo_6_CE_LN.Models
{
    public class CasoEstudioContext : DbContext
    {
        public CasoEstudioContext(DbContextOptions<CasoEstudioContext> options) : base(options) { }

        //Tablas Rutas

        public DbSet<Rutas> Rutas { get; set; }
        public DbSet<Paradas> Paradas { get; set; }
        public DbSet<Horarios> Horarios { get; set; }


    }
}
