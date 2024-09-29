using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
   
        public class Notification
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
            public bool IsRead { get; set; }
        

    }
}
