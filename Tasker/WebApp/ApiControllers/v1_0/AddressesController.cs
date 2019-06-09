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
    public class AddressesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public AddressesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get Addresses
        /// </summary>
        /// <returns>Array of Addresses</returns>
        // GET: api/Addresses
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.Address>> GetAddresses()
        {
            return (await _bll.Addresses.AllAsync())
                .Select(e => PublicApi.v1.Mappers.AddressMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get address by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>certain address</returns>
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

        /// <summary>
        /// Update Address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns>No Content</returns>
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

        /// <summary>
        /// Post address
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Address</returns>
        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Address>> PostAddress(PublicApi.v1.DTO.Address address)
        {
            _bll.Addresses.Add(PublicApi.v1.Mappers.AddressMapper.MapFromExternal(address));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAddress), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = address.Id
                }, address);
        }

        /// <summary>
        /// Delete address by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Address>> DeleteAddress(int id)
        {
            _bll.Addresses.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
