using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
   
        public class Promotion
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public decimal DiscountPercentage { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
       

    }
}
