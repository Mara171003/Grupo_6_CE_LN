using Grupo_6_CE_LN.Data;
using Grupo_6_CE_LN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grupo_6_CE_LN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly CasoEstudioContext _context;

        public RutasController(CasoEstudioContext context)
        {
            _context = context;
        }

        // GET: api/Rutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rutas>>> GetRutas()
        {
            return await _context.Rutas.ToListAsync();
        }

        // GET: api/Rutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rutas>> GetRutas(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);

            if (ruta == null)
            {
                return NotFound();
            }

            return ruta;
        }

        // POST: api/Rutas
        [HttpPost]
        public async Task<ActionResult<Rutas>> PostRutas(Rutas ruta)
        {
            _context.Vehiculos.Add(ruta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRutas), new { id = ruta.IdRuta}, ruta);
        }

        // PUT: api/Rutas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRutas(int id, Rutas ruta)
        {
            if (id != ruta.IdRuta)
            {
                return BadRequest();
            }

            _context.Entry(ruta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Rutas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRutas(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }

            _context.Vehiculos.Remove(ruta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RutasExists(int id)
        {
            return _context.Rutas.Any(e => e.IdRuta == id);
        }

        // GET: api/Paradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paradas>>> GetParadas()
        {
            return await _context.Paradas.ToListAsync();
        }

        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horarios>>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }

    }
}
