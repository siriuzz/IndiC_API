using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndiC_API.Models;

namespace IndiC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteAsignaturasController : ControllerBase
    {
        private readonly IndiCContext _context;

        public EstudianteAsignaturasController(IndiCContext context)
        {
            _context = context;
        }

        // GET: api/EstudianteAsignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteAsignatura>>> GetEstudianteAsignaturas()
        {
          if (_context.EstudianteAsignaturas == null)
          {
              return NotFound();
          }
            return await _context.EstudianteAsignaturas.ToListAsync();
        }

        // GET: api/EstudianteAsignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteAsignatura>> GetEstudianteAsignatura(int id)
        {
          if (_context.EstudianteAsignaturas == null)
          {
              return NotFound();
          }
            var estudianteAsignatura = await _context.EstudianteAsignaturas.FindAsync(id);

            if (estudianteAsignatura == null)
            {
                return NotFound();
            }

            return estudianteAsignatura;
        }

        // PUT: api/EstudianteAsignaturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudianteAsignatura(int id, EstudianteAsignatura estudianteAsignatura)
        {
            if (id != estudianteAsignatura.IdEstudiante)
            {
                return BadRequest();
            }

            _context.Entry(estudianteAsignatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstudianteAsignaturaExists(id))
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

        // POST: api/EstudianteAsignaturas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstudianteAsignatura>> PostEstudianteAsignatura(EstudianteAsignatura estudianteAsignatura)
        {
          if (_context.EstudianteAsignaturas == null)
          {
              return Problem("Entity set 'IndiCContext.EstudianteAsignaturas'  is null.");
          }
            _context.EstudianteAsignaturas.Add(estudianteAsignatura);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstudianteAsignaturaExists(estudianteAsignatura.IdEstudiante))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstudianteAsignatura", new { id = estudianteAsignatura.IdEstudiante }, estudianteAsignatura);
        }

        // DELETE: api/EstudianteAsignaturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudianteAsignatura(int id)
        {
            if (_context.EstudianteAsignaturas == null)
            {
                return NotFound();
            }
            var estudianteAsignatura = await _context.EstudianteAsignaturas.FindAsync(id);
            if (estudianteAsignatura == null)
            {
                return NotFound();
            }

            _context.EstudianteAsignaturas.Remove(estudianteAsignatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteAsignaturaExists(int id)
        {
            return (_context.EstudianteAsignaturas?.Any(e => e.IdEstudiante == id)).GetValueOrDefault();
        }
    }
}
