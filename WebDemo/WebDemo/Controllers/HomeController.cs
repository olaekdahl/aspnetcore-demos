using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebDemo.Configs;
using WebDemo.DAL;
using WebDemo.Services;
using WebDemo.Shared.Models;
using WebDemo.Shared.ViewModels;
using WebDemo.Components;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repo;
        private ISession _session;
        private ILogger _logger;

        //public HomeController(IProductRepository repo,
        //    IHttpContextAccessor httpContextAccessor)
        //{
        public HomeController(IProductRepository repo, ILogger<HomeController> logger)
        {
            //_session = httpContextAccessor.HttpContext.Session;
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Error(string id)
        {
            ViewBag.id = id;
            ViewBag.requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogInformation("oops");
            return View();
        }

        //[Route("/Products/List")]
        //[Route("/Products/All")]
        public IActionResult Index()
        {
            //var msg = TempData["outcome"];
            //var products = _repo.AllProducts.ToList();
            //HttpContext.Response.Cookies.Append("uid", "123129");
            //var uid = HttpContext.Request.Cookies["uid"];
            //Product p = new Product { Id = 1, ProductName = "Blue Bike" };
            //HttpContext.Session.Set<Product>("p1", p);
            //var p_out = HttpContext.Session.Get<Product>("p1");
            return View();
        }

        public IActionResult Customers()
        {
            return View(_repo.AllCustomers);
        }

        public IActionResult AddCustomer()
        {
            return View("Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(Customer c)
        {
            if (ModelState.IsValid)
            {
                _repo.InsertOrUpdateCustomer(c);
                _repo.Save();
                TempData["outcome"] = "success";
                ViewBag.outcome = "success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["outcome"] = "failure";
                return RedirectToAction("AddCustomer");
            }
        }

        public IActionResult Details(int id)
        {
            var pvm = new ProductViewModel();
            pvm.Product = _repo.Find(id);
            pvm.Suppliers = _repo.AllSuppliers;
            return View(pvm);
        }

        public IActionResult GetImage(int id)
        {
            return null;
        }

        public IActionResult Delete(int id)
        {
            var orders = _repo.FindOrders(id);
            if(orders.Count() == 0)
            {
                _repo.Delete(id);
                _repo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(orders);
            }
            
        }

    }
}