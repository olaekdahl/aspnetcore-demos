using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComm.Shared.Models;

namespace EComm.Web.DAL
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        Task<IEnumerable<Product>> GetProductsAsync();
        Product GetProduct(int id);

        IEnumerable<Customer> GetCustomers();
        TopCustomer GetTopCustomer();
        Task<TopCustomer> GetTopCustomerAsync();
        void UpdateProduct(Product product);

        IEnumerable<Supplier> GetSuppliers();
        void AddProduct(Product p);
        void DeleteProduct(int id);
    }
}
