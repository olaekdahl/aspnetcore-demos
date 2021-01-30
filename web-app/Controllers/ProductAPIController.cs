using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.DAL;
using web_app.Shared.Models;

namespace web_app.Controllers
{
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private IRepository _repo;
        private ILogger<ProductAPIController> _logger;

        public ProductAPIController(IRepository repo,
            ILogger<ProductAPIController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet("/api/product")]
        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        [HttpGet("/api/product/{id}")]
        public Product GetProduct(int id)
        {
            return _repo.GetProduct(id);
        }

        [HttpPost("/api/product")]
        public IActionResult AddProduct([FromBody]Product p)
        {
            var product = _repo.AddProduct2(p);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPost("/api/product3")]
        public IActionResult AddProduct3()
        {
            return Ok();
        }

        [HttpDelete("/api/product")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok();
        }
    }
}
