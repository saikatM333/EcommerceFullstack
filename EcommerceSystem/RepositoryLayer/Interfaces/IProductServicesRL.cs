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
    public interface IProductServicesRL
    {   
            public  Task<IEnumerable<Product>> GetProducts();
            public  Task<Product> GetProduct(int id);
            public Task<Product> PostProduct(Product product);
            public Task<Product> PutProduct(int id, Product product);
            public Task<Product> DeleteProduct(int id);
            public  Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
            public Task<IEnumerable<Product>> SearchProducts(string query);
            public Task<IEnumerable<Product>> GetRecommendedProducts(int customerId);
    }
}
