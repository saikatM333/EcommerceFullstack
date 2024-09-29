using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.DTOs;
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
    public class CartServices : ICartServiceRL
    {
        private readonly EcommerceDBContext _context;
        public CartServices(EcommerceDBContext dBContext)
        {
            _context = dBContext;
        }

        // Controllers/CartController.cs
        public async Task<ICollection<CartItem>> GetCart(int userId)
        {

            var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product)
                            .FirstOrDefaultAsync(c => c.CustomerId == userId);

            if (cart == null)
            {
                return null;
            }

            return cart.CartItems;
        }

        [Authorize]
        public async Task<Product> AddItemToCart(int productId, int quantity, int userId)
        {

            //var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.CustomerId == userId);

            //if (cart == null)
            //{
            //    cart = new Cart { CustomerId = userId };
            //    _context.Carts.Add(cart);
            //    await _context.SaveChangesAsync();
            //}

            //var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            //if (cartItem == null)
            //{
            //    cartItem = new CartItem { CartId = cart.Id, ProductId = productId, Quantity = quantity };

            //    _context.CartItems.Add(cartItem);
            //}
            //else
            //{
            //    cartItem.Quantity += quantity;
            //}
            //var cartItemModel = new CartItemModel
            //{
            //    CartId = cartItem.CartId,
            //    ProductId = cartItem.ProductId,
            //    Quantity = cartItem.Quantity
            //};
            //await _context.SaveChangesAsync();

            //return new CartDTO
            //{
            //    Id = cart.Id,
            //    CustomerId = cart.CustomerId,
            //    CartItems = cart.CartItems.Select(ci => new CartItemDTO
            //    {
            //        Id = ci.Id,
            //        ProductId = ci.ProductId,
            //        Quantity = ci.Quantity
            //    }).ToList()
            //};


            // var product     = await _context.Products.FindAsync(productId);

            var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.CustomerId == userId);

            if (cart == null)
            {
                cart = new Cart { CustomerId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem { CartId = cart.Id, ProductId = productId, Quantity = quantity };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();

            // Map to DTO
            var cartDTO = new CartDTO
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                CartItems = cart.CartItems.Select(ci => new CartItemDTO
                {
                    Id = ci.Id,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };
            var product  = await _context.Products.FindAsync(productId);
            return product;

        }


        public async Task<CartItem> RemoveItemFromCart(int productId, int userId)
        {

            var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.CustomerId == userId);

            if (cart == null)
            {
                return null;
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return cartItem;
        }
    

}
}
