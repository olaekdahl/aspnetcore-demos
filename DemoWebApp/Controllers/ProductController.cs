using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoApp.DAL;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IRepository repo):base(repo)
        {

        }

        public IActionResult Add()
        {
            ProductViewModel vm = new ProductViewModel();
            vm.Categories = _repo.Categories.ToList();
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind(Prefix = "Product")]Product p)
        {
            if (ModelState.IsValid)
            {
                _repo.AddProduct(p);
                return RedirectToAction("List");
            }
            ProductViewModel vm = new ProductViewModel();
            vm.Categories = _repo.Categories.ToList();
            vm.Product = p;
            return View(vm);
            
        }

        public IActionResult List()
        {
            //var res = new ContentResult();
            //res.Content = "test";
            //return res;
            int count = _repo.Products.ToList().Count();
            
            return View("Index", count);
        }

        public IActionResult Details(int pid)
        {
            ProductViewModel vm = new ProductViewModel();
            vm.Product = _repo.FindProduct(pid);
            vm.Categories = _repo.Categories.ToList();
            return View(vm);
        }
    }
}