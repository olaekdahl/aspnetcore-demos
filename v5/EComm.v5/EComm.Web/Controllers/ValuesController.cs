using EComm.Web.Models;
using EComm.Web.Options;
using EComm.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private IRepository _repo;

        private ILogger<ValuesController> _logger;

        public ValuesController(IEmailService email, IOptions<EmailOptions> configuration,
            IRepository repo, ILogger<ValuesController> logger)
        {
            //_server = configuration.Value.Server;
            //_user = configuration.Value.User;
            _repo = repo;
            _logger = logger;
        }

        List<Employee> employees = new List<Employee>()
            {
                new Employee{Id=1,Name="Ola"},
                new Employee{Id=2,Name="Tim"}
            };


        [HttpGet("employees")]
        [ProducesResponseType(200)]
        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }

        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        [HttpGet("employee/{id}")]
        [ProducesResponseType(200)]
        public Employee GetEmployee(int id)
        {
            Employee employee = employees.Where(e => e.Id == id).FirstOrDefault();
            return employee;
        }

        [HttpPost("employee")]
        public IActionResult AddEmployee([FromBody]Employee emp)
        {
            employees.Add(emp);
            return CreatedAtAction("employee", new { id = emp.Id }, emp);
        }

        [HttpPost("test")]
        public Employee AddEmployee()
        { 
            return new Employee();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
