using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepositoryLayer.DTOs
{
   
        public class NotificationDTO
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public bool IsRead { get; set; }
        

    }
}
