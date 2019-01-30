using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoApp.DAL;
using DemoApp.Services;

namespace DemoApp.Controllers
{
    public class BaseController : Controller
    {
        protected IRepository _repo;
        protected IEmailService _email;
        public BaseController(IRepository repo)
        {
            _repo = repo;
        }
    }
}