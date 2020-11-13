using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace EComm.Web.Models
{
    public class Repository : IRepository
    {
        private ECommDbContext _ctx;
        private InventoryDbContext _invCtx;
        public Repository(ECommDbContext ctx, InventoryDbContext invCtx)
        {
            _ctx = ctx;
            _invCtx = invCtx;
        }

        public Repository(ECommDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _ctx.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _ctx.Customers.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _ctx.Products.ToList();
        }

        public Product AddProduct(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
            // Product p = _ctx.Products.Where(p => p.ProductName.Equals(product.ProductName)).SingleOrDefault();
            return product;
        }

        public Product GetProduct(int id)
        {
            return _ctx.Products.Find(id);
        }

        public IEnumerable<ProductInventory> GetProductInventory()
        {
            return _invCtx.ProductInventory.ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _ctx.Suppliers.ToList();
        }
    }
}
