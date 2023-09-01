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
    public class VigenciascargoesController : ControllerBase
    {
        private readonly NominaContext _context;

        public VigenciascargoesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Vigenciascargoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vigenciascargo>>> GetVigenciascargos()
        {
          if (_context.Vigenciascargos == null)
          {
              return NotFound();
          }
            return await _context.Vigenciascargos.ToListAsync();
        }

        // GET: api/Vigenciascargoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vigenciascargo>> GetVigenciascargo(int id)
        {
          if (_context.Vigenciascargos == null)
          {
              return NotFound();
          }
            var vigenciascargo = await _context.Vigenciascargos.FindAsync(id);

            if (vigenciascargo == null)
            {
                return NotFound();
            }

            return vigenciascargo;
        }

        // PUT: api/Vigenciascargoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVigenciascargo(int id, Vigenciascargo vigenciascargo)
        {
            if (id != vigenciascargo.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(vigenciascargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VigenciascargoExists(id))
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

        // POST: api/Vigenciascargoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vigenciascargo>> PostVigenciascargo(Vigenciascargo vigenciascargo)
        {
          if (_context.Vigenciascargos == null)
          {
              return Problem("Entity set 'NominaContext.Vigenciascargos'  is null.");
          }
            _context.Vigenciascargos.Add(vigenciascargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVigenciascargo", new { id = vigenciascargo.Secuencia }, vigenciascargo);
        }

        // DELETE: api/Vigenciascargoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVigenciascargo(int id)
        {
            if (_context.Vigenciascargos == null)
            {
                return NotFound();
            }
            var vigenciascargo = await _context.Vigenciascargos.FindAsync(id);
            if (vigenciascargo == null)
            {
                return NotFound();
            }

            _context.Vigenciascargos.Remove(vigenciascargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VigenciascargoExists(int id)
        {
            return (_context.Vigenciascargos?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
