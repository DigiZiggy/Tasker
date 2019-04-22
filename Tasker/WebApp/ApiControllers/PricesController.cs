using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
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

    public class PricesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public PricesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceDTO>>> GetPrices()
        {
//            var result = new List<PriceDTO>();
//            var prices = await _uow.Prices.AllAsync();
//            foreach (var price in prices)
//            {
//                result.Add(new PriceDTO()
//                {
//                    Id = price.Id,
//                    Amount = price.Amount,
//                    Start = price.Start,
//                    End = price.End,
//                    Comment = price.Comment
//                });   
//            }
//            return Ok(result);
            return Ok(await _uow.Prices.GetAllWithPriceAsync());           
            
        }

        // GET: api/Prices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Price>> GetPrice(int id)
        {
            var price = await _uow.Prices.FindAsync(id);

            if (price == null)
            {
                return NotFound();
            }

            return price;
        }

        // PUT: api/Prices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrice(int id, Price price)
        {
            if (id != price.Id)
            {
                return BadRequest();
            }

            _uow.Prices.Update(price);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Prices
        [HttpPost]
        public async Task<ActionResult<Price>> PostPrice(Price price)
        {
            await _uow.Prices.AddAsync(price);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetPrice", new { id = price.Id }, price);
        }

        // DELETE: api/Prices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Price>> DeletePrice(int id)
        {
            var price = await _uow.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            _uow.Prices.Remove(price);
            await _uow.SaveChangesAsync();

            return price;
        }
    }
}
