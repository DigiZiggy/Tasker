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
    public class TaskerTasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TaskerTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskerTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskerTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/TaskerTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskerTask>> GetTaskerTask(int id)
        {
            var taskerTask = await _context.Tasks.FindAsync(id);

            if (taskerTask == null)
            {
                return NotFound();
            }

            return taskerTask;
        }

        // PUT: api/TaskerTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskerTask(int id, TaskerTask taskerTask)
        {
            if (id != taskerTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskerTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskerTaskExists(id))
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

        // POST: api/TaskerTasks
        [HttpPost]
        public async Task<ActionResult<TaskerTask>> PostTaskerTask(TaskerTask taskerTask)
        {
            _context.Tasks.Add(taskerTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskerTask", new { id = taskerTask.Id }, taskerTask);
        }

        // DELETE: api/TaskerTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskerTask>> DeleteTaskerTask(int id)
        {
            var taskerTask = await _context.Tasks.FindAsync(id);
            if (taskerTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskerTask);
            await _context.SaveChangesAsync();

            return taskerTask;
        }

        private bool TaskerTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
