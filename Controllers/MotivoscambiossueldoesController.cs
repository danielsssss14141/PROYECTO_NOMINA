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
    public class MotivoscambiossueldoesController : ControllerBase
    {
        private readonly NominaContext _context;

        public MotivoscambiossueldoesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Motivoscambiossueldoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motivoscambiossueldo>>> GetMotivoscambiossueldos()
        {
          if (_context.Motivoscambiossueldos == null)
          {
              return NotFound();
          }
            return await _context.Motivoscambiossueldos.ToListAsync();
        }

        // GET: api/Motivoscambiossueldoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motivoscambiossueldo>> GetMotivoscambiossueldo(int id)
        {
          if (_context.Motivoscambiossueldos == null)
          {
              return NotFound();
          }
            var motivoscambiossueldo = await _context.Motivoscambiossueldos.FindAsync(id);

            if (motivoscambiossueldo == null)
            {
                return NotFound();
            }

            return motivoscambiossueldo;
        }

        // PUT: api/Motivoscambiossueldoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivoscambiossueldo(int id, Motivoscambiossueldo motivoscambiossueldo)
        {
            if (id != motivoscambiossueldo.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(motivoscambiossueldo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoscambiossueldoExists(id))
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

        // POST: api/Motivoscambiossueldoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Motivoscambiossueldo>> PostMotivoscambiossueldo(Motivoscambiossueldo motivoscambiossueldo)
        {
          if (_context.Motivoscambiossueldos == null)
          {
              return Problem("Entity set 'NominaContext.Motivoscambiossueldos'  is null.");
          }
            _context.Motivoscambiossueldos.Add(motivoscambiossueldo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivoscambiossueldo", new { id = motivoscambiossueldo.Secuencia }, motivoscambiossueldo);
        }

        // DELETE: api/Motivoscambiossueldoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivoscambiossueldo(int id)
        {
            if (_context.Motivoscambiossueldos == null)
            {
                return NotFound();
            }
            var motivoscambiossueldo = await _context.Motivoscambiossueldos.FindAsync(id);
            if (motivoscambiossueldo == null)
            {
                return NotFound();
            }

            _context.Motivoscambiossueldos.Remove(motivoscambiossueldo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotivoscambiossueldoExists(int id)
        {
            return (_context.Motivoscambiossueldos?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
