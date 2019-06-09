using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdentificationsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public IdentificationsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get identifications
        /// </summary>
        /// <returns>Array of identifications</returns>
        // GET: api/Identifications
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.Identification>> GetIdentifications()
        {
            return (await _bll.Identifications.AllAsync())
                .Select(e => PublicApi.v1.Mappers.IdentificationMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get identification by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain identification</returns>
        // GET: api/Identifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Identification>> GetIdentification(int id)
        {
            var identification = PublicApi.v1.Mappers.IdentificationMapper.MapFromBLL(await _bll.Identifications.FindAsync(id));

            if (identification == null)
            {
                return NotFound();
            }

            return identification;
        }

        /// <summary>
        /// Update identification
        /// </summary>
        /// <param name="id"></param>
        /// <param name="identification"></param>
        /// <returns>No Content</returns>
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

        /// <summary>
        /// Post identification
        /// </summary>
        /// <param name="identification"></param>
        /// <returns>Identification</returns>
        // POST: api/Identifications
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Identification>> PostIdentification(PublicApi.v1.DTO.Identification identification)
        {
            _bll.Identifications.Add(PublicApi.v1.Mappers.IdentificationMapper.MapFromExternal(identification));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetIdentification), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = identification.Id
                }, identification);
        }

        /// <summary>
        /// Delete identification by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/Identifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Identification>> DeleteIdentification(int id)
        {
            _bll.Identifications.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
