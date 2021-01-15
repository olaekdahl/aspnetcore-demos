using EComm.Shared.Models;
using EComm.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Controllers
{
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private IRepository _repo;

        public ProductAPIController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("/api/product")]
        public IEnumerable<Product> Test()
        {
            return _repo.GetProducts();
        }

        [HttpGet("/api/product/{id}")]
        public Product GetProduct(int id)
        {
            return _repo.GetProduct(id);
        }

        [HttpDelete("/api/product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
            return new NoContentResult();
        }

        [HttpPost("/api/product")]
        public IActionResult AddProduct(Product p)
        {
            _repo.AddProduct(p);
            return CreatedAtAction("Test", new { id = p.ProductId }, p);
        }

    }
}
