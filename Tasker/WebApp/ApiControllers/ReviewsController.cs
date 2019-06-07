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
    public class ReviewsController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ReviewsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Review>>> GetReviews()
        {
            return (await _bll.Reviews.AllAsync())
                .Select(e => PublicApi.v1.Mappers.ReviewMapper.MapFromBLL(e)).ToList();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Review>> GetReview(int id)
        {
            var review = PublicApi.v1.Mappers.ReviewMapper.MapFromBLL(await _bll.Reviews.FindAllIncludedAsync(id));

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

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

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Review>> PostReview(PublicApi.v1.DTO.Review review)
        {
            _bll.Reviews.Add(PublicApi.v1.Mappers.ReviewMapper.MapFromExternal(review));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var review = await _bll.Reviews.FindAllIncludedAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _bll.Reviews.Remove(review);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
