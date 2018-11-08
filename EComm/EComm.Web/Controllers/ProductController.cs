using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.DataAccess;
using EComm.Model;
using EComm.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EComm.Web.Controllers
{
    public class ProductController : Controller
    {
        private ECommDataContext _dataContext;

        public ProductController(ECommDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [Route("product/{id:int}")]
        public IActionResult Detail(int id)
        {
            var product = _dataContext.Products.Include(p => p.Supplier).SingleOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = _dataContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            var suppliers = _dataContext.Suppliers.ToList();
            var pvm = new ProductEditViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Package = product.Package,
                IsDiscontinued = product.IsDiscontinued,
                SupplierId = product.SupplierId,
                Suppliers = suppliers.Select(s =>
                    new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString() }).ToList()
            };
            return View(pvm);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel pvm)
        {
            if (!ModelState.IsValid) {
                var suppliers = _dataContext.Suppliers.ToList();
                pvm.Suppliers = suppliers.Select(s => new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString() }).ToList();
                return View(pvm);
            }
            var product = new Product
            {
                Id = pvm.Id,
                ProductName = pvm.ProductName,
                UnitPrice = pvm.UnitPrice,
                Package = pvm.Package,
                IsDiscontinued = pvm.IsDiscontinued,
                SupplierId = pvm.SupplierId
            };
            _dataContext.Attach(product);
            _dataContext.Entry(product).State = EntityState.Modified;
            _dataContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}