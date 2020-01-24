using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm.Web.Controllers
{
    public class ErrorController : Controller
    {
        public string ExceptionMessage { get; private set; }

        public IActionResult Error(int code)
        {
            return View();
        }
    }
}