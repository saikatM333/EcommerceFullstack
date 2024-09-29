using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class OrderServices : IOrderServicesRL
    {
        private readonly EcommerceDBContext _context;
        public OrderServices(EcommerceDBContext dBContext)
        {
            _context = dBContext;
        }

        // Controllers/OrdersController.cs

        public async Task<IEnumerable<OrderItem>> GetOrders(int userId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == userId)
                .SelectMany(o => o.OrderItems) // Flattens the collection of OrderItems
                .Include(oi => oi.Product)     // Eager load the related Product entity
                .ToListAsync();
        }



        public async Task<Order> PlaceOrder(int userId)
        {

            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                        .FirstOrDefaultAsync(c => c.CustomerId == userId);

            if (cart == null )
            {
                return null;
            }

            var order = new Order
            {
                CustomerId = userId,
                OrderDate = DateTime.UtcNow,
                OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            
            cart.CartItems = null;
            
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(int customerId)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();

            return orders;
        }

        public async Task<Order> TrackOrder(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return null;
            }

            return order;
        }


    }
}
