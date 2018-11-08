using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class EmployeeDataController : Controller
    {
        private AppDbContext _ctx;
        public EmployeeDataController(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View(_ctx.Employees.ToList());
        }
    }
}