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
    public class IdentificationsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public IdentificationsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Identifications
        [HttpGet]
        public async Task<List<Identification>> GetIdentifications()
        {
            return await _bll.Identifications.AllAsync();
        }

        // GET: api/Identifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Identification>> GetIdentification(int id)
        {
            var identification = await _bll.Identifications.FindAllIncludedAsync(id);

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
            
            _bll.Identifications.Update(identification);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Identifications
        [HttpPost]
        public async Task<ActionResult<Identification>> PostIdentification(Identification identification)
        {
            await _bll.Identifications.AddAsync(identification);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetIdentification", new { id = identification.Id }, identification);
        }

        // DELETE: api/Identifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Identification>> DeleteIdentification(int id)
        {
            var identification = await _bll.Identifications.FindAllIncludedAsync(id);
            if (identification == null)
            {
                return NotFound();
            }

            _bll.Identifications.Remove(identification);
            await _bll.SaveChangesAsync();

            return identification;
        }
    }
}
