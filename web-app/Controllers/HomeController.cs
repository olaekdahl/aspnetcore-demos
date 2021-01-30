// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.DAL;
using web_app.Services;
using web_app.Shared.Models;
using web_app.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace web_app.Controllers
{
    // [AllowAnonymous]
    public class HomeController : Controller
    {
        private IEmailService _email;
        private IRepository _repo;
        private ILogger<HomeController> _logger;

        public HomeController(IEmailService email, IRepository repo,
            ILogger<HomeController> logger)
        {
            _email = email;
            _repo = repo;
            _logger = logger;
        }


        [HttpGet("ClientError")]
        [HttpPost("ClientError")]
        public IActionResult ClientError(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet("Error")]
        [HttpPost("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            string id = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            if(exceptionHandlerPathFeature != null)
            {
                _logger.LogError($"TYPE: {exceptionHandlerPathFeature.Error.GetType()}");
                _logger.LogError($"PATH: {exceptionHandlerPathFeature.Path}");
            }
            ViewBag.Id = id;
            return View();
        }



        [HttpGet]
        public IActionResult Create()
        {
            var model = new ProductViewModel();
            model.Product = new Product();
            model.Suppliers = _repo.GetSuppliers();
            return View(model);
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProduct(IFormCollection data)
        {
            var product = new Product();

            TryUpdateModelAsync(product, typeof(Product), "Product");
            // product.ProductName = data["Name"];

            if(ModelState.IsValid)
            {
                _repo.AddProuct(product);
                return RedirectToAction("Index");
            }

            var model = new ProductViewModel();
            model.Product = product;
            model.Suppliers = _repo.GetSuppliers();
            return View(model);
        }

        public IActionResult Edit(int pid)
        {
            var model = new ProductViewModel();
            model.Product = _repo.GetProduct(pid);
            model.Suppliers = _repo.GetSuppliers();
            return View(model);
        }

        //[Authorize("admin")]
        //[AllowAnonymous]
        public IActionResult Index(int pid=0)
        {
            int pageNum = pid;
            ViewBag.PageNum = pageNum;
            var products = _repo.GetProducts().Skip(pageNum*10).Take(10);
            if(User.IsInRole("admin"))
            {
                HttpContext.Response.Cookies.Append("returning-user", "true");
                HttpContext.Response.Cookies.Append("last-visit", DateTime.Now.ToString());
            }
            


            var isVerified = bool.Parse(HttpContext.Items["isVerified"].ToString());

            var p = new Product();
            HttpContext.Session.SetObject<Product>("p1", p);
            var p2 = HttpContext.Session.GetObject<Product>("p1");
            var name = HttpContext.Session.GetString("name");

            var returninguser = HttpContext.Request.Cookies["returning-user"];
            var lastVisit = HttpContext.Request.Cookies["last-visit"];

            ViewBag.ReturningUser = returninguser;
            ViewBag.LastVisit = lastVisit;

            return View(products);
        }

        public IActionResult Details(int pid)
        {
            var product = _repo.GetProduct(pid);
            if(product != null)
            {
                return View(product);
            } 
            else
            {
                return Content($"Product with id {pid} was not found");
            }
           
        }


        public IActionResult Add(Product product)
        {
            _repo.AddProuct(product);
            return Ok();
        }


        [ResponseCache(Duration = 100, Location = ResponseCacheLocation.Any)]
        public IActionResult foo()
        {
            return Content("email sent!");
        }
    }
}
