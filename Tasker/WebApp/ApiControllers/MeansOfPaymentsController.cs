using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
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
        private readonly IAppUnitOfWork _uow;

        public MeansOfPaymentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/MeansOfPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeansOfPayment>>> GetMeansOfPayments()
        {
            var result = await _uow.MeansOfPayments.AllAsync();
            return Ok(result);
            
        }

        // GET: api/MeansOfPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeansOfPayment>> GetMeansOfPayment(int id)
        {
            var meansOfPayment = await _uow.MeansOfPayments.FindAsync(id);

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

            _uow.MeansOfPayments.Update(meansOfPayment);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/MeansOfPayments
        [HttpPost]
        public async Task<ActionResult<MeansOfPayment>> PostMeansOfPayment(MeansOfPayment meansOfPayment)
        {
            await _uow.MeansOfPayments.AddAsync(meansOfPayment);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetMeansOfPayment", new { id = meansOfPayment.Id }, meansOfPayment);
        }

        // DELETE: api/MeansOfPayments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MeansOfPayment>> DeleteMeansOfPayment(int id)
        {
            var meansOfPayment = await _uow.MeansOfPayments.FindAsync(id);
            if (meansOfPayment == null)
            {
                return NotFound();
            }

            _uow.MeansOfPayments.Remove(meansOfPayment);
            await _uow.SaveChangesAsync();

            return meansOfPayment;
        }
    }
}
