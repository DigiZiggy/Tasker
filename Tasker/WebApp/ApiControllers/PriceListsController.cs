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
    public class PriceListsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PriceListsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/PriceLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceList>>> GetPriceLists()
        {
            var result = await _uow.PriceLists.AllAsync();
            return Ok(result);
            
        }

        // GET: api/PriceLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceList>> GetPriceList(int id)
        {
            var priceList = await _uow.PriceLists.FindAsync(id);

            if (priceList == null)
            {
                return NotFound();
            }

            return priceList;
        }

        // PUT: api/PriceLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceList(int id, PriceList priceList)
        {
            if (id != priceList.Id)
            {
                return BadRequest();
            }

            _uow.PriceLists.Update(priceList);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/PriceLists
        [HttpPost]
        public async Task<ActionResult<PriceList>> PostPriceList(PriceList priceList)
        {
            await _uow.PriceLists.AddAsync(priceList);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPriceList", new { id = priceList.Id }, priceList);
        }

        // DELETE: api/PriceLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PriceList>> DeletePriceList(int id)
        {
            var priceList = await _uow.PriceLists.FindAsync(id);
            if (priceList == null)
            {
                return NotFound();
            }

            _uow.PriceLists.Remove(priceList);
            await _uow.SaveChangesAsync();

            return priceList;
        }
    }
}
