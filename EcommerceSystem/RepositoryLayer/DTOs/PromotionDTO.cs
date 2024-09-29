using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepositoryLayer.DTOs
{
   
        public class PromotionDTO
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public decimal DiscountPercentage { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
       

    }
}
