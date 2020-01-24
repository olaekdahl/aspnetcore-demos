using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ecomm.Web.Models;
using Ecomm.Web.Services;
using Microsoft.Extensions.Configuration;
using Ecomm.Data;
using Ecomm.Data.Repository;
using Ecomm.Data.Models;
using Microsoft.AspNetCore.Http;
using Ecomm.Web.Filters;

namespace Ecomm.Web.Controllers
{
    // [TypeFilter(typeof(CustomExceptionFilter))]
    public class HomeController : Controller
    {
        private IRepository _repo;
        private IEmailService _email;
        private ILogger _logger;
        public HomeController(ILogger<HomeController> logger, IRepository repo, IEmailService email)
        {
            _repo = repo;
            _email = email;
            _logger = logger;
        }

        public Exception OhOh()
        {
            throw new Exception();
        }

        // [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult GetPerson(int id)
        {
            //var result = _repo.GetPerson(id);
            //return Json(result);
            var result = _repo.GetPerson(id);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Inside Edit Action");
            var product = _repo.FindProduct(id);
            var categories = _repo.GetCategories();
            ProductViewModel vm = new ProductViewModel();
            vm.Product = product;
            vm.Categories = categories;
            return View(vm);
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditProduct(ProductViewModel vm)
        //public IActionResult EditProduct([Bind(Prefix = "Product")]Product p)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = _repo.GetCategories();
                return View(vm);
            }

            // Session["jkjksd"] = "jj";

            ViewData["msg"] = "From ViewBag";
            TempData["msg"] = "From TempData";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            //var people = _repo.GetPeople();
            //var products = await _repo.GetProducts();
            //IndexViewModel vm = new IndexViewModel();
            //vm.People = people;
            //vm.Products = products;
            //return View(vm);
            HttpContext.Response.Cookies.Append("uid", "1245");
            var cookie = HttpContext.Request.Cookies["uid"];
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem("item1");
            cart.AddItem("item2");
            Utils.StoreInSession(cart, HttpContext.Session);

            return View(await _repo.GetProducts());
        }

        [ActionName("Products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.GetProducts();
            //sendemail
            //
            return View();
            //return Content($"Number of products: {products.Count()}");
        }
    }
}
