using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Data.DAL;
using AdventureWorks.Shared.ViewModels;
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

        public IActionResult Details(int id)
        {
            var evm = new EmployeeViewModel();
            evm.Employee = _ctx.Employees.Find(id);
            evm.Departments = _ctx.Departments;

            return View(evm);
        }
    }
}