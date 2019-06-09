using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TaskerTasksController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public TaskerTasksController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get tasks
        /// </summary>
        /// <returns>Array of tasks</returns>
        // GET: api/TaskerTasks
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.TaskerTask>> GetTasks()
        {
            return (await _bll.Tasks.AllAsync())
                .Select(e => PublicApi.v1.Mappers.TaskerTaskMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain task</returns>
        // GET: api/TaskerTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.TaskerTask>> GetTaskerTask(int id)
        {
            var taskerTask = PublicApi.v1.Mappers.TaskerTaskMapper.MapFromBLL(await _bll.Tasks.FindAsync(id));

            if (taskerTask == null)
            {
                return NotFound();
            }

            return taskerTask;
        }

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskerTask"></param>
        /// <returns>No content</returns>
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

        /// <summary>
        /// Post task
        /// </summary>
        /// <param name="taskerTask"></param>
        /// <returns>Task</returns>
        // POST: api/TaskerTasks
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.TaskerTask>> PostTaskerTask(PublicApi.v1.DTO.TaskerTask taskerTask)
        {
            _bll.Tasks.Add(PublicApi.v1.Mappers.TaskerTaskMapper.MapFromExternal(taskerTask));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTaskerTask), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = taskerTask.Id
                }, taskerTask);
        }

        /// <summary>
        /// Delete task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/TaskerTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.TaskerTask>> DeleteTaskerTask(int id)
        {
            _bll.Tasks.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
