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
    public class MotivoscambioscargoesController : ControllerBase
    {
        private readonly NominaContext _context;

        public MotivoscambioscargoesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Motivoscambioscargoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motivoscambioscargo>>> GetMotivoscambioscargos()
        {
          if (_context.Motivoscambioscargos == null)
          {
              return NotFound();
          }
            return await _context.Motivoscambioscargos.ToListAsync();
        }

        // GET: api/Motivoscambioscargoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Motivoscambioscargo>> GetMotivoscambioscargo(int id)
        {
          if (_context.Motivoscambioscargos == null)
          {
              return NotFound();
          }
            var motivoscambioscargo = await _context.Motivoscambioscargos.FindAsync(id);

            if (motivoscambioscargo == null)
            {
                return NotFound();
            }

            return motivoscambioscargo;
        }

        // PUT: api/Motivoscambioscargoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivoscambioscargo(int id, Motivoscambioscargo motivoscambioscargo)
        {
            if (id != motivoscambioscargo.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(motivoscambioscargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivoscambioscargoExists(id))
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

        // POST: api/Motivoscambioscargoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Motivoscambioscargo>> PostMotivoscambioscargo(Motivoscambioscargo motivoscambioscargo)
        {
          if (_context.Motivoscambioscargos == null)
          {
              return Problem("Entity set 'NominaContext.Motivoscambioscargos'  is null.");
          }
            _context.Motivoscambioscargos.Add(motivoscambioscargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivoscambioscargo", new { id = motivoscambioscargo.Secuencia }, motivoscambioscargo);
        }

        // DELETE: api/Motivoscambioscargoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivoscambioscargo(int id)
        {
            if (_context.Motivoscambioscargos == null)
            {
                return NotFound();
            }
            var motivoscambioscargo = await _context.Motivoscambioscargos.FindAsync(id);
            if (motivoscambioscargo == null)
            {
                return NotFound();
            }

            _context.Motivoscambioscargos.Remove(motivoscambioscargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotivoscambioscargoExists(int id)
        {
            return (_context.Motivoscambioscargos?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
