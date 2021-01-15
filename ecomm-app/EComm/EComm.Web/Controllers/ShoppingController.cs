using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

namespace EComm.Web.Controllers
{
    public class ShoppingController : Controller
    {
        // [Route("add/{num1}/{num2}")]
        public IActionResult Test()
        {
            MediaTypeHeaderValue m = new MediaTypeHeaderValue("text/html");
            return View();
        }
    }
}
