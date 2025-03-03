using Grupo_6_CE_LN.Data;
using Grupo_6_CE_LN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grupo_6_CE_LN.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletosController : ControllerBase
    {
        private readonly CasoEstudioContext _context;

        public BoletosController(CasoEstudioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boletos>>> GetBoletos()
        {
            return await _context.Boletos
                .Include(b => b.Usuarios)
                .Include(b => b.Ruta)
                .Include(b => b.Vehiculo)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Boletos>> GetBoleto(int id)
        {
            var boleto = await _context.Boletos
                .Include(b => b.Usuarios)
                .Include(b => b.Ruta)
                .Include(b => b.Vehiculo)
                .FirstOrDefaultAsync(b => b.ID_Boleto == id);

            if (boleto == null)
            {
                return NotFound();
            }

            return boleto;
        }

        [HttpPost]
        public async Task<ActionResult<Boletos>> PostBoleto(Boletos boleto)
        {
            // Validaciones para asegurar que el usuario, ruta y vehículo existen
            if (!await _context.Usuarios.AnyAsync(u => u.ID_Usuario == boleto.ID_Usuario) ||
                !await _context.Rutas.AnyAsync(r => r.IdRuta == boleto.IdRuta) ||
                !await _context.Vehiculos.AnyAsync(v => v.Id == boleto.Id))
            {
                return BadRequest("Usuario, Ruta o Vehículo no encontrado.");
            }

            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoleto), new { id = boleto.ID_Boleto }, boleto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleto(int id, Boletos boleto)
        {
            if (id != boleto.ID_Boleto)
            {
                return BadRequest();
            }

            _context.Entry(boleto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletoExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoleto(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }

            _context.Boletos.Remove(boleto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoletoExists(int id)
        {
            return _context.Boletos.Any(e => e.ID_Boleto == id);
        }
    }
}