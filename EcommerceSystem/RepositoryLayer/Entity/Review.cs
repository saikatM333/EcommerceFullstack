using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class Review
    {
       
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int CustomerId { get; set; }
            public string Comment { get; set; }
            public int Rating { get; set; }
            public DateTime Date { get; set; }
            public Customer Customer { get; set; }
            public Product Product { get; set; }
        

    }
}
