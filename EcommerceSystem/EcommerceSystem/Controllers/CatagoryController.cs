using busnessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace OnlineBookOrderingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        // Controllers/CategoriesController.cs


        private readonly ICategoryServicesBL _categoryServicesBL;
        public CatagoryController(ICategoryServicesBL categoryServicesBL)
        {
            _categoryServicesBL = categoryServicesBL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var data = await _categoryServicesBL.GetCategories();
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
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryServicesBL.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var data  = _categoryServicesBL.PostCategory(category);
            if (data == null)
            {
                return NotFound(category);
            }
            else
            {
                return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, data);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
           

            var  data  = _categoryServicesBL.PutCategory(id , category);
            if (data == null)
            {
                return BadRequest();
            }

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryServicesBL.DeleteCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                 return Ok(id);
            }
        
    }

}
}
