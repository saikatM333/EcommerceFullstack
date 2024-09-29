using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public  class Wishlist
    {
        
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public List<WishlistItem> WishlistItems { get; set; }
        }

        

    
}
