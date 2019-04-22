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

    public class IdentificationsController : ControllerBase
    {
        private readonly IAppUnitOfWork _uow;

        public IdentificationsController(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Identifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentificationDTO>>> GetIdentifications()
        {
//            var result = new List<IdentificationDTO>();
//            var identifications = await _uow.Identifications.AllAsync();
//            foreach (var identification in identifications)
//            {
//                result.Add(new IdentificationDTO()
//                {
//                    Id = identification.Id,
//                    DocumentNumber = identification.DocumentNumber,
//                    Start = identification.Start,
//                    End = identification.End
//                });   
//            }              
//            
//            return Ok(result); 
            return Ok(await _uow.Identifications.GetAllWithIdentificationAsync());           

        }

        // GET: api/Identifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Identification>> GetIdentification(int id)
        {
            var identification = await _uow.Identifications.FindAsync(id);

            if (identification == null)
            {
                return NotFound();
            }

            return identification;
        }

        // PUT: api/Identifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentification(int id, Identification identification)
        {
            if (id != identification.Id)
            {
                return BadRequest();
            }

            _uow.Identifications.Update(identification);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Identifications
        [HttpPost]
        public async Task<ActionResult<Identification>> PostIdentification(Identification identification)
        {
            await _uow.Identifications.AddAsync(identification);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetIdentification", new { id = identification.Id }, identification);
        }

        // DELETE: api/Identifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Identification>> DeleteIdentification(int id)
        {
            var identification = await _uow.Identifications.FindAsync(id);
            if (identification == null)
            {
                return NotFound();
            }

            _uow.Identifications.Remove(identification);
            await _uow.SaveChangesAsync();

            return identification;
        }
    }
}
