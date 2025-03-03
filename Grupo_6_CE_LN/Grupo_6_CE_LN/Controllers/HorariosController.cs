using Grupo_6_CE_LN.Data;
using Grupo_6_CE_LN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grupo_6_CE_LN.Controllers
{
    public class HorariosController : ControllerBase
    {
        private readonly CasoEstudioContext _context;

        public HorariosController(CasoEstudioContext context)
        {
            _context = context;
        }

        // GET: api/Horarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horarios>>> GetHorarios()
        {
            return await _context.Horarios.ToListAsync();
        }
    }
}
