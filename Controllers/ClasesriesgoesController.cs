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
    public class ClasesriesgoesController : ControllerBase
    {
        private readonly NominaContext _context;

        public ClasesriesgoesController(NominaContext context)
        {
            _context = context;
        }

        // GET: api/Clasesriesgoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clasesriesgo>>> GetClasesriesgos()
        {
          if (_context.Clasesriesgos == null)
          {
              return NotFound();
          }
            return await _context.Clasesriesgos.ToListAsync();
        }

        // GET: api/Clasesriesgoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clasesriesgo>> GetClasesriesgo(int id)
        {
          if (_context.Clasesriesgos == null)
          {
              return NotFound();
          }
            var clasesriesgo = await _context.Clasesriesgos.FindAsync(id);

            if (clasesriesgo == null)
            {
                return NotFound();
            }

            return clasesriesgo;
        }

        // PUT: api/Clasesriesgoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasesriesgo(int id, Clasesriesgo clasesriesgo)
        {
            if (id != clasesriesgo.Secuencia)
            {
                return BadRequest();
            }

            _context.Entry(clasesriesgo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasesriesgoExists(id))
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

        // POST: api/Clasesriesgoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clasesriesgo>> PostClasesriesgo(Clasesriesgo clasesriesgo)
        {
          if (_context.Clasesriesgos == null)
          {
              return Problem("Entity set 'NominaContext.Clasesriesgos'  is null.");
          }
            _context.Clasesriesgos.Add(clasesriesgo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasesriesgo", new { id = clasesriesgo.Secuencia }, clasesriesgo);
        }

        // DELETE: api/Clasesriesgoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasesriesgo(int id)
        {
            if (_context.Clasesriesgos == null)
            {
                return NotFound();
            }
            var clasesriesgo = await _context.Clasesriesgos.FindAsync(id);
            if (clasesriesgo == null)
            {
                return NotFound();
            }

            _context.Clasesriesgos.Remove(clasesriesgo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasesriesgoExists(int id)
        {
            return (_context.Clasesriesgos?.Any(e => e.Secuencia == id)).GetValueOrDefault();
        }
    }
}
