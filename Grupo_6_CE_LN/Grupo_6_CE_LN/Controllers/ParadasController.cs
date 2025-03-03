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
    public class ParadasController : ControllerBase
    {
        private readonly CasoEstudioContext _context;

        public ParadasController(CasoEstudioContext context)
        {
            _context = context;
        }

        // GET: api/Paradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paradas>>> GetParadas()
        {
            return await _context.Paradas.ToListAsync();
        }

    }
}
