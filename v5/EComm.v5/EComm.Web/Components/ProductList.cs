using EComm.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Components
{
    public class ProductList : ViewComponent
    {
        private IRepository _repo;

        public ProductList(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _repo.GetProductsAsync();
            return View(products);
        }
    }
}
