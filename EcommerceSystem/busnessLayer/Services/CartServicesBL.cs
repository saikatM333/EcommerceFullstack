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
using RepositoryLayer.DTOs;

namespace busnessLayer.Services
{
    public class CartServicesBL : ICartServiceBL
    {
        private readonly ICartServiceRL _rl;
        public CartServicesBL(ICartServiceRL cartServiceRL)
        {
            _rl = cartServiceRL;
        }

        // Controllers/CartController.cs
        public async Task<ICollection<CartItem>> GetCart(int userId)
        {
            return await _rl.GetCart(userId);
        }
        public async Task<Product> AddItemToCart(int productId, int quantity, int userId)
        {
            return await _rl.AddItemToCart(productId, quantity, userId);     
        }
        public async Task<CartItem> RemoveItemFromCart(int productId, int userId)
        {
           return await  _rl.RemoveItemFromCart(productId, userId);
        }
    

}
}
