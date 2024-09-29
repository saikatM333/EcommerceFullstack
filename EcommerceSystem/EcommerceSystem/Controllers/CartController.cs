using busnessLayer.Interfaces;
using busnessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.DTOs;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.JsonHelper;
using System.Security.Claims;

namespace OnlineBookOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CartController : ControllerBase
    {
        private readonly ICartServiceBL _cartServiceBL;

        public CartController(ICartServiceBL cartServiceBL)
        {
            _cartServiceBL = cartServiceBL;
        }

        [HttpGet("")]
      
        public async Task<IActionResult> GetCart()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            int userId = int.Parse(userid);
            var cart = await _cartServiceBL.GetCart(userId);

            string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            // Update the ImageUrl for each product in the cart
            foreach (var cartItem in cart)
            {
                // Assuming the images are stored in a 'pics' directory within 'wwwroot'
                cartItem.Product.ImageUrl = $"{baseUrl}/pics/{cartItem.ProductId}.jpg";
            }
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPost("AddItem")]
        public async Task<ActionResult<CartDTO>> AddItemToCart( int productId, int quantity )
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int userId = int.Parse(userid);
            var data = _cartServiceBL.AddItemToCart(productId, quantity , userId );
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                string serializedCart = await JsonHelper.SerializeAsync(data);
                return Ok(serializedCart);
            }
        }

        [HttpDelete("RemoveItem")]
        public async Task<IActionResult> RemoveItemFromCart(int productId  )
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int userId = int.Parse(userid);
            var data = await _cartServiceBL.RemoveItemFromCart(productId , userId);
            if (data == null)
            {
                return BadRequest();
            }

            return Ok(data);
        
    }

}
}
