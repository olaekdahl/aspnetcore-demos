using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.DAL;

namespace DemoApp.Components
{
    [ViewComponent]
    public class ProductList : ViewComponent
    {
        private IRepository _repo;
        public ProductList(IRepository repo)
        {
            _repo = repo;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = _repo.Products.ToList();
            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
