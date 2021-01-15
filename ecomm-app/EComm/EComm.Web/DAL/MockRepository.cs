using EComm.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.DAL
{
    public class MockRepository : IRepository
    {
        private List<Product> products;
        public MockRepository()
        {
            products = new List<Product>()
            {
                new Product(){ProductId=1,Name="Yellow Bike", Price=100.99m},
                new Product(){ProductId=2,Name="Blue Bike", Price=200.99m}
            };
        }
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProduct(int id)
        {
            var product = (from p in products
                           where p.ProductId == id
                           select p).Single();

            return product;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public TopCustomer GetTopCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<TopCustomer> GetTopCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
