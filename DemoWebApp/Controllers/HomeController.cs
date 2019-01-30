using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoApp.Services;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ///_email.SendEmail("ola@isinc.com", "Hello from email service...");
            return View();
        }

        public IActionResult Login()
        {
            ///_email.SendEmail("ola@isinc.com", "Hello from email service...");
            return View();
        }

        public IActionResult Search()
        {
            ///_email.SendEmail("ola@isinc.com", "Hello from email service...");
            return View();
        }
    }
}