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
    public class VigenciassueldoesController : ControllerBase
    {
        private readonly NominaContext _context;

        public VigenciassueldoesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Vigenciassueldoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vigenciassueldo>>> GetVigenciassueldos()
        {
          if (_context.Vigenciassueldos == null)
          {
              return NotFound();
          }
            return await _context.Vigenciassueldos.ToListAsync();
        }

        // GET: api/Vigenciassueldoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vigenciassueldo>> GetVigenciassueldo(int id)
        {
          if (_context.Vigenciassueldos == null)
          {
              return NotFound();
          }
            var vigenciassueldo = await _context.Vigenciassueldos.FindAsync(id);

            if (vigenciassueldo == null)
            {
                return NotFound();
            }

            return vigenciassueldo;
        }

        // PUT: api/Vigenciassueldoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVigenciassueldo(int id, Vigenciassueldo vigenciassueldo)
        {
            if (id != vigenciassueldo.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(vigenciassueldo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VigenciassueldoExists(id))
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

        // POST: api/Vigenciassueldoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vigenciassueldo>> PostVigenciassueldo(Vigenciassueldo vigenciassueldo)
        {
          if (_context.Vigenciassueldos == null)
          {
              return Problem("Entity set 'NominaContext.Vigenciassueldos'  is null.");
          }
            _context.Vigenciassueldos.Add(vigenciassueldo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVigenciassueldo", new { id = vigenciassueldo.Secuencia }, vigenciassueldo);
        }

        // DELETE: api/Vigenciassueldoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVigenciassueldo(int id)
        {
            if (_context.Vigenciassueldos == null)
            {
                return NotFound();
            }
            var vigenciassueldo = await _context.Vigenciassueldos.FindAsync(id);
            if (vigenciassueldo == null)
            {
                return NotFound();
            }

            _context.Vigenciassueldos.Remove(vigenciassueldo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VigenciassueldoExists(int id)
        {
            return (_context.Vigenciassueldos?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
