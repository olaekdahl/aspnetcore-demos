using Microsoft.AspNetCore.Mvc;
using System;

namespace EComm.Controllers
{
    public class TestController: Controller
    {
        public string Hello()
        {
            return "Hello!";
        }
    }
}
