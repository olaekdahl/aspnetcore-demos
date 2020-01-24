using Ecomm.Data.Models;
using Ecomm.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm.Web.ViewComponents
{
    public class ProductList : ViewComponent
    {
        private IRepository _repo;

        public ProductList(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync(string search)
        {
            IEnumerable<Product> products;
            if (string.IsNullOrEmpty(search))
            {
                products = await _repo.GetProducts();
            }
            else
            {
                products = await _repo.GetProducts();//.Where(p => p.ProductName.StartsWith(search)).ToList();
                products = products.Where(p => p.Name.StartsWith(search)).ToList();
            }
            return View(products);
        }
    }
}
