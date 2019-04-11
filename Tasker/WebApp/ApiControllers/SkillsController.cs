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
using DTO;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class SkillsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public SkillsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDTO>>> GetSkills()
        {
            var result = new List<SkillDTO>();
            var skills = await _uow.Skills.AllAsync();
            foreach (var skill in skills)
            {
                result.Add(new SkillDTO()
                {
                    Id = skill.Id,
                    Name = skill.Name,
                    Description = skill.Description,
                    Comment = skill.Comment
                });   
            }   
            return Ok(result);
            
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var skill = await _uow.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // PUT: api/Skills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _uow.Skills.Update(skill);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Skills
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            await _uow.Skills.AddAsync(skill);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Skill>> DeleteSkill(int id)
        {
            var skill = await _uow.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _uow.Skills.Remove(skill);
            await _uow.SaveChangesAsync();

            return skill;
        }
    }
}
