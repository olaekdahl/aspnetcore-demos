using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }
    }
}
