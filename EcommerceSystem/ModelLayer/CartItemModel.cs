using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
       
        public int ProductId { get; set; }
       
        public int Quantity { get; set; }
    }
}
