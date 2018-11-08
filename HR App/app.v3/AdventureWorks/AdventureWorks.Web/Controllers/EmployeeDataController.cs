using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Data.DAL;
using AdventureWorks.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Web.Controllers
{
    public class EmployeeDataController : Controller
    {
        private AppDbContext _ctx;
        public EmployeeDataController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Search(string query)
        {
            Thread.Sleep(1000);
            return PartialView("Index", _ctx.Employees.Where(e => e.FirstName.StartsWith(query)).ToList());
        }
        public IActionResult Index()
        {
            //_ctx.Database.ExecuteSqlCommand("exec HumanResources.AddEmployee");
            return View(_ctx.Employees.ToList());
        }

        public IActionResult Create()
        {
            AddEmployeeViewModel evm = new AddEmployeeViewModel();
            evm.Departments = _ctx.Departments.ToList();
            return View(evm);
        }

        [HttpPost]
        public IActionResult Create(AddEmployeeViewModel addEmployeeViewModel)
        {
            /*
             @NationalIDNumber nvarchar(15)
            , @LoginID nvarchar(256)
            , @FirstName nvarchar(50)
            , @LastName nvarchar(50)
            , @JobTitle nvarchar(50)
            , @BirthDate date
            , @MaritalStatus nchar(1)
            , @Gender nchar(1)
            , @HireDate date
            , @SalariedFlag bit
            , @VacationHours smallint
            , @SickLeaveHours smallint
            , @DepartmentId smallint"
             */
            SqlParameter p0 = new SqlParameter("@NationalIDNumber", SqlDbType.NVarChar);
            SqlParameter p1 = new SqlParameter("@LoginID", SqlDbType.NVarChar);
            SqlParameter p2 = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter p3 = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter p4 = new SqlParameter("@JobTitle", SqlDbType.NVarChar);
            SqlParameter p5 = new SqlParameter("@BirthDate", SqlDbType.Date);
            SqlParameter p6 = new SqlParameter("@MaritalStatus", SqlDbType.NChar);
            SqlParameter p7 = new SqlParameter("@Gender", SqlDbType.NChar);
            SqlParameter p8 = new SqlParameter("@HireDate", SqlDbType.Date);
            SqlParameter p9 = new SqlParameter("@SalariedFlag", SqlDbType.Bit);
            SqlParameter p10 = new SqlParameter("@VacationHours", SqlDbType.SmallInt);
            SqlParameter p11 = new SqlParameter("@SickLeaveHours", SqlDbType.SmallInt);
            SqlParameter p12 = new SqlParameter("@DepartmentId", SqlDbType.SmallInt);

            p0.Value = addEmployeeViewModel.NationalIDNumber;
            p1.Value = addEmployeeViewModel.LoginID;
            p2.Value = addEmployeeViewModel.Employee.FirstName;
            p3.Value = addEmployeeViewModel.Employee.LastName;
            p4.Value = addEmployeeViewModel.Employee.JobTitle;
            p5.Value = addEmployeeViewModel.BirthDate;
            p6.Value = addEmployeeViewModel.MaritalStatus;
            p7.Value = addEmployeeViewModel.Gender;
            p8.Value = addEmployeeViewModel.HireDate;
            p9.Value = addEmployeeViewModel.SalariedFlag;
            p10.Value = addEmployeeViewModel.VacationHours;
            p11.Value = addEmployeeViewModel.SickLeaveHours;
            p12.Value = addEmployeeViewModel.DepartmentId;

            _ctx.Database.ExecuteSqlCommand($"HumanResources.AddEmployee {p0},{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12}");
            return RedirectToAction("Index");
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