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

    public class UserTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public UserTypesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserType>>> GetUserTypes()
        {
            var result = await _uow.UserTypes.AllAsync();
            return Ok(result);
        }

        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserType>> GetUserType(int id)
        {
            var userType = await _uow.UserTypes.FindAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return userType;
        }

        // PUT: api/UserTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserType(int id, UserType userType)
        {
            if (id != userType.Id)
            {
                return BadRequest();
            }

            _uow.UserTypes.Update(userType);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserTypes
        [HttpPost]
        public async Task<ActionResult<UserType>> PostUserType(UserType userType)
        {
            await _uow.UserTypes.AddAsync(userType);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetUserType", new { id = userType.Id }, userType);
        }

        // DELETE: api/UserTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserType>> DeleteUserType(int id)
        {
            var userType = await _uow.UserTypes.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }

            _uow.UserTypes.Remove(userType);
            await _uow.SaveChangesAsync();

            return userType;
        }
    }
}
