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
    public class AddressesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AddressesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Address>>> GetAddresses()
        {
            return (await _bll.Addresses.AllAsync())
                .Select(e => PublicApi.v1.Mappers.AddressMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Address>> GetAddress(int id)
        {
            var address = PublicApi.v1.Mappers.AddressMapper.MapFromBLL(await _bll.Addresses.FindAsync(id));

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, PublicApi.v1.DTO.Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _bll.Addresses.Update(PublicApi.v1.Mappers.AddressMapper.MapFromExternal(address));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Address>> PostAddress(PublicApi.v1.DTO.Address address)
        {
            _bll.Addresses.Add(PublicApi.v1.Mappers.AddressMapper.MapFromExternal(address));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            var address = await _bll.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _bll.Addresses.Remove(address);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
