using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class CartItemModel
    {
      
        public int CartId { get; set; }
       
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
    }
}
