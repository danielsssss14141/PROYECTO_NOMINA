using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NOMIN.Models;

namespace NOMIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposunidadesController : ControllerBase
    {
        private readonly NominaContext _context;

        public TiposunidadesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Tiposunidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tiposunidade>>> GetTiposunidades()
        {
          if (_context.Tiposunidades == null)
          {
              return NotFound();
          }
            return await _context.Tiposunidades.ToListAsync();
        }

        // GET: api/Tiposunidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tiposunidade>> GetTiposunidade(int id)
        {
          if (_context.Tiposunidades == null)
          {
              return NotFound();
          }
            var tiposunidade = await _context.Tiposunidades.FindAsync(id);

            if (tiposunidade == null)
            {
                return NotFound();
            }

            return tiposunidade;
        }

        // PUT: api/Tiposunidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposunidade(int id, Tiposunidade tiposunidade)
        {
            if (id != tiposunidade.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(tiposunidade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposunidadeExists(id))
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

        // POST: api/Tiposunidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tiposunidade>> PostTiposunidade(Tiposunidade tiposunidade)
        {
          if (_context.Tiposunidades == null)
          {
              return Problem("Entity set 'NominaContext.Tiposunidades'  is null.");
          }
            _context.Tiposunidades.Add(tiposunidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposunidade", new { id = tiposunidade.Secuencia }, tiposunidade);
        }

        // DELETE: api/Tiposunidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposunidade(int id)
        {
            if (_context.Tiposunidades == null)
            {
                return NotFound();
            }
            var tiposunidade = await _context.Tiposunidades.FindAsync(id);
            if (tiposunidade == null)
            {
                return NotFound();
            }

            _context.Tiposunidades.Remove(tiposunidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposunidadeExists(int id)
        {
            return (_context.Tiposunidades?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
