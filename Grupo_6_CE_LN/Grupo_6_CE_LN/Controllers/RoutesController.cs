using Microsoft.AspNetCore.Mvc;
using Grupo_6_CE_LN.Models;  // Suponiendo que Models contiene la entidad Route
using Grupo_6_CE_LN.Data;    // Suponiendo que Data es donde está definido el DbContext
using Microsoft.EntityFrameworkCore;

namespace Grupo_6_CE_LN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/routes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            var routes = await _context.Routes.ToListAsync();
            return Ok(routes);
        }

        // GET: api/routes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            var route = await _context.Routes.FindAsync(id);

            if (route == null)
            {
                return NotFound();
            }

            
            return Ok(route);
        }
    }
}
