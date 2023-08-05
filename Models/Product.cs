using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsDeactive { get; set; }
        public string Image { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}
