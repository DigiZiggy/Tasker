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
    public class ReviewsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ReviewsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// Get reviews
        /// </summary>
        /// <returns>Array of reviews</returns>
        // GET: api/Reviews
        [HttpGet]
        public async Task<List<PublicApi.v1.DTO.Review>> GetReviews()
        {
            return (await _bll.Reviews.AllAsync())
                .Select(e => PublicApi.v1.Mappers.ReviewMapper.MapFromBLL(e)).ToList();
        }
        
        /// <summary>
        /// Get review by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Certain review</returns>
        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Review>> GetReview(int id)
        {
            var review = PublicApi.v1.Mappers.ReviewMapper.MapFromBLL(await _bll.Reviews.FindAsync(id));

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        /// <summary>
        /// Update review
        /// </summary>
        /// <param name="id"></param>
        /// <param name="review"></param>
        /// <returns>No Content</returns>
        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, PublicApi.v1.DTO.Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }
           
            _bll.Reviews.Update(PublicApi.v1.Mappers.ReviewMapper.MapFromExternal(review));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Post review
        /// </summary>
        /// <param name="review"></param>
        /// <returns>Review</returns>
        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Review>> PostReview(PublicApi.v1.DTO.Review review)
        {
            _bll.Reviews.Add(PublicApi.v1.Mappers.ReviewMapper.MapFromExternal(review));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetReview), 
                new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = review.Id
                }, review);
        }

        /// <summary>
        /// Delete review by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Review>> DeleteReview(int id)
        {
            _bll.Reviews.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
