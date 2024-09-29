using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RepositoryLayer.Entity.Wishlist;

namespace RepositoryLayer.DTOs
{
    public class WishlistItemDTO
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
    }
       
}
