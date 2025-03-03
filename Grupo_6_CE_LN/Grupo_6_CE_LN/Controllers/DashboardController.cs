using Microsoft.AspNetCore.Mvc;
using Grupo_6_CE_LN.Data;
using Grupo_6_CE_LN.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Grupo_6_CE_LN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly CasoEstudioContext _context;

        
        public DashboardController(CasoEstudioContext context)
        {
            _context = context;
        }

        
        // POST: api/Dashboard
        [HttpPost]
        public async Task<ActionResult<DashboardStats>> PostDashboard(int id)
        {
            // Estadísticas necesarias para el Dashboard
            var totalRoutesActive = await _context.Rutas.CountAsync(r => r.Estado == "Activo");
            var totalVehiclesInGoodCondition = await _context.Vehiculos.CountAsync(v => v.Estado == "Bueno");
            var currentMonth = DateTime.Now.Month;
            var totalTicketsSold = await _context.Boletos
                                                .Where(t => t.FechaHoraCompra.Month == currentMonth)
                                                .CountAsync();

            // Crear un objeto para pasar las estadísticas a la vista
            var dashboardStats = new DashboardStats
            {
                TotalRoutesActive = totalRoutesActive,
                TotalVehiclesInGoodCondition = totalVehiclesInGoodCondition,
                TotalTicketsSold = totalTicketsSold
            };
            _context.DashboardStats.Add(dashboardStats);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDashboard), new { id = dashboardStats.IdDashboard }, dashboardStats);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashboardStats>>> GetDashboard()
        {
            return await _context.DashboardStats.ToListAsync();
        }

    }
}