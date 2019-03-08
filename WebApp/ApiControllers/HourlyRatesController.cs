using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourlyRatesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HourlyRatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HourlyRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HourlyRate>>> GetHourlyRates()
        {
            return await _context.HourlyRates.ToListAsync();
        }

        // GET: api/HourlyRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HourlyRate>> GetHourlyRate(int id)
        {
            var hourlyRate = await _context.HourlyRates.FindAsync(id);

            if (hourlyRate == null)
            {
                return NotFound();
            }

            return hourlyRate;
        }

        // PUT: api/HourlyRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourlyRate(int id, HourlyRate hourlyRate)
        {
            if (id != hourlyRate.Id)
            {
                return BadRequest();
            }

            _context.Entry(hourlyRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourlyRateExists(id))
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

        // POST: api/HourlyRates
        [HttpPost]
        public async Task<ActionResult<HourlyRate>> PostHourlyRate(HourlyRate hourlyRate)
        {
            _context.HourlyRates.Add(hourlyRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHourlyRate", new { id = hourlyRate.Id }, hourlyRate);
        }

        // DELETE: api/HourlyRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HourlyRate>> DeleteHourlyRate(int id)
        {
            var hourlyRate = await _context.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }

            _context.HourlyRates.Remove(hourlyRate);
            await _context.SaveChangesAsync();

            return hourlyRate;
        }

        private bool HourlyRateExists(int id)
        {
            return _context.HourlyRates.Any(e => e.Id == id);
        }
    }
}
