using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using busnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busnessLayer.Services
{
    public class CategoryServicesBL : ICategoryServicesBL
    {
        private readonly ICategoryServicesRL _categoryServicesRL;
        public CategoryServicesBL(ICategoryServicesRL categoryServicesRL)
        {
            _categoryServicesRL = categoryServicesRL;
        }

        // Controllers/CategoriesController.cs
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryServicesRL.GetCategories();
        }

        public async Task<Category> GetCategory(int id)
        {         
            return await _categoryServicesRL.GetCategory(id);
        }

        public async Task<Category> PostCategory(Category category)
        {
            return await _categoryServicesRL.PostCategory(category);
        }

        public async Task<Category> PutCategory(int id, Category category)
        {
            return await _categoryServicesRL.PutCategory(id, category);
        }
        public async Task<Category> DeleteCategory(int id)
        {
            return await _categoryServicesRL.DeleteCategory(id);
        }
    }
}
