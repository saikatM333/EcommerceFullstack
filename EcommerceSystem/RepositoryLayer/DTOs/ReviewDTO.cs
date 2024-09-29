using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DTOs
{
    public class ReviewDTO
    {
       
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string CustomerName { get; set; }
            public string Content { get; set; }
            public int Rating { get; set; }
            public DateTime Date { get; set; }

            
        

    }
}
