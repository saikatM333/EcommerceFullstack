using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DTOs
{
    public  class WishlistDTO
    {
        
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public List<WishlistItemDTO> WishlistItems { get; set; }
        }

        

    
}
