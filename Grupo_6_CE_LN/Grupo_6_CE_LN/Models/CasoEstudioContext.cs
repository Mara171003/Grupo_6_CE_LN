using Microsoft.EntityFrameworkCore;

namespace Grupo_6_CE_LN.Models
{
    public class CasoEstudioContext : DbContext
    {
        public CasoEstudioContext(DbContextOptions<CasoEstudioContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Boletos> Boletos { get; set; }
    }
}
