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
    public class TaskTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public TaskTypesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/TaskTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskType>>> GetTaskTypes()
        {
            var result = await _uow.TaskTypes.AllAsync();
            return Ok(result);
            
        }

        // GET: api/TaskTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskType>> GetTaskType(int id)
        {
            var taskType = await _uow.TaskTypes.FindAsync(id);

            if (taskType == null)
            {
                return NotFound();
            }

            return taskType;
        }

        // PUT: api/TaskTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskType(int id, TaskType taskType)
        {
            if (id != taskType.Id)
            {
                return BadRequest();
            }

            _uow.TaskTypes.Update(taskType);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/TaskTypes
        [HttpPost]
        public async Task<ActionResult<TaskType>> PostTaskType(TaskType taskType)
        {
            await _uow.TaskTypes.AddAsync(taskType);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetTaskType", new { id = taskType.Id }, taskType);
        }

        // DELETE: api/TaskTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskType>> DeleteTaskType(int id)
        {
            var taskType = await _uow.TaskTypes.FindAsync(id);
            if (taskType == null)
            {
                return NotFound();
            }

            _uow.TaskTypes.Remove(taskType);
            await _uow.SaveChangesAsync();

            return taskType;
        }
    }
}
