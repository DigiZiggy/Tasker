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
    public class SkillsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public SkillsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BLL.App.DTO.Skill>>> GetSkills()
        {
            return await _bll.Skills.AllAsync();
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BLL.App.DTO.Skill>> GetSkill(int id)
        {
            var skill = await _bll.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // PUT: api/Skills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, BLL.App.DTO.Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _bll.Skills.Update(skill);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Skills
        [HttpPost]
        public async Task<ActionResult<BLL.App.DTO.Skill>> PostSkill(BLL.App.DTO.Skill skill)
        {
            await _bll.Skills.AddAsync(skill);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSkill(int id)
        {
            var skill = await _bll.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _bll.Skills.Remove(skill);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
