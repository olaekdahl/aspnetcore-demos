using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models;

namespace DemoApp.DAL
{
    public interface IRepository
    {
        IQueryable<Product> Products { get; }
        IQueryable<Category> Categories { get; }
        Product FindProduct(int pid);
        int AddProduct(Product p);
    }
    public class Repository : IRepository
    {
        private ProductDbContext _ctx;

        public Repository(ProductDbContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Product> Products
        {
            get
            {
                //List<Product> products = new List<Product>();
                //products.Add(new Product { Id = 1, Color = "Yellow", Name = "Bike" });
                //products.Add(new Product { Id = 2, Color = "Red", Name = "Helmet" });

                return _ctx.Products.AsQueryable();
            }
        }

        public IQueryable<Category> Categories
        {
            get
            {
                return _ctx.Categories.AsQueryable();
            }
        }

        public int AddProduct(Product p)
        {
            _ctx.Products.Add(p);
            int id = _ctx.SaveChanges();
            return id;
        }

        public Product FindProduct(int pid)
        {
            return _ctx.Products.Find(pid);
        }
    }
}
