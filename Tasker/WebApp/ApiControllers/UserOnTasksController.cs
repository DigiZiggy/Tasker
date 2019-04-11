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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UserOnTasksController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public UserOnTasksController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/UserOnTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOnTask>>> GetUserOnTasks()
        {
            var result = await _uow.UserOnTasks.AllAsync();
            return Ok(result);
            
        }

        // GET: api/UserOnTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOnTask>> GetUserOnTask(int id)
        {
            var userOnTask = await _uow.UserOnTasks.FindAsync(id);

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

            _uow.UserOnTasks.Update(userOnTask);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserOnTasks
        [HttpPost]
        public async Task<ActionResult<UserOnTask>> PostUserOnTask(UserOnTask userOnTask)
        {
            await _uow.UserOnTasks.AddAsync(userOnTask);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetUserOnTask", new { id = userOnTask.Id }, userOnTask);
        }

        // DELETE: api/UserOnTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserOnTask>> DeleteUserOnTask(int id)
        {
            var userOnTask = await _uow.UserOnTasks.FindAsync(id);
            if (userOnTask == null)
            {
                return NotFound();
            }

            _uow.UserOnTasks.Remove(userOnTask);
            await _uow.SaveChangesAsync();

            return userOnTask;
        }
    }
}
