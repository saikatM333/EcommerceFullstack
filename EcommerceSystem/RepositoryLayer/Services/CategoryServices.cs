using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CategoryServices : ICategoryServicesRL
    {
        private readonly EcommerceDBContext _context;
        public CategoryServices(EcommerceDBContext dBContext)
        {
            _context = dBContext;
        }

        // Controllers/CategoriesController.cs
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }


        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return null;
            }

            return category;
        }


        public async Task<Category> PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }


        public async Task<Category> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return null;
            }

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return category;
        }
        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
