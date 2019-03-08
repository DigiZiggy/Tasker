using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOnAddressesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserOnAddressesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserOnAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOnAddress>>> GetUserOnAddresses()
        {
            return await _context.UserOnAddresses.ToListAsync();
        }

        // GET: api/UserOnAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOnAddress>> GetUserOnAddress(int id)
        {
            var userOnAddress = await _context.UserOnAddresses.FindAsync(id);

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

            _context.Entry(userOnAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOnAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserOnAddresses
        [HttpPost]
        public async Task<ActionResult<UserOnAddress>> PostUserOnAddress(UserOnAddress userOnAddress)
        {
            _context.UserOnAddresses.Add(userOnAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOnAddress", new { id = userOnAddress.Id }, userOnAddress);
        }

        // DELETE: api/UserOnAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserOnAddress>> DeleteUserOnAddress(int id)
        {
            var userOnAddress = await _context.UserOnAddresses.FindAsync(id);
            if (userOnAddress == null)
            {
                return NotFound();
            }

            _context.UserOnAddresses.Remove(userOnAddress);
            await _context.SaveChangesAsync();

            return userOnAddress;
        }

        private bool UserOnAddressExists(int id)
        {
            return _context.UserOnAddresses.Any(e => e.Id == id);
        }
    }
}
