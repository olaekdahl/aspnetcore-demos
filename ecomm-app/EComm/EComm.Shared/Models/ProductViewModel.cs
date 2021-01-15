using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EComm.Shared.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Supplier> Suppliers { get; set; }

        public IEnumerable<SelectListItem> SupplierList
        {
            get
            {
                return from s in Suppliers
                       select new SelectListItem()
                       {
                           Value = s.Id.ToString(),
                           Text = s.CompanyName,
                           Selected = s.Id == Product.SupplierId
                       };
            }
        }
    }
}
