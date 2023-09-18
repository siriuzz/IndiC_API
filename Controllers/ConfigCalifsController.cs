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
    public class ConfigCalifsController : ControllerBase
    {
        private readonly IndiCContext _context;

        public ConfigCalifsController(IndiCContext context)
        {
            _context = context;
        }

        // GET: api/ConfigCalifs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigCalif>>> GetConfigCalifs()
        {
          if (_context.ConfigCalifs == null)
          {
              return NotFound();
          }
            return await _context.ConfigCalifs.ToListAsync();
        }

        // GET: api/ConfigCalifs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigCalif>> GetConfigCalif(int id)
        {
          if (_context.ConfigCalifs == null)
          {
              return NotFound();
          }
            var configCalif = await _context.ConfigCalifs.FindAsync(id);

            if (configCalif == null)
            {
                return NotFound();
            }

            return configCalif;
        }

        // PUT: api/ConfigCalifs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigCalif(int id, ConfigCalif configCalif)
        {
            if (id != configCalif.IdConfig)
            {
                return BadRequest();
            }

            _context.Entry(configCalif).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigCalifExists(id))
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

        // POST: api/ConfigCalifs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfigCalif>> PostConfigCalif(ConfigCalif configCalif)
        {
          if (_context.ConfigCalifs == null)
          {
              return Problem("Entity set 'IndiCContext.ConfigCalifs'  is null.");
          }
            _context.ConfigCalifs.Add(configCalif);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigCalif", new { id = configCalif.IdConfig }, configCalif);
        }

        // DELETE: api/ConfigCalifs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfigCalif(int id)
        {
            if (_context.ConfigCalifs == null)
            {
                return NotFound();
            }
            var configCalif = await _context.ConfigCalifs.FindAsync(id);
            if (configCalif == null)
            {
                return NotFound();
            }

            _context.ConfigCalifs.Remove(configCalif);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConfigCalifExists(int id)
        {
            return (_context.ConfigCalifs?.Any(e => e.IdConfig == id)).GetValueOrDefault();
        }
    }
}
