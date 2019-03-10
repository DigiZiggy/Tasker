using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeansOfPaymentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MeansOfPaymentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MeansOfPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeansOfPayment>>> GetMeansOfPayments()
        {
            return await _context.MeansOfPayments.ToListAsync();
        }

        // GET: api/MeansOfPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeansOfPayment>> GetMeansOfPayment(int id)
        {
            var meansOfPayment = await _context.MeansOfPayments.FindAsync(id);

            if (meansOfPayment == null)
            {
                return NotFound();
            }

            return meansOfPayment;
        }

        // PUT: api/MeansOfPayments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeansOfPayment(int id, MeansOfPayment meansOfPayment)
        {
            if (id != meansOfPayment.Id)
            {
                return BadRequest();
            }

            _context.Entry(meansOfPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeansOfPaymentExists(id))
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

        // POST: api/MeansOfPayments
        [HttpPost]
        public async Task<ActionResult<MeansOfPayment>> PostMeansOfPayment(MeansOfPayment meansOfPayment)
        {
            _context.MeansOfPayments.Add(meansOfPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeansOfPayment", new { id = meansOfPayment.Id }, meansOfPayment);
        }

        // DELETE: api/MeansOfPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeansOfPayment>> DeleteMeansOfPayment(int id)
        {
            var meansOfPayment = await _context.MeansOfPayments.FindAsync(id);
            if (meansOfPayment == null)
            {
                return NotFound();
            }

            _context.MeansOfPayments.Remove(meansOfPayment);
            await _context.SaveChangesAsync();

            return meansOfPayment;
        }

        private bool MeansOfPaymentExists(int id)
        {
            return _context.MeansOfPayments.Any(e => e.Id == id);
        }
    }
}
