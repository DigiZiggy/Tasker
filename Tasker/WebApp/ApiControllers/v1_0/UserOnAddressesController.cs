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
    public class UserOnAddressesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserOnAddressesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get user on addresses
        /// </summary>
        /// <returns>Array of user on addresses</returns>
        // GET: api/UserOnAddresses
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.UserOnAddress>> GetUserOnAddresses()
        {
            return (await _bll.UserOnAddresses.AllAsync())
                .Select(e => PublicApi.v1.Mappers.UserOnAddressMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get user on address by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain user on address</returns>
        // GET: api/UserOnAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserOnAddress>> GetUserOnAddress(int id)
        {
            var userOnAddress = PublicApi.v1.Mappers.UserOnAddressMapper.MapFromBLL(await _bll.UserOnAddresses.FindAsync(id));

            if (userOnAddress == null)
            {
                return NotFound();
            }

            return userOnAddress;
        }

        /// <summary>
        /// Update user on address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userOnAddress"></param>
        /// <returns>No content</returns>
        // PUT: api/UserOnAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOnAddress(int id, PublicApi.v1.DTO.UserOnAddress userOnAddress)
        {
            if (id != userOnAddress.Id)
            {
                return BadRequest();
            }

            _bll.UserOnAddresses.Update(PublicApi.v1.Mappers.UserOnAddressMapper.MapFromExternal(userOnAddress));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post user on address
        /// </summary>
        /// <param name="userOnAddress"></param>
        /// <returns>User on address</returns>
        // POST: api/UserOnAddresses
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.UserOnAddress>> PostUserOnAddress(PublicApi.v1.DTO.UserOnAddress userOnAddress)
        {
            _bll.UserOnAddresses.Add(PublicApi.v1.Mappers.UserOnAddressMapper.MapFromExternal(userOnAddress));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUserOnAddress), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = userOnAddress.Id
                }, userOnAddress);
        }

        /// <summary>
        /// Delete user on address by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/UserOnAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserOnAddress>> DeleteUserOnAddress(int id)
        {
            _bll.UserOnAddresses.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
