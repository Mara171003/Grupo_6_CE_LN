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
        public ActionResult<IEnumerable<Boletos>> GetBoletos()
        {
            return _context.Boletos.Include(b => b.Usuarios).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Boletos> GetBoleto(int id)
        {
            var boleto = _context.Boletos.Include(b => b.Usuarios).FirstOrDefault(b => b.ID_Boleto == id);

            if (boleto == null)
            {
                return NotFound();
            }

            return boleto;
        }

        [HttpPost]
        public ActionResult<Boletos> PostBoleto(Boletos boleto)
        {
            if (!_context.Usuarios.Any(u => u.ID_Usuario == boleto.ID_Usuario) //||
               // !_context.Rutas.Any(r => r.IdRuta == boleto.IdRuta) ||
               // !_context.Vehiculos.Any(v => v.Id == boleto.Id)
               )
            {
                return BadRequest("Usuario, Ruta o Vehículo no encontrado.");
            }

            _context.Boletos.Add(boleto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBoleto), new { id = boleto.ID_Boleto }, boleto);
        }

        [HttpPut("{id}")]
        public IActionResult PutBoleto(int id, Boletos boleto)
        {
            if (id != boleto.ID_Boleto)
            {
                return BadRequest();
            }

            _context.Entry(boleto).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
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
        public IActionResult DeleteBoleto(int id)
        {
            var boleto = _context.Boletos.Find(id);
            if (boleto == null)
            {
                return NotFound();
            }

            _context.Boletos.Remove(boleto);
            _context.SaveChanges();

            return NoContent();
        }

        private bool BoletoExists(int id)
        {
            return _context.Boletos.Any(e => e.ID_Boleto == id);
        }
    }
}