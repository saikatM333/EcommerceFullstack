using busnessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.JsonHelper;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewServicesBL _reviewServicesBL;

        public ReviewsController(IReviewServicesBL reviewServicesBL)
        {
            _reviewServicesBL = reviewServicesBL;
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByProduct(int productId)
        {
            var data = _reviewServicesBL.GetReviewsByProduct(productId);
            if (data == null)
            {
                return NotFound();
            }
            string serializedReview = await JsonHelper.SerializeAsync(data);
            return Ok(serializedReview);
        }

        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(string productId  ,  string rating , string comment )
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int productid = int.Parse(productId);
            int Rating = int.Parse(rating);
            int userId = int.Parse(userid);
            var data = _reviewServicesBL.PostReview(userId , productid, Rating , comment);

            if (data != null)
            {
                string serializedreview = await JsonHelper.SerializeAsync(data);
                return Ok(serializedreview);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("avgRate")]
        public async Task<ActionResult> GetAverageResult(string productId)
        {
            int ProductId = int.Parse(productId);
            var data = _reviewServicesBL.GetAverageRating(ProductId);

            if (data == null)
            {
                return NotFound();
            }
            else
            {
                string serializedReviwew = await JsonHelper.SerializeAsync(data);
                return Ok(serializedReviwew);
            }
        }
    }
}
