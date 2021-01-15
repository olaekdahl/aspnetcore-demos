using EComm.Shared.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.DAL
{
    public class Repository : IRepository
    {
        private ECommDbContext _ctx;
        public Repository(ECommDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddProduct(Product p)
        {
            _ctx.Products.Add(p);
            _ctx.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var p = _ctx.Products.Find(id);
            _ctx.Products.Remove(p);
            _ctx.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        { 
            return _ctx.Customers.ToList();
        }

        public Product GetProduct(int id)
        {
            SqlParameter pid = new SqlParameter("@id", System.Data.SqlDbType.Int);
            pid.Value = id;
            //SqlParameter test = new SqlParameter("@test", System.Data.SqlDbType.Int);
            //test.Value = 10;

            var sqlParams = new SqlParameter[] { pid };
            // _ctx.Products.FromSqlInterpolated($"[dbo].[GetProduct] @id={id}");

            return _ctx.Products.FromSqlRaw("[dbo].[GetProduct] @id", sqlParams).AsEnumerable().Single();
            //return _ctx.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _ctx.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.FromSqlRaw("exec dbo.GetAllProducts").ToListAsync();
            //return await _ctx.Products.ToListAsync();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _ctx.Suppliers.ToList();
        }

        public TopCustomer GetTopCustomer()
        {
            var res = _ctx.TopCustomer.FromSqlRaw(@"select top 1 c.Id, FirstName, LastName, sum(o.TotalAmount) as TotalAmount
                                from Customers as c 
                                join orders as o on o.CustomerId=c.Id
                                group by c.Id, FirstName, LastName
                                order by TotalAmount desc");
            return res.Single();
        }

        public async Task<TopCustomer> GetTopCustomerAsync()
        {
            var res = await _ctx.TopCustomer.FromSqlRaw(@"select top 1 c.Id, FirstName, LastName, sum(o.TotalAmount) as TotalAmount
                                from Customers as c 
                                join orders as o on o.CustomerId=c.Id
                                group by c.Id, FirstName, LastName
                                order by TotalAmount desc").SingleOrDefaultAsync();
            return res;
        }

        public void UpdateProduct(Product product)
        {
            _ctx.Products.Attach(product);
            _ctx.Entry(product).State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
