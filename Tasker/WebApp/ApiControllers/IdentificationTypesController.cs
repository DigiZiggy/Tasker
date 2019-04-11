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

    public class IdentificationTypesController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public IdentificationTypesController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/IdentificationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificationType>>> GetIdentificationTypes()
        {
            var result = await _uow.IdentificationTypes.AllAsync();
            return Ok(result);
            
        }

        // GET: api/IdentificationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentificationType>> GetIdentificationType(int id)
        {
            var identificationType = await _uow.IdentificationTypes.FindAsync(id);

            if (identificationType == null)
            {
                return NotFound();
            }

            return identificationType;
        }

        // PUT: api/IdentificationTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentificationType(int id, IdentificationType identificationType)
        {
            if (id != identificationType.Id)
            {
                return BadRequest();
            }

            _uow.IdentificationTypes.Update(identificationType);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/IdentificationTypes
        [HttpPost]
        public async Task<ActionResult<IdentificationType>> PostIdentificationType(IdentificationType identificationType)
        {
            await _uow.IdentificationTypes.AddAsync(identificationType);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetIdentificationType", new { id = identificationType.Id }, identificationType);
        }

        // DELETE: api/IdentificationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdentificationType>> DeleteIdentificationType(int id)
        {
            var identificationType = await _uow.IdentificationTypes.FindAsync(id);
            if (identificationType == null)
            {
                return NotFound();
            }

            _uow.IdentificationTypes.Remove(identificationType);
            await _uow.SaveChangesAsync();

            return identificationType;
        }
    }
}
