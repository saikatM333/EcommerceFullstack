using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICategoryServicesRL
    {
        

            // Controllers/CategoriesController.cs
            public  Task<IEnumerable<Category>> GetCategories();

            public  Task<Category> GetCategory(int id);


            public  Task<Category> PostCategory(Category category);


            public  Task<Category> PutCategory(int id, Category category);
            public  Task<Category> DeleteCategory(int id);
            
    

}
}
