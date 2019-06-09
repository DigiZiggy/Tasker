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
    public class HourlyRatesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public HourlyRatesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get houlry rates
        /// </summary>
        /// <returns>Array of hourly rates</returns>
        // GET: api/HourlyRates
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.HourlyRate>> GetHourlyRates()
        {
            return (await _bll.HourlyRates.AllAsync())
                .Select(e => PublicApi.v1.Mappers.HourlyRateMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get hourly rate by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain hourly rate</returns>
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

        /// <summary>
        /// Update hourly rate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hourlyRate"></param>
        /// <returns>No Content</returns>
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

        /// <summary>
        /// Post hourly rate
        /// </summary>
        /// <param name="hourlyRate"></param>
        /// <returns>Hourly Rate</returns>
        // POST: api/HourlyRates
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.HourlyRate>> PostHourlyRate(PublicApi.v1.DTO.HourlyRate hourlyRate)
        {
            _bll.HourlyRates.Add(PublicApi.v1.Mappers.HourlyRateMapper.MapFromExternal(hourlyRate));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetHourlyRate), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = hourlyRate.Id
                }, hourlyRate);
        }

        /// <summary>
        /// Delete hourly rate by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/HourlyRates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.HourlyRate>> DeleteHourlyRate(int id)
        {
            _bll.HourlyRates.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
