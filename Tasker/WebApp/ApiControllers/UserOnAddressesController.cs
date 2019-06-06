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
    public class UserOnAddressesController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserOnAddressesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserOnAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.UserOnAddress>>> GetUserOnAddresses()
        {
            return await _bll.UserOnAddresses.AllAsync();
        }

        // GET: api/UserOnAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.UserOnAddress>> GetUserOnAddress(int id)
        {
            var userOnAddress = await _bll.UserOnAddresses.FindAllIncludedAsync(id);

            if (userOnAddress == null)
            {
                return NotFound();
            }

            return userOnAddress;
        }

        // PUT: api/UserOnAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOnAddress(int id, BLL.App.DTO.UserOnAddress userOnAddress)
        {
            if (id != userOnAddress.Id)
            {
                return BadRequest();
            }

            _bll.UserOnAddresses.Update(userOnAddress);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserOnAddresses
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.UserOnAddress>> PostUserOnAddress(BLL.App.DTO.UserOnAddress userOnAddress)
        {
            await _bll.UserOnAddresses.AddAsync(userOnAddress);
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
