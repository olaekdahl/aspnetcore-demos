using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [Route("authorize")]
    public class AuthController : Controller
    {
        [Route("logon")]
        [Route("login")]
        [Route("start")]
        [Route("user/login")]
        public IActionResult Login()
        {
            return View("~/Views/Auth/LoginViews/Login.cshtml");
        }
    }
}