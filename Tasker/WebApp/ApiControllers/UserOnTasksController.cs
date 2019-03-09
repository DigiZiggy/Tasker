using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOnTasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserOnTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserOnTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOnTask>>> GetUserOnTasks()
        {
            return await _context.UserOnTasks.ToListAsync();
        }

        // GET: api/UserOnTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOnTask>> GetUserOnTask(int id)
        {
            var userOnTask = await _context.UserOnTasks.FindAsync(id);

            if (userOnTask == null)
            {
                return NotFound();
            }

            return userOnTask;
        }

        // PUT: api/UserOnTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOnTask(int id, UserOnTask userOnTask)
        {
            if (id != userOnTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(userOnTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOnTaskExists(id))
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

        // POST: api/UserOnTasks
        [HttpPost]
        public async Task<ActionResult<UserOnTask>> PostUserOnTask(UserOnTask userOnTask)
        {
            _context.UserOnTasks.Add(userOnTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOnTask", new { id = userOnTask.Id }, userOnTask);
        }

        // DELETE: api/UserOnTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserOnTask>> DeleteUserOnTask(int id)
        {
            var userOnTask = await _context.UserOnTasks.FindAsync(id);
            if (userOnTask == null)
            {
                return NotFound();
            }

            _context.UserOnTasks.Remove(userOnTask);
            await _context.SaveChangesAsync();

            return userOnTask;
        }

        private bool UserOnTaskExists(int id)
        {
            return _context.UserOnTasks.Any(e => e.Id == id);
        }
    }
}
