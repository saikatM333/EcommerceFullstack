using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
