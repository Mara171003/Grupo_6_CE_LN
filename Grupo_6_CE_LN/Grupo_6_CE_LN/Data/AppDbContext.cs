using Microsoft.EntityFrameworkCore;
using Grupo_6_CE_LN.Models;

namespace Grupo_6_CE_LN.Data.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Vehiculo> Vehiculos { get; set; } // Asegúrate de que el modelo Vehiculo existe
}
