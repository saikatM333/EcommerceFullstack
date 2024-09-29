﻿using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IOrderServicesRL
    {
            public  Task<IEnumerable<OrderItem>> GetOrders(int userId);
            public  Task<Order> PlaceOrder(int userId);
            public Task<Order> TrackOrder(int orderId);
            public Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomer(int customerId);
}
}
