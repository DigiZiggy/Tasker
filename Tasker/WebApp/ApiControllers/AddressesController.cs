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

    public class AddressesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public AddressesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddresses()
        {
//            var result = new List<AddressDTO>();
//            var addresses = await _uow.Addresses.AllAsync();
//            foreach (var address in addresses)
//            {
//                result.Add(new AddressDTO()
//                {
//                    Id = address.Id,
//                    Street = address.Street,
//                    District = address.District,
//                    PostalCode = address.PostalCode
//                });   
//            }
//
//            return Ok(result);
            return Ok(await _uow.Addresses.GetAllWithAddressAsync());           
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _uow.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {           
            if (id != address.Id)
            {
                return BadRequest();
            }

            _uow.Addresses.Update(address);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            await _uow.Addresses.AddAsync(address);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _uow.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _uow.Addresses.Remove(address);
            await _uow.SaveChangesAsync();

            return address;
        }
    }
}
