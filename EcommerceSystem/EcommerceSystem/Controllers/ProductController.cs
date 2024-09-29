using busnessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.JsonHelper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineBookOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Controllers/ProductsController.cs

        private readonly IProductServicesBL _productServicesBL;

        public ProductController(IProductServicesBL productServicesBL)
        {
            _productServicesBL  = productServicesBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var data  = await _productServicesBL.GetProducts(); 
            if (data == null) {
                return BadRequest("something went wrong");
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productServicesBL.GetProduct(id);
            string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
            product.ImageUrl = $"{baseUrl}/pics/{product.Id}.jpg";

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var data  =  _productServicesBL.PostProduct(product);
            if (data == null)
            {
                return BadRequest("some thing went wrong");
            }
            else
            {

                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productServicesBL.DeleteProduct(id);
            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        
    }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts(string query)
        {
            IEnumerable<Product> products  = await  _productServicesBL.SearchProducts(query);
            string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            foreach (var product in products)
            {
                // Assuming the images are stored in a directory one level above 'wwwroot'
                product.ImageUrl = $"{baseUrl}/pics/{product.Id}.jpg";
            }
          
            return Ok(products);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string categoryId)
        {    int catId = int.Parse(categoryId);
            IEnumerable<Product> products  = await _productServicesBL.GetProductsByCategory(catId);
            string baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            foreach (var product in products)
            {
                // Assuming the images are stored in a directory one level above 'wwwroot'
                product.ImageUrl = $"{baseUrl}/pics/{product.Id}.jpg";
            }
            string serializedProduct = await JsonHelper.SerializeAsync(products);
            return Ok(serializedProduct);
        }

        [HttpGet("recommended")]
        public async Task<ActionResult<IEnumerable<Product>>> GetRecommendedProducts(int customerId)
        {
            // Simple recommendation logic: get the top 5 products from the same categories as the customer's past orders
           var recommendedProducts = await _productServicesBL.GetRecommendedProducts(customerId);

            return Ok(recommendedProducts);
        }



    }
}
