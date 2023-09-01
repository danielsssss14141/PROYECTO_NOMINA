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
    public class EmpledoesController : ControllerBase
    {
        private readonly NominaContext _context;

        public EmpledoesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Empledoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empledo>>> GetEmpledos()
        {
          if (_context.Empledos == null)
          {
              return NotFound();
          }
            return await _context.Empledos.ToListAsync();
        }

        // GET: api/Empledoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empledo>> GetEmpledo(int id)
        {
          if (_context.Empledos == null)
          {
              return NotFound();
          }
            var empledo = await _context.Empledos.FindAsync(id);

            if (empledo == null)
            {
                return NotFound();
            }

            return empledo;
        }

        // PUT: api/Empledoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpledo(int id, Empledo empledo)
        {
            if (id != empledo.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(empledo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpledoExists(id))
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

        // POST: api/Empledoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empledo>> PostEmpledo(Empledo empledo)
        {
          if (_context.Empledos == null)
          {
              return Problem("Entity set 'NominaContext.Empledos'  is null.");
          }
            _context.Empledos.Add(empledo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpledo", new { id = empledo.Secuencia }, empledo);
        }

        // DELETE: api/Empledoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpledo(int id)
        {
            if (_context.Empledos == null)
            {
                return NotFound();
            }
            var empledo = await _context.Empledos.FindAsync(id);
            if (empledo == null)
            {
                return NotFound();
            }

            _context.Empledos.Remove(empledo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpledoExists(int id)
        {
            return (_context.Empledos?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
