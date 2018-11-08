using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class EmployeeDataController : Controller
    {
        public IActionResult Index()
        {
            return Content("<h1>Hello!</h1>", "text/html");
        }
    }
}