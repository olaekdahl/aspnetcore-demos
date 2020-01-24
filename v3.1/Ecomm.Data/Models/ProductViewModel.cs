using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecomm.Data.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<SelectListItem> CategoryList
        {
            get
            {
                if(Categories == null)
                {
                    return null;
                }
                return from c in Categories
                       select new SelectListItem()
                       {
                           Value = c?.Id.ToString(),
                           Text = c?.Name,
                           Selected = (c?.Id == Product?.Category?.Id)
                       };
            }
        }
    }
}
