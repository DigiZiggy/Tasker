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
    public class UserSkillsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public UserSkillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserSkills
        [HttpGet]
        public async Task<List<UserSkill>> GetUserSkills()
        {
            return await _bll.UserSkills.AllAsync();
        }

        // GET: api/UserSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSkill>> GetUserSkill(int id)
        {
            var userSkill = await _bll.UserSkills.FindAllIncludedAsync(id);

            if (userSkill == null)
            {
                return NotFound();
            }

            return userSkill;
        }

        // PUT: api/UserSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSkill(int id, UserSkill userSkill)
        {
            if (id != userSkill.Id)
            {
                return BadRequest();
            }

            _bll.UserSkills.Update(userSkill);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserSkills
        [HttpPost]
        public async Task<ActionResult<UserSkill>> PostUserSkill(UserSkill userSkill)
        {
            await _bll.UserSkills.AddAsync(userSkill);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserSkill", new { id = userSkill.Id }, userSkill);
        }

        // DELETE: api/UserSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSkill>> DeleteUserSkill(int id)
        {
            var userSkill = await _bll.UserSkills.FindAllIncludedAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }

            _bll.UserSkills.Remove(userSkill);
            await _bll.SaveChangesAsync();

            return userSkill;
        }
    }
}
