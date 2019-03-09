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
    public class IdentificationTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IdentificationTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/IdentificationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificationType>>> GetIdentificationTypes()
        {
            return await _context.IdentificationTypes.ToListAsync();
        }

        // GET: api/IdentificationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentificationType>> GetIdentificationType(int id)
        {
            var identificationType = await _context.IdentificationTypes.FindAsync(id);

            if (identificationType == null)
            {
                return NotFound();
            }

            return identificationType;
        }

        // PUT: api/IdentificationTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentificationType(int id, IdentificationType identificationType)
        {
            if (id != identificationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(identificationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentificationTypeExists(id))
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

        // POST: api/IdentificationTypes
        [HttpPost]
        public async Task<ActionResult<IdentificationType>> PostIdentificationType(IdentificationType identificationType)
        {
            _context.IdentificationTypes.Add(identificationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdentificationType", new { id = identificationType.Id }, identificationType);
        }

        // DELETE: api/IdentificationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdentificationType>> DeleteIdentificationType(int id)
        {
            var identificationType = await _context.IdentificationTypes.FindAsync(id);
            if (identificationType == null)
            {
                return NotFound();
            }

            _context.IdentificationTypes.Remove(identificationType);
            await _context.SaveChangesAsync();

            return identificationType;
        }

        private bool IdentificationTypeExists(int id)
        {
            return _context.IdentificationTypes.Any(e => e.Id == id);
        }
    }
}
