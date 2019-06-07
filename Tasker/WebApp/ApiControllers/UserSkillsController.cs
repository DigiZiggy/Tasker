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
    public class UserSkillsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserSkillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.UserSkill>>> GetUserSkills()
        {
            return (await _bll.UserSkills.AllAsync())
                .Select(e => PublicApi.v1.Mappers.UserSkillMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/UserSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.UserSkill>> GetUserSkill(int id)
        {
            var userSkill = PublicApi.v1.Mappers.UserSkillMapper.MapFromBLL(await _bll.UserSkills.FindAllIncludedAsync(id));

            if (userSkill == null)
            {
                return NotFound();
            }

            return userSkill;
        }

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

        // POST: api/UserSkills
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.UserSkill>> PostUserSkill(PublicApi.v1.DTO.UserSkill userSkill)
        {
            _bll.UserSkills.Add(PublicApi.v1.Mappers.UserSkillMapper.MapFromExternal(userSkill));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserSkill", new { id = userSkill.Id }, userSkill);
        }

        // DELETE: api/UserSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserSkill(int id)
        {
            var userSkill = await _bll.UserSkills.FindAllIncludedAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }

            _bll.UserSkills.Remove(userSkill);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
