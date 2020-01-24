using Ecomm.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecomm.Data
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}
