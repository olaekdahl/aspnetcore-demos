using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EComm.Web.Models;
using EComm.Web.Services;
using EComm.Web.DAL;
using EComm.Shared.Models;
using Microsoft.AspNetCore.Http;
using EComm.Web.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace EComm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private IEmailService _emailService;
        private IRepository _repo;

        public HomeController(IRepository repo, ILogger<HomeController> logger)
        {
            _logger = logger;
            // _emailService = emailService;
            _repo = repo;
        }

        public IActionResult Create()
        {
            var prod = new Product();
            var suppliers = _repo.GetSuppliers();
            var model = new ProductViewModel();
            model.Product = prod;
            model.Suppliers = suppliers;
            return View(model);
        }

        [ActionName("Create")]
        [HttpPost]
        public IActionResult CreteProduct([Bind(Prefix = "Product")]Product p)
        {
            if(ModelState.IsValid)
            {
                p.IsDiscontinued = false;
                _repo.AddProduct(p);
                TempData["message"] = $"{p.Name } was added!";
                return RedirectToAction("Index");
            }

            var prod = p;
            var suppliers = _repo.GetSuppliers();
            var model = new ProductViewModel();
            model.Product = prod;
            model.Suppliers = suppliers;
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod = _repo.GetProduct(id);
            var suppliers = _repo.GetSuppliers();
            var model = new ProductViewModel();
            model.Product = prod;
            model.Suppliers = suppliers;
            return View(model);
        }

        [ActionName("Edit")]
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            try
            {
                _repo.UpdateProduct(product);
            }
            catch(Exception ex)
            {
                
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            // Cookies -> text file on client
            HttpContext.Response.Cookies.Append("uid", "12345");
            var uid = HttpContext.Request.Cookies["uid"];
            ViewBag.Uid = uid;

            // sessions
            HttpContext.Session.SetString("name", "Ola");
            var name = HttpContext.Session.GetString("name");

            Product p = new Product();
            HttpContext.Session.SetObject<Product>("p1", p);
            var p2 = HttpContext.Session.GetObject<Product>("p1");

            // Items
            // var isVerified = bool.Parse(HttpContext.Items["isVerified"].ToString());
            // if (isVerified) { }

            var products = _repo.GetProducts();
            //ViewBag.Products = products;
            //ViewData["Products"] = products;
            return View("Products", products);
        }

        public IEnumerable<Product> Products()
        {
            var products = _repo.GetProducts();
            return products;
        }

        //public IActionResult GetTopCustomer()
        //{
        //    var top = _repo.GetTopCustomer();
        //    return View();
        //}

        [Authorize(Roles = "admin,IT")]
        public IActionResult Details(int id)
        {
            Product  p = _repo.GetProduct(id);
            if(p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpGet("ResultAsync")]
        public async Task<IActionResult> ResultAsync()
        {
            var prods1 = await _repo.GetProductsAsync();
            var prods2 = await _repo.GetProductsAsync();
            var prods3 = await _repo.GetProductsAsync();
            return Json("done");
        }

        public IActionResult Customer()
        {
            return View(_repo.GetCustomers());
        }

        [Route("login")]
        [Route("user-login")]
        [Route("auth/user-login.jsp/{name}")]
        public IActionResult UserLogin(string name)
        {
            return Content($"{name} is logged in!");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ClientError(int id)
        {
            ViewBag.Code = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
                                HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            //{
            //    ExceptionMessage = "File error thrown";
            //}
            //if (exceptionHandlerPathFeature?.Path == "/index")
            //{
            //    ExceptionMessage += " from home page";
            //}
            string id = string.Empty;
            if (exceptionHandlerPathFeature != null)
            {
                id = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
                _logger.LogError($"ID: {id}");
                _logger.LogError($"TIME: {DateTime.Now}");
                _logger.LogError($"User: {User.Identity.Name}");
                _logger.LogError($"TYPE: {exceptionHandlerPathFeature?.Error.GetType()}");
                _logger.LogError($"ERROR: {exceptionHandlerPathFeature?.Error.Message}");
                _logger.LogError($"PATH: {exceptionHandlerPathFeature?.Path}");
            }
            return View(new ErrorViewModel { RequestId = id });
        }
    }
}
