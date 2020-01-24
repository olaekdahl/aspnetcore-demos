using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomm.Data.Models;
using Ecomm.Data.Repository;
using Ecomm.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm.Web.Controllers
{
    public class PersonController : Controller
    {
        private IRepository _repo;
        public PersonController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetPeople());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_repo.GetPerson(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult EditPerson(Person p)
        {
            _repo.UpdatePerson(p);
            return RedirectToAction("Index");
        }
    }
}