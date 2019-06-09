using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get payment
        /// </summary>
        /// <returns>Array of payments</returns>
        // GET: api/Payments
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.Payment>> GetPayments()
        {
            return (await _bll.Payments.AllAsync())
                .Select(e => PublicApi.v1.Mappers.PaymentMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get payment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain payment</returns>
        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Payment>> GetPayment(int id)
        {
            var payment = PublicApi.v1.Mappers.PaymentMapper.MapFromBLL(await _bll.Payments.FindAsync(id));

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        /// <summary>
        /// Update payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payment"></param>
        /// <returns>No content</returns>
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

        /// <summary>
        /// Post payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>Payment</returns>
        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Payment>> PostPayment(PublicApi.v1.DTO.Payment payment)
        {
            _bll.Payments.Add(PublicApi.v1.Mappers.PaymentMapper.MapFromExternal(payment));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPayment), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = payment.Id
                }, payment);
        }

        /// <summary>
        /// Delete payment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Payment>> DeletePayment(int id)
        {
            _bll.Payments.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
