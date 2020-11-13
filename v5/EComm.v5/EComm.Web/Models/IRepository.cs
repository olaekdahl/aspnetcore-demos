using System.Collections.Generic;
using System.Threading.Tasks;

namespace EComm.Web.Models
{
    public interface IRepository
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Product> GetProducts();
        Task<IEnumerable<Product>> GetProductsAsync();
        Product AddProduct(Product product);
        Product GetProduct(int id);
        IEnumerable<ProductInventory> GetProductInventory();
        IEnumerable<Supplier> GetSuppliers();
    }
}