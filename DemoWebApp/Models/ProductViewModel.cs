using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

        public IEnumerable<SelectListItem> CategoryList
        {
            get
            {
                return from c in Categories
                       select new SelectListItem
                       {
                           Text = c.CategoryName,
                           Value = c.Id.ToString()
                           //Selected = Product.CategoryId == null ? true : c.Id == Product.CategoryId
                       };
            }
        }
    }
}
