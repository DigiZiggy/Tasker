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
    public class UserTasksController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserTasksController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserTasks
        [HttpGet]
        public async Task<List<UserTask>> GetUserTasks()
        {
            return await _bll.UserTasks.AllAsync();
        }

        // GET: api/UserTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetUserTask(int id)
        {
            var userTask = await _bll.UserTasks.FindAllIncludedAsync(id);

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

            _bll.UserTasks.Update(userTask);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserTasks
        [HttpPost]
        public async Task<ActionResult<UserTask>> PostUserTask(UserTask userTask)
        {
            await _bll.UserTasks.AddAsync(userTask);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserTask", new { id = userTask.Id }, userTask);
        }

        // DELETE: api/UserTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserTask>> DeleteUserTask(int id)
        {
            var userTask = await _bll.UserTasks.FindAllIncludedAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }

            _bll.UserTasks.Remove(userTask);
            await _bll.SaveChangesAsync();

            return userTask;
        }
    }
}
