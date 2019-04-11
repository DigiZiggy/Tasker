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
using DTO;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PaymentsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PaymentsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetPayments()
        {
            var result = new List<PaymentDTO>();
            var payments = await _uow.Payments.AllAsync();
            foreach (var payment in payments)
            {
                result.Add(new PaymentDTO()
                {
                    Id = payment.Id,
                    PaymentCode = payment.PaymentCode,
                    TimeOfPayment = payment.TimeOfPayment,
                    Total = payment.Total,
                    Comment = payment.Comment
                });   
            }
            return Ok(result);
            
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _uow.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            _uow.Payments.Update(payment);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            await _uow.Payments.AddAsync(payment);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {
            var payment = await _uow.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _uow.Payments.Remove(payment);
            await _uow.SaveChangesAsync();

            return payment;
        }
    }
}
