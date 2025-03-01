using Microsoft.EntityFrameworkCore;
using Grupo_6_CE_LN.Models;

namespace Grupo_6_CE_LN.Data
{
    public class CasoEstudioContext : DbContext
    {
        public CasoEstudioContext(DbContextOptions<CasoEstudioContext> options) : base(options) { }

        //Tablas Rutas

        public DbSet<Rutas> Rutas { get; set; }
        public DbSet<Paradas> Paradas { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}
