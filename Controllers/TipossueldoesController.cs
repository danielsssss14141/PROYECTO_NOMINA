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
    public class TipossueldoesController : ControllerBase
    {
        private readonly NominaContext _context;

        public TipossueldoesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Tipossueldoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipossueldo>>> GetTipossueldos()
        {
          if (_context.Tipossueldos == null)
          {
              return NotFound();
          }
            return await _context.Tipossueldos.ToListAsync();
        }

        // GET: api/Tipossueldoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipossueldo>> GetTipossueldo(int id)
        {
          if (_context.Tipossueldos == null)
          {
              return NotFound();
          }
            var tipossueldo = await _context.Tipossueldos.FindAsync(id);

            if (tipossueldo == null)
            {
                return NotFound();
            }

            return tipossueldo;
        }

        // PUT: api/Tipossueldoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipossueldo(int id, Tipossueldo tipossueldo)
        {
            if (id != tipossueldo.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(tipossueldo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipossueldoExists(id))
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

        // POST: api/Tipossueldoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipossueldo>> PostTipossueldo(Tipossueldo tipossueldo)
        {
          if (_context.Tipossueldos == null)
          {
              return Problem("Entity set 'NominaContext.Tipossueldos'  is null.");
          }
            _context.Tipossueldos.Add(tipossueldo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipossueldo", new { id = tipossueldo.Secuencia }, tipossueldo);
        }

        // DELETE: api/Tipossueldoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipossueldo(int id)
        {
            if (_context.Tipossueldos == null)
            {
                return NotFound();
            }
            var tipossueldo = await _context.Tipossueldos.FindAsync(id);
            if (tipossueldo == null)
            {
                return NotFound();
            }

            _context.Tipossueldos.Remove(tipossueldo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipossueldoExists(int id)
        {
            return (_context.Tipossueldos?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
