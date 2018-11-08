using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDemo.Shared.Models;

namespace WebDemo.Shared.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public IQueryable<Supplier> Suppliers { get; set; }
        public IEnumerable<SelectListItem> SupplierList
        {
            get
            {
                return from s in Suppliers
                       select new SelectListItem
                       {
                           Text = s.CompanyName,
                           Value = s.Id.ToString(),
                           Selected = (s.Id == Product.Id)
                       };
            }
        }
    }
}
