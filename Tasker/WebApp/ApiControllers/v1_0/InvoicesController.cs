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
    public class InvoicesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public InvoicesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get invoices
        /// </summary>
        /// <returns>Array of invoices</returns>
        // GET: api/Invoices
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.Invoice>> GetInvoices()
        {
            return (await _bll.Invoices.AllAsync())
                .Select(e => PublicApi.v1.Mappers.InvoiceMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get invoice by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain invoice</returns>
        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Invoice>> GetInvoice(int id)
        {
            var invoice = PublicApi.v1.Mappers.InvoiceMapper.MapFromBLL(await _bll.Invoices.FindAsync(id));

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        /// <summary>
        /// Update invoice
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoice"></param>
        /// <returns>No content</returns>
        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, PublicApi.v1.DTO.Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }
            
            _bll.Invoices.Update(PublicApi.v1.Mappers.InvoiceMapper.MapFromExternal(invoice));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post invoice
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns>Invoice</returns>
        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Invoice>> PostInvoice(PublicApi.v1.DTO.Invoice invoice)
        {
            _bll.Invoices.Add(PublicApi.v1.Mappers.InvoiceMapper.MapFromExternal(invoice));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetInvoice), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = invoice.Id
                }, invoice);
        }

        /// <summary>
        /// Delete invoice by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Invoice>> DeleteInvoice(int id)
        {
            _bll.Invoices.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
