using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepositoryLayer.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
      
        public int CustomerId { get; set; }

      
        public ICollection<CartItemDTO> CartItems { get; set; }
    }
}
