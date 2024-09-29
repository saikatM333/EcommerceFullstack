using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class CartItem
    {
        public int Id { get; set; }
       
        public int CartId { get; set; }
        [JsonIgnore]
        public Cart Cart { get; set; }
        
        public int ProductId { get; set; }
       
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
