using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using busnessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace busnessLayer.Services
{
    public class OrderServicesBL : IOrderServicesBL
    {
        private readonly IOrderServicesRL _orderServicesRL;
        public OrderServicesBL(IOrderServicesRL orderServicesRL)
        {
           _orderServicesRL = orderServicesRL;
        }
        public async Task<IEnumerable<OrderItem>> GetOrders(int userId)
        {
            return await _orderServicesRL.GetOrders(userId);
        }

        public async Task<Order> PlaceOrder(int userId)
        {
            return await _orderServicesRL.PlaceOrder(userId);
        }

        public Task<Order> TrackOrder(int orderId)
        {
            return _orderServicesRL.TrackOrder(orderId);
        }
        public Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(int customerId)
        {
            return _orderServicesRL.GetOrdersByCustomer(customerId);   
        }
    }
}
