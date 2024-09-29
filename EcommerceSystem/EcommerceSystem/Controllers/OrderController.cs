using busnessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.JsonHelper;
using System.Security.Claims;

namespace OnlineBookOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {    private readonly IOrderServicesBL _orderServicesBL;
        // Controllers/OrdersController.cs
        public OrderController(IOrderServicesBL orderServicesBL)
        {
           _orderServicesBL = orderServicesBL;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders( )
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int userid = int.Parse(userId);
            var data = await _orderServicesBL.GetOrders(userid);
              
            string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
             
            // Update the ImageUrl for each product in the cart
            foreach (var orderItem in data)
            {
                // Assuming the images are stored in a 'pics' directory within 'wwwroot'
                orderItem.Product.ImageUrl = $"{baseUrl}/pics/{orderItem.ProductId}.jpg";
            }
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder( )
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            int userid = int.Parse(userId);
            var data = _orderServicesBL.PlaceOrder(userid);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                string serializedOrder = await JsonHelper.SerializeAsync(data);
                return Ok(serializedOrder);
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(int customerId)
        {
            var orders = _orderServicesBL.GetOrdersByCustomer(customerId);  

            return Ok(orders);
        }

        [HttpGet("track/{orderId}")]
        public async Task<ActionResult<Order>> TrackOrder(int orderId)
        {
            var order = _orderServicesBL.TrackOrder(orderId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }




    }
}
