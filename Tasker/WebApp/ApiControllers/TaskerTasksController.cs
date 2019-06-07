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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskerTasksController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TaskerTasksController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/TaskerTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.TaskerTask>>> GetTasks()
        {
            return (await _bll.Tasks.AllAsync())
                .Select(e => PublicApi.v1.Mappers.TaskerTaskMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/TaskerTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.TaskerTask>> GetTaskerTask(int id)
        {
            var taskerTask = PublicApi.v1.Mappers.TaskerTaskMapper.MapFromBLL(await _bll.Tasks.FindAllIncludedAsync(id));

            if (taskerTask == null)
            {
                return NotFound();
            }

            return taskerTask;
        }

        // PUT: api/TaskerTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskerTask(int id, PublicApi.v1.DTO.TaskerTask taskerTask)
        {
            if (id != taskerTask.Id)
            {
                return BadRequest();
            }

            _bll.Tasks.Update(PublicApi.v1.Mappers.TaskerTaskMapper.MapFromExternal(taskerTask));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/TaskerTasks
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.TaskerTask>> PostTaskerTask(PublicApi.v1.DTO.TaskerTask taskerTask)
        {
            _bll.Tasks.Add(PublicApi.v1.Mappers.TaskerTaskMapper.MapFromExternal(taskerTask));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTaskerTask", new { id = taskerTask.Id }, taskerTask);
        }

        // DELETE: api/TaskerTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTaskerTask(int id)
        {
            var taskerTask = await _bll.Tasks.FindAllIncludedAsync(id);
            if (taskerTask == null)
            {
                return NotFound();
            }

            _bll.Tasks.Remove(taskerTask);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
