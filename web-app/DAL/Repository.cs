using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Shared.Models;

namespace web_app.DAL
{
    public class Repository : IRepository
    {
        private ECommDbContext _ctx;
        public Repository(ECommDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _ctx.Products.ToList();
        }

        public Product GetProduct(int pid)
        {
            return _ctx.Products.Find(pid);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int pid)
        {
            return await _ctx.Products.FindAsync(pid);
        }

        public void AddProuct(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
        }

        //       CREATE PROCEDURE[dbo].[AddProduct]
        //       @name nvarchar(50),
        //@price decimal (12,2),
        //@supplierId int,
        //@package nvarchar(30),
        //@isDiscontinued bit

        public Product AddProduct2(Product product)
        {
            var res = _ctx.Products.FromSqlInterpolated($@"exec dbo.AddProduct 
                                @name={product.ProductName},
                                @price={product.Price}, @supplierId={product.SupplierId},
                                @package={product.Package}, @isDiscontinued={product.IsDiscontinued}").AsEnumerable().Single();
            return res;
        }

        public async Task<TopCustomer> GetTopCustomerAsync()
        {
            return await _ctx.TopCustomer.FromSqlRaw(@"select top 1 c.Id, FirstName, LastName, sum(o.TotalAmount) as TotalAmount
                                from Customers as c 
                                join orders as o on o.CustomerId=c.Id
                                group by c.Id, FirstName, LastName
                                order by TotalAmount desc").SingleAsync();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _ctx.Suppliers.ToList();
        }
    }
}
