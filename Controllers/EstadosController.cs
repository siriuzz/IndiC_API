﻿using System;
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
    public class EstadosController : ControllerBase
    {
        private readonly IndiCContext _context;

        public EstadosController(IndiCContext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
          if (_context.Estados == null)
          {
              return NotFound();
          }
            return await _context.Estados.ToListAsync();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
          if (_context.Estados == null)
          {
              return NotFound();
          }
            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado estado)
        {
            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estado)
        {
          if (_context.Estados == null)
          {
              return Problem("Entity set 'IndiCContext.Estados'  is null.");
          }
            _context.Estados.Add(estado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadoExists(estado.IdEstado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstado", new { id = estado.IdEstado }, estado);
        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            if (_context.Estados == null)
            {
                return NotFound();
            }
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return (_context.Estados?.Any(e => e.IdEstado == id)).GetValueOrDefault();
        }
    }
}
