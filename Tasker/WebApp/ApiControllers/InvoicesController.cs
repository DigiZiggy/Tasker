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
    public class InvoicesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public InvoicesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.Invoice>>> GetInvoices()
        {
            return await _bll.Invoices.AllAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Invoice>> GetInvoice(int id)
        {
            var invoice = await _bll.Invoices.FindAllIncludedAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, BLL.App.DTO.Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }
            
            _bll.Invoices.Update(invoice);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.Invoice>> PostInvoice(BLL.App.DTO.Invoice invoice)
        {
            await _bll.Invoices.AddAsync(invoice);
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
