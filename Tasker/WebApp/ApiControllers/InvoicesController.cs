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
    public class InvoicesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public InvoicesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Invoice>>> GetInvoices()
        {
            return (await _bll.Invoices.AllAsync())
                .Select(e => PublicApi.v1.Mappers.InvoiceMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Invoice>> GetInvoice(int id)
        {
            var invoice = PublicApi.v1.Mappers.InvoiceMapper.MapFromBLL(await _bll.Invoices.FindAllIncludedAsync(id));

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

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

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Invoice>> PostInvoice(PublicApi.v1.DTO.Invoice invoice)
        {
            _bll.Invoices.Add(PublicApi.v1.Mappers.InvoiceMapper.MapFromExternal(invoice));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.Id }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoice(int id)
        {
            var invoice = await _bll.Invoices.FindAllIncludedAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _bll.Invoices.Remove(invoice);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
