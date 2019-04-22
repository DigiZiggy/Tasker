using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
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
        private readonly IAppUnitOfWork _uow;

        public UserSkillsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/UserSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSkillDTO>>> GetUserSkills()
        {
//            var result = new List<UserSkillDTO>();
//            var userSkills = await _uow.UserSills.AllAsync();
//            foreach (var userSkill in userSkills)
//            {
//                result.Add(new UserSkillDTO()
//                {
//                    Id = userSkill.Id,
//                    Name = userSkill.Name,
//                    Start = userSkill.Start,
//                    End = userSkill.End,
//                    Comment = userSkill.Comment
//                });   
//            }
//            
//            return Ok(result); 
            return Ok(await _uow.UserSills.GetAllWithUserSkillAsync());           

        }

        // GET: api/UserSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSkill>> GetUserSkill(int id)
        {
            var userSkill = await _uow.UserSills.FindAsync(id);

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

            _uow.UserSills.Update(userSkill);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserSkills
        [HttpPost]
        public async Task<ActionResult<UserSkill>> PostUserSkill(UserSkill userSkill)
        {
            await _uow.UserSills.AddAsync(userSkill);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetUserSkill", new { id = userSkill.Id }, userSkill);
        }

        // DELETE: api/UserSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSkill>> DeleteUserSkill(int id)
        {
            var userSkill = await _uow.UserSills.FindAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }

            _uow.UserSills.Remove(userSkill);
            await _uow.SaveChangesAsync();

            return userSkill;
        }
    }
}
