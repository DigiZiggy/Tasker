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

    public class CitiesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public CitiesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCities()
        {
            var result = new List<CityDTO>();
            var cities = await _uow.Cities.AllAsync();
            foreach (var city in cities)
            {
                result.Add(new CityDTO()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Comment = city.Comment
                });   
            }

            return Ok(result);             
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await _uow.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            _uow.Cities.Update(city);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            await _uow.Cities.AddAsync(city);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            var city = await _uow.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _uow.Cities.Remove(city);
            await _uow.SaveChangesAsync();

            return city;
        }
    }
}
