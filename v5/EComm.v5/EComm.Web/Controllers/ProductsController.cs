using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Web.Models;
using EComm.Web.Options;
using EComm.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using EComm.Web.Helpers;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EComm.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IEmailService _email;
        private IRepository _repo;

        private ILogger<ProductsController> _logger;

        public ProductsController(IEmailService email, IOptions<EmailOptions> configuration,
            IRepository repo, ILogger<ProductsController> logger)
        {
            _email = email;
            //_server = configuration.Value.Server;
            //_user = configuration.Value.User;
            _repo = repo;
            _logger = logger;
        }

        public IActionResult Error()
        {
            _logger.LogError("This is the error log message");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErrorDemo()
        {
            throw new Exception("uh oh....");
        }

        public IActionResult Index()
        {
            var isVerified = HttpContext.Items["isVerified"];
            var item2 = HttpContext.Items["item2"];
            HttpContext.Response.Cookies.Append("uid", "12467");
            UserModel userModel = new UserModel()
            {
                Id = 10,
                Manager = "Tim",
                UserName = HttpContext.User.Identity.Name
            };
            HttpContext.Session.SetObject<UserModel>("user", userModel);
            var um = HttpContext.Session.GetObject<UserModel>("user");
           
            var model = _repo.GetProducts();
            return View(model);
        }

        public IActionResult Details(int id)
        {

            // var uid = HttpContext.Request.Cookies["uid"];
            // ViewBag.Uid = uid;
            return View(_repo.GetProduct(id));
        }

        public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel();
            model.Product = new Product();
            model.Suppliers = _repo.GetSuppliers();
            return View(model);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> AddProduct(ProductViewModel p)
        {
            
            if(ModelState.IsValid)
            {
                Product newProduct = new Product();
                await TryUpdateModelAsync(newProduct, "Product");
                _repo.AddProduct(newProduct);
                return RedirectToAction("Index");
            }
            p.Suppliers = _repo.GetSuppliers();
            return View("Create", p);
        }

        public IActionResult Test()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddProduct(Product p)
        //{
        //    ViewBag.Name = p.ProductName;
        //    ViewBag.Price = p.UnitPrice;
        //    return View("ProductAdded");
        //}

    }
}
