using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_app.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View("test");
        }

        public ContentResult Logout()
        {
            return Content("<b>user is logged out.</b>", "text/html");
        }
    }
}
