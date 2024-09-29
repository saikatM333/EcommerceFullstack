using RepositoryLayer.Context;
using RepositoryLayer.DTOs;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busnessLayer.Interfaces
{
    public interface ICartServiceBL
    { 
        public Task<ICollection<CartItem>> GetCart(int userId);
        public  Task<Product> AddItemToCart(int productId, int quantity, int userId);
        public Task<CartItem> RemoveItemFromCart(int productId, int userId); 
}
}
