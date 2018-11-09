using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebDemo.DAL;
using WebDemo.Shared.Models;

namespace WebDemo.Components
{
    [ViewComponent]
    public class ProductList : ViewComponent
    {
        private IProductRepository _repo;
        public ProductList(IProductRepository repo)
        {
            _repo = repo;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Product> model = _repo.AllProducts;
            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
