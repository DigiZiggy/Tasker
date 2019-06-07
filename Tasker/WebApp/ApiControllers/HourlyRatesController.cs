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
    public class HourlyRatesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public HourlyRatesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/HourlyRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.HourlyRate>>> GetHourlyRates()
        {
            return (await _bll.HourlyRates.AllAsync())
                .Select(e => PublicApi.v1.Mappers.HourlyRateMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/HourlyRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.HourlyRate>> GetHourlyRate(int id)
        {
            var hourlyRate = PublicApi.v1.Mappers.HourlyRateMapper.MapFromBLL(await _bll.HourlyRates.FindAsync(id));

            if (hourlyRate == null)
            {
                return NotFound();
            }

            return hourlyRate;
        }

        // PUT: api/HourlyRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHourlyRate(int id, PublicApi.v1.DTO.HourlyRate hourlyRate)
        {
            if (id != hourlyRate.Id)
            {
                return BadRequest();
            }

            _bll.HourlyRates.Update(PublicApi.v1.Mappers.HourlyRateMapper.MapFromExternal(hourlyRate));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/HourlyRates
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.HourlyRate>> PostHourlyRate(PublicApi.v1.DTO.HourlyRate hourlyRate)
        {
            _bll.HourlyRates.Add(PublicApi.v1.Mappers.HourlyRateMapper.MapFromExternal(hourlyRate));
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
