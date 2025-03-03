using Microsoft.AspNetCore.Mvc;
using Grupo_6_CE_LN.Data;
using Grupo_6_CE_LN.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Grupo_6_CE_LN.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Estadísticas necesarias para el Dashboard
            var totalRoutesActive = await _context.Routes.CountAsync(r => r.Status == "Activo");
            var totalVehiclesInGoodCondition = await _context.Vehicles.CountAsync(v => v.Status == "Bueno");
            var currentMonth = DateTime.Now.Month;
            var totalTicketsSold = await _context.Tickets
                                                .Where(t => t.PurchaseDate.Month == currentMonth)
                                                .CountAsync();

            // Crear un objeto para pasar las estadísticas a la vista
            var dashboardStats = new DashboardStats
            {
                TotalRoutesActive = totalRoutesActive,
                TotalVehiclesInGoodCondition = totalVehiclesInGoodCondition,
                TotalTicketsSold = totalTicketsSold
            };

            
            return View(dashboardStats);
        }
    }
}
