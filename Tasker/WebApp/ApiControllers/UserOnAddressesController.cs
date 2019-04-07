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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOnAddressesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public UserOnAddressesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/UserOnAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOnAddress>>> GetUserOnAddresses()
        {
            var result = await _uow.UserOnAddresses.AllAsync();
            return Ok(result);
            
        }

        // GET: api/UserOnAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOnAddress>> GetUserOnAddress(int id)
        {
            var userOnAddress = await _uow.UserOnAddresses.FindAsync(id);

            if (userOnAddress == null)
            {
                return NotFound();
            }

            return userOnAddress;
        }

        // PUT: api/UserOnAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOnAddress(int id, UserOnAddress userOnAddress)
        {
            if (id != userOnAddress.Id)
            {
                return BadRequest();
            }

            _uow.UserOnAddresses.Update(userOnAddress);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserOnAddresses
        [HttpPost]
        public async Task<ActionResult<UserOnAddress>> PostUserOnAddress(UserOnAddress userOnAddress)
        {
            await _uow.UserOnAddresses.AddAsync(userOnAddress);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetUserOnAddress", new { id = userOnAddress.Id }, userOnAddress);
        }

        // DELETE: api/UserOnAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserOnAddress>> DeleteUserOnAddress(int id)
        {
            var userOnAddress = await _uow.UserOnAddresses.FindAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }

            _uow.UserOnAddresses.Remove(userOnAddress);
            await _uow.SaveChangesAsync();

            return userOnAddress;
        }
    }
}
