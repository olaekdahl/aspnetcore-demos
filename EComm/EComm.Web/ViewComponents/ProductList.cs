using EComm.DataAccess;
using EComm.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.ViewComponents
{
    public class ProductList : ViewComponent
    {
        private ECommDataContext _dataContext;

        public ProductList(ECommDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<IViewComponentResult> InvokeAsync(string search)
        {
            IEnumerable<Product> products;
            if (string.IsNullOrEmpty(search))
            {
                products = _dataContext.Products.ToList();
            }
            else
            {
                products = _dataContext.Products.Where(p => p.ProductName.StartsWith(search)).ToList();
            }
            return Task.FromResult<IViewComponentResult>(View(products));
        }
    }
}
