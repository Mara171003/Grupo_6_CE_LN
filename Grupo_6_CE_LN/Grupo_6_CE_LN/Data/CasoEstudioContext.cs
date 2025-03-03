using Microsoft.EntityFrameworkCore;
using Grupo_6_CE_LN.Models;
using System.Data;

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
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Boletos> Boletos { get; set; }
        public DbSet<DashboardStats> DashboardStats { get; set; }
    }
}
