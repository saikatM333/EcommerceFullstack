using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DTOs { 
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
