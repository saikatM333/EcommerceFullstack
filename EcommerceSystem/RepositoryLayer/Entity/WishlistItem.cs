using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RepositoryLayer.Entity.Wishlist;

namespace RepositoryLayer.Entity
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public int ProductId { get; set; }
        public Wishlist Wishlist { get; set; }
        public Product Product { get; set; }
    }
}
