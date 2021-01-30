using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.DAL;

namespace web_app.Components
{
    public class TopCustomerComponent : ViewComponent
    {
        private IRepository _repo;
        public TopCustomerComponent(IRepository repo)
        {
            _repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _repo.GetTopCustomerAsync();
            return View(model);
        }
    }
}
