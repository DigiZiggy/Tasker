using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IdentificationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Identifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Identification>>> GetIdentifications()
        {
            return await _context.Identifications.ToListAsync();
        }

        // GET: api/Identifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Identification>> GetIdentification(int id)
        {
            var identification = await _context.Identifications.FindAsync(id);

            if (identification == null)
            {
                return NotFound();
            }

            return identification;
        }

        // PUT: api/Identifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentification(int id, Identification identification)
        {
            if (id != identification.Id)
            {
                return BadRequest();
            }

            _context.Entry(identification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentificationExists(id))
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

        // POST: api/Identifications
        [HttpPost]
        public async Task<ActionResult<Identification>> PostIdentification(Identification identification)
        {
            _context.Identifications.Add(identification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdentification", new { id = identification.Id }, identification);
        }

        // DELETE: api/Identifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Identification>> DeleteIdentification(int id)
        {
            var identification = await _context.Identifications.FindAsync(id);
            if (identification == null)
            {
                return NotFound();
            }

            _context.Identifications.Remove(identification);
            await _context.SaveChangesAsync();

            return identification;
        }

        private bool IdentificationExists(int id)
        {
            return _context.Identifications.Any(e => e.Id == id);
        }
    }
}
