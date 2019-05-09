using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UserTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetUserTasks()
        {
            return await _context.UserTasks.ToListAsync();
        }

        // GET: api/UserTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetUserTask(int id)
        {
            var userTask = await _context.UserTasks.FindAsync(id);

            if (userTask == null)
            {
                return NotFound();
            }

            return userTask;
        }

        // PUT: api/UserTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTask(int id, UserTask userTask)
        {
            if (id != userTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(userTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(id))
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

        // POST: api/UserTasks
        [HttpPost]
        public async Task<ActionResult<UserTask>> PostUserTask(UserTask userTask)
        {
            _context.UserTasks.Add(userTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTask", new { id = userTask.Id }, userTask);
        }

        // DELETE: api/UserTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTask>> DeleteUserTask(int id)
        {
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }

            _context.UserTasks.Remove(userTask);
            await _context.SaveChangesAsync();

            return userTask;
        }

        private bool UserTaskExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}
