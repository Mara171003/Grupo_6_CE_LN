using Microsoft.EntityFrameworkCore;
using Grupo_6_CE_LN.Models;
using System.Collections.Generic;

namespace Grupo_6_CE_LN.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Route> Routes { get; set; }  // DbSet para la entidad Route
    }
}
