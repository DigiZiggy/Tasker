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
    public class HourlyRatesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public HourlyRatesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/HourlyRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HourlyRateDTO>>> GetHourlyRates()
        {
//            var result = new List<HourlyRateDTO>();
//            var hourlyRates = await _uow.HourlyRates.AllAsync();
//            foreach (var hourlyRate in hourlyRates)
//            {
//                result.Add(new HourlyRateDTO()
//                {
//                    Id = hourlyRate.Id,
//                    HourRate = hourlyRate.HourRate,
//                    Start = hourlyRate.Start,
//                    End = hourlyRate.End
//                });   
//            }            
//            return Ok(result);
            return Ok(await _uow.HourlyRates.GetAllWithHourlyRateAsync());           
            
        }

        // GET: api/HourlyRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HourlyRate>> GetHourlyRate(int id)
        {
            var hourlyRate = await _uow.HourlyRates.FindAsync(id);

            if (hourlyRate == null)
            {
                return NotFound();
            }

            return hourlyRate;
        }

        // PUT: api/HourlyRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourlyRate(int id, HourlyRate hourlyRate)
        {
            if (id != hourlyRate.Id)
            {
                return BadRequest();
            }

            _uow.HourlyRates.Update(hourlyRate);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/HourlyRates
        [HttpPost]
        public async Task<ActionResult<HourlyRate>> PostHourlyRate(HourlyRate hourlyRate)
        {
            await _uow.HourlyRates.AddAsync(hourlyRate);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetHourlyRate", new { id = hourlyRate.Id }, hourlyRate);
        }

        // DELETE: api/HourlyRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HourlyRate>> DeleteHourlyRate(int id)
        {
            var hourlyRate = await _uow.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }

            _uow.HourlyRates.Remove(hourlyRate);
            await _uow.SaveChangesAsync();

            return hourlyRate;
        }
    }
}
