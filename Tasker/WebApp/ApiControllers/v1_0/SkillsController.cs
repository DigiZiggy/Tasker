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
    public class SkillsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SkillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get skills
        /// </summary>
        /// <returns>Array of skills</returns>
        // GET: api/Skills
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.Skill>> GetSkills()
        {
            return (await _bll.Skills.AllAsync())
                .Select(e => PublicApi.v1.Mappers.SkillMapper.MapFromBLL(e)).ToList();
        }

        /// <summary>
        /// Get skill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain skill</returns>
        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Skill>> GetSkill(int id)
        {
            var skill = PublicApi.v1.Mappers.SkillMapper.MapFromBLL(await _bll.Skills.FindAsync(id));

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        /// <summary>
        /// Update skill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skill"></param>
        /// <returns>No content</returns>
        // PUT: api/Skills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, PublicApi.v1.DTO.Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _bll.Skills.Update(PublicApi.v1.Mappers.SkillMapper.MapFromExternal(skill));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post skill
        /// </summary>
        /// <param name="skill"></param>
        /// <returns>Skill</returns>
        // POST: api/Skills
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Skill>> PostSkill(PublicApi.v1.DTO.Skill skill)
        {
            _bll.Skills.Add(PublicApi.v1.Mappers.SkillMapper.MapFromExternal(skill));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetSkill), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = skill.Id
                }, skill);
        }

        /// <summary>
        /// Delete skill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Skill>> DeleteSkill(int id)
        {
            _bll.Skills.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
