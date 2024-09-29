using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [JsonIgnore]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }

        public string ImageUrl { get; set; }
    }
}
