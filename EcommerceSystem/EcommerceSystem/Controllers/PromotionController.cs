using busnessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionServicesBL _promotionServicesBL;

        public PromotionController(IPromotionServicesBL promotionServicesBL)
        {
            _promotionServicesBL = promotionServicesBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions()
        {   
            var data = await _promotionServicesBL.GetPromotions();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetPromotion(int id)
        {
            var promotion = await _promotionServicesBL.GetPromotion(id);

            if (promotion == null)
            {
                return NotFound();
            }

            return promotion;
        }

        [HttpPost]
        public async Task<ActionResult<Promotion>> PostPromotion(Promotion promotion)
        {   var data  = _promotionServicesBL.PostPromotion(promotion);
            if (data == null)
            {
                return NoContent();
            }
            else
            {
                return CreatedAtAction("GetPromotion", new { id = promotion.Id }, promotion);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotion(int id, Promotion promotion)
        {  var data  = await _promotionServicesBL.PutPromotion(id, promotion);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var promotion = await _promotionServicesBL.DeletePromotion(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }
    }
}
