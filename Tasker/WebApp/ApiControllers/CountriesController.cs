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
using DTO;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CountriesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CountriesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountries()
        {
            var result = new List<CountryDTO>();
            var countries = await _uow.Countries.AllAsync();
            foreach (var country in countries)
            {
                result.Add(new CountryDTO()
                {
                    Id = country.Id,
                    Name = country.Name,
                    CountryCode = country.CountryCode
                });   
            }

            return Ok(result);          
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _uow.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _uow.Countries.Update(country);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            await _uow.Countries.AddAsync(country);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var country = await _uow.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _uow.Countries.Remove(country);
            await _uow.SaveChangesAsync();

            return country;
        }
    }
}
