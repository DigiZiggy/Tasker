using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Payment>>> GetPayments()
        {
            return (await _bll.Payments.AllAsync())
                .Select(e => PublicApi.v1.Mappers.PaymentMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Payment>> GetPayment(int id)
        {
            var payment = PublicApi.v1.Mappers.PaymentMapper.MapFromBLL(await _bll.Payments.FindAllIncludedAsync(id));

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, PublicApi.v1.DTO.Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }
            
            _bll.Payments.Update(PublicApi.v1.Mappers.PaymentMapper.MapFromExternal(payment));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Payment>> PostPayment(PublicApi.v1.DTO.Payment payment)
        {
            _bll.Payments.Add(PublicApi.v1.Mappers.PaymentMapper.MapFromExternal(payment));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(int id)
        {
            var payment = await _bll.Payments.FindAllIncludedAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _bll.Payments.Remove(payment);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
