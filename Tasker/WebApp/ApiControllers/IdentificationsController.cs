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
    public class IdentificationsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public IdentificationsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Identifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Identification>>> GetIdentifications()
        {
            return (await _bll.Identifications.AllAsync())
                .Select(e => PublicApi.v1.Mappers.IdentificationMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Identifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Identification>> GetIdentification(int id)
        {
            var identification = PublicApi.v1.Mappers.IdentificationMapper.MapFromBLL(await _bll.Identifications.FindAllIncludedAsync(id));

            if (identification == null)
            {
                return NotFound();
            }

            return identification;
        }

        // PUT: api/Identifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentification(int id, PublicApi.v1.DTO.Identification identification)
        {
            if (id != identification.Id)
            {
                return BadRequest();
            }
            
            _bll.Identifications.Update(PublicApi.v1.Mappers.IdentificationMapper.MapFromExternal(identification));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Identifications
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Identification>> PostIdentification(PublicApi.v1.DTO.Identification identification)
        {
            _bll.Identifications.Add(PublicApi.v1.Mappers.IdentificationMapper.MapFromExternal(identification));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetIdentification", new { id = identification.Id }, identification);
        }

        // DELETE: api/Identifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIdentification(int id)
        {
            var identification = await _bll.Identifications.FindAllIncludedAsync(id);
            if (identification == null)
            {
                return NotFound();
            }

            _bll.Identifications.Remove(identification);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
