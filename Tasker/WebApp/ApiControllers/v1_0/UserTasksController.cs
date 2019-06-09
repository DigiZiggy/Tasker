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
    public class UserTasksController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserTasksController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get user tasks
        /// </summary>
        /// <returns>Array of user tasks</returns>
        // GET: api/UserTasks
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.UserTask>> GetUserTasks()
        {
            return (await _bll.UserTasks.AllAsync())
                .Select(e => PublicApi.v1.Mappers.UserTaskMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get user task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain user task</returns>
        // GET: api/UserTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserTask>> GetUserTask(int id)
        {
            var userTask = PublicApi.v1.Mappers.UserTaskMapper.MapFromBLL(await _bll.UserTasks.FindAsync(id));

            if (userTask == null)
            {
                return NotFound();
            }

            return userTask;
        }

        /// <summary>
        /// Update user task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userTask"></param>
        /// <returns>No content</returns>
        // PUT: api/UserTasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTask(int id, PublicApi.v1.DTO.UserTask userTask)
        {
            if (id != userTask.Id)
            {
                return BadRequest();
            }

            _bll.UserTasks.Update(PublicApi.v1.Mappers.UserTaskMapper.MapFromExternal(userTask));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post user task
        /// </summary>
        /// <param name="userTask"></param>
        /// <returns>User task</returns>
        // POST: api/UserTasks
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.UserTask>> PostUserTask(PublicApi.v1.DTO.UserTask userTask)
        {
            _bll.UserTasks.Add(PublicApi.v1.Mappers.UserTaskMapper.MapFromExternal(userTask));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUserTask), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = userTask.Id
                }, userTask);
        }

        /// <summary>
        /// Delete user task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/UserTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserTask>> DeleteUserTask(int id)
        {
            _bll.UserTasks.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
