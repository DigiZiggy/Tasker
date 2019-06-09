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
    public class UserSkillsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserSkillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get user skills
        /// </summary>
        /// <returns>Array of user skills</returns>
        // GET: api/UserSkills
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.UserSkill>> GetUserSkills()
        {
            return (await _bll.UserSkills.AllAsync())
                .Select(e => PublicApi.v1.Mappers.UserSkillMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get user skill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain user skill</returns>
        // GET: api/UserSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserSkill>> GetUserSkill(int id)
        {
            var userSkill = PublicApi.v1.Mappers.UserSkillMapper.MapFromBLL(await _bll.UserSkills.FindAsync(id));

            if (userSkill == null)
            {
                return NotFound();
            }

            return userSkill;
        }

        /// <summary>
        /// Update user skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userSkill"></param>
        /// <returns>No content</returns>
        // PUT: api/UserSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSkill(int id, PublicApi.v1.DTO.UserSkill userSkill)
        {
            if (id != userSkill.Id)
            {
                return BadRequest();
            }

            _bll.UserSkills.Update(PublicApi.v1.Mappers.UserSkillMapper.MapFromExternal(userSkill));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post user skill
        /// </summary>
        /// <param name="userSkill"></param>
        /// <returns>User skill</returns>
        // POST: api/UserSkills
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.UserSkill>> PostUserSkill(PublicApi.v1.DTO.UserSkill userSkill)
        {
            _bll.UserSkills.Add(PublicApi.v1.Mappers.UserSkillMapper.MapFromExternal(userSkill));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUserSkill), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = userSkill.Id
                }, userSkill);
        }

        /// <summary>
        /// Delete user skill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/UserSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserSkill>> DeleteUserSkill(int id)
        {
            _bll.UserSkills.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
