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
    public class TasksController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public TasksController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Task>>> GetTasks()
        {
            var result = await _uow.Tasks.AllAsync();
            return Ok(result);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Task>> GetTask(int id)
        {
            var task = await _uow.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Domain.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _uow.Tasks.Update(task);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<Domain.Task>> PostTask(Domain.Task task)
        {
            await _uow.Tasks.AddAsync(task);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = task.Id }, task);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Domain.Task>> DeleteTask(int id)
        {
            var task = await _uow.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _uow.Tasks.Remove(task);
            await _uow.SaveChangesAsync();

            return task;
        }
    }
}
