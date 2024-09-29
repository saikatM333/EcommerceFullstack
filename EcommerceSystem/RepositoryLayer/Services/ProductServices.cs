using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class ProductServices : IProductServicesRL
    {


        private readonly EcommerceDBContext _context;

        public ProductServices(EcommerceDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
    }


    public async Task<Product> GetProduct(int id)
    {
        var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return null;
        }

        return product;
    }


    public async Task<Product> PostProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }


    public async Task<Product> PutProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return null;
        }

        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return product;
    }


    public async Task<Product> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return null;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return product;

    }

        public async Task<IEnumerable<Product>> GetRecommendedProducts(int customerId)
        {
            // Simple recommendation logic: get the top 5 products from the same categories as the customer's past orders
            var customerOrders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();

            var productIds = customerOrders
                .SelectMany(o => o.OrderItems)
                .Select(oi => oi.Product.CategoryId)
                .Distinct()
                .ToList();

            var recommendedProducts = await _context.Products
                .Where(p => productIds.Contains(p.CategoryId))
                .OrderByDescending(p => p.Price) // Simple logic: Recommend higher-priced products
                .Take(5)
                .ToListAsync();

            return recommendedProducts;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int categoryId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> SearchProducts(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return await GetProducts();
            }

            var products = await _context.Products
                .Where(p => p.Name.Contains(query) || p.Description.Contains(query))
                .ToListAsync();

            return products;
        }
    }
}
