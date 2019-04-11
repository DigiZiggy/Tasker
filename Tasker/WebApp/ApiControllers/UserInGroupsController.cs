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

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UserInGroupsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public UserInGroupsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/UserInGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInGroup>>> GetUserInGroups()
        {
            var result = await _uow.UserInGroups.AllAsync();
            return Ok(result);
            
        }

        // GET: api/UserInGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInGroup>> GetUserInGroup(int id)
        {
            var userInGroup = await _uow.UserInGroups.FindAsync(id);

            if (userInGroup == null)
            {
                return NotFound();
            }

            return userInGroup;
        }

        // PUT: api/UserInGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInGroup(int id, UserInGroup userInGroup)
        {
            if (id != userInGroup.Id)
            {
                return BadRequest();
            }

            _uow.UserInGroups.Update(userInGroup);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserInGroups
        [HttpPost]
        public async Task<ActionResult<UserInGroup>> PostUserInGroup(UserInGroup userInGroup)
        {
            await _uow.UserInGroups.AddAsync(userInGroup);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetUserInGroup", new { id = userInGroup.Id }, userInGroup);
        }

        // DELETE: api/UserInGroups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInGroup>> DeleteUserInGroup(int id)
        {
            var userInGroup = await _uow.UserInGroups.FindAsync(id);
            if (userInGroup == null)
            {
                return NotFound();
            }

            _uow.UserInGroups.Remove(userInGroup);
            await _uow.SaveChangesAsync();

            return userInGroup;
        }
    }
}
