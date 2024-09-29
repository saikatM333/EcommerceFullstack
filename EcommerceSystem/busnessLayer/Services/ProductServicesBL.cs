using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using busnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace busnessLayer.Services
{
    public class ProductServicesBL : IProductServicesBL
    {
        private readonly IProductServicesRL _productServicesRL;

        public ProductServicesBL(IProductServicesRL productServicesRL)
        {
               _productServicesRL = productServicesRL;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productServicesRL.GetProducts();
        }

    public async Task<Product> GetProduct(int id)
    {
        return await _productServicesRL.GetProduct(id);
    }

    public async Task<Product> PostProduct(Product product)
    {
        return await _productServicesRL.PostProduct(product); 
    }

    public async Task<Product> PutProduct(int id, Product product)
    {
        return await _productServicesRL.PutProduct(id, product);
    }

    public async Task<Product> DeleteProduct(int id)
    {
        return await (_productServicesRL.DeleteProduct(id));
    }
        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            return await _productServicesRL.GetProductsByCategory(categoryId);
        }
        public async  Task<IEnumerable<Product>> SearchProducts(string query)
        {
            return await _productServicesRL.SearchProducts(query);
        }
        public async  Task<IEnumerable<Product>> GetRecommendedProducts(int customerId)
        {
            return await  _productServicesRL.GetRecommendedProducts(customerId);
        }
    }
}
