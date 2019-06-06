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
    public class HourlyRatesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public HourlyRatesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/HourlyRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.HourlyRate>>> GetHourlyRates()
        {
            return await _bll.HourlyRates.AllAsync();
        }

        // GET: api/HourlyRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.HourlyRate>> GetHourlyRate(int id)
        {
            var hourlyRate = await _bll.HourlyRates.FindAsync(id);

            if (hourlyRate == null)
            {
                return NotFound();
            }

            return hourlyRate;
        }

        // PUT: api/HourlyRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourlyRate(int id, BLL.App.DTO.HourlyRate hourlyRate)
        {
            if (id != hourlyRate.Id)
            {
                return BadRequest();
            }

            _bll.HourlyRates.Update(hourlyRate);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/HourlyRates
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.HourlyRate>> PostHourlyRate(BLL.App.DTO.HourlyRate hourlyRate)
        {
            await _bll.HourlyRates.AddAsync(hourlyRate);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetHourlyRate", new { id = hourlyRate.Id }, hourlyRate);
        }

        // DELETE: api/HourlyRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHourlyRate(int id)
        {
            var hourlyRate = await _bll.HourlyRates.FindAsync(id);
            if (hourlyRate == null)
            {
                return NotFound();
            }

            _bll.HourlyRates.Remove(hourlyRate);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
