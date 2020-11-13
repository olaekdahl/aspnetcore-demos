using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Models
{
    public class MockRepository : IRepository
    {
        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            return new Customer();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            //throw new NotImplementedException();

            return new Product()
            {
                Id = id,
                IsDiscontinued = false,
                ProductName = "Blue Bike",
                SupplierId = 1,
                UnitPrice = 10.99M
            };
        }

        public IEnumerable<ProductInventory> GetProductInventory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }
    }
}
