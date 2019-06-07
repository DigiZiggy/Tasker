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
    public class UserOnAddressesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserOnAddressesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserOnAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.UserOnAddress>>> GetUserOnAddresses()
        {
            return (await _bll.UserOnAddresses.AllAsync())
                .Select(e => PublicApi.v1.Mappers.UserOnAddressMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/UserOnAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserOnAddress>> GetUserOnAddress(int id)
        {
            var userOnAddress = PublicApi.v1.Mappers.UserOnAddressMapper.MapFromBLL(await _bll.UserOnAddresses.FindAllIncludedAsync(id));

            if (userOnAddress == null)
            {
                return NotFound();
            }

            return userOnAddress;
        }

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

        // POST: api/UserOnAddresses
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.UserOnAddress>> PostUserOnAddress(PublicApi.v1.DTO.UserOnAddress userOnAddress)
        {
            _bll.UserOnAddresses.Add(PublicApi.v1.Mappers.UserOnAddressMapper.MapFromExternal(userOnAddress));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserOnAddress", new { id = userOnAddress.Id }, userOnAddress);
        }

        // DELETE: api/UserOnAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserOnAddress(int id)
        {
            var userOnAddress = await _bll.UserOnAddresses.FindAllIncludedAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }

            _bll.UserOnAddresses.Remove(userOnAddress);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
