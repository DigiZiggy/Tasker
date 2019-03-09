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
    public class UserInGroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserInGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserInGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInGroup>>> GetUserInGroups()
        {
            return await _context.UserInGroups.ToListAsync();
        }

        // GET: api/UserInGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInGroup>> GetUserInGroup(int id)
        {
            var userInGroup = await _context.UserInGroups.FindAsync(id);

            if (userInGroup == null)
            {
                return NotFound();
            }

            return userInGroup;
        }

        // PUT: api/UserInGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInGroup(int id, UserInGroup userInGroup)
        {
            if (id != userInGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInGroupExists(id))
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

        // POST: api/UserInGroups
        [HttpPost]
        public async Task<ActionResult<UserInGroup>> PostUserInGroup(UserInGroup userInGroup)
        {
            _context.UserInGroups.Add(userInGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInGroup", new { id = userInGroup.Id }, userInGroup);
        }

        // DELETE: api/UserInGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInGroup>> DeleteUserInGroup(int id)
        {
            var userInGroup = await _context.UserInGroups.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }

            _context.UserInGroups.Remove(userInGroup);
            await _context.SaveChangesAsync();

            return userInGroup;
        }

        private bool UserInGroupExists(int id)
        {
            return _context.UserInGroups.Any(e => e.Id == id);
        }
    }
}
