using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDemo.Shared.Models;

namespace WebDemo.DAL
{
    public interface IProductRepository : IDisposable
    {
        IQueryable<Product> AllProducts { get; }
        Product Find(int? id);
        void InsertOrUpdateProduct(Product product);
        void InsertOrUpdateCustomer(Customer customer);
        void Delete(int id);
        void Save();

        IQueryable<Order> FindOrders(int id);

        IQueryable<Supplier> AllSuppliers { get; }

        IQueryable<Customer> AllCustomers { get; }


    }


    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> AllProducts
        {
            get { return _context.Products.FromSql("exec dbo.GetProducts"); }
        }

        public IQueryable<Order> FindOrders(int id)
        { 
            IQueryable<Order> orders;
            orders = _context.Orders.Where(p => p.Id == id);
            return orders;
        }

        public Product Find(int? id)
        {
            Product product = new Product();
            //product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            product = _context.Products.FromSql("exec dbo.GetProduct {0}", id).FirstOrDefault();
            return product;
        }

        public void InsertOrUpdateProduct(Product product)
        {
            if (product.Id == default(int))
            {
                // New entity
                _context.Products.Add(product);
            }
            else
            {
                // Existing entity
                _context.Entry(product).State = EntityState.Modified;
            }
        }

        public void InsertOrUpdateCustomer(Customer customer)
        {
            if (customer.Id == default(int))
            {
                // New entity
                _context.Customers.Add(customer);
            }
            else
            {
                // Existing entity
                _context.Entry(customer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var employee = _context.Products.Find(id);
            _context.Products.Remove(employee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IQueryable<Supplier> AllSuppliers
        {
            get
            {
                return _context.Suppliers;
            }
        }

        public IQueryable<Customer> AllCustomers
        {
            get
            {
                return _context.Customers;
            }
        }
    }
}
