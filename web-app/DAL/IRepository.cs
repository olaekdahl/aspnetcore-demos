using System.Collections.Generic;
using System.Threading.Tasks;
using web_app.Shared.Models;

namespace web_app.DAL
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        Task<IEnumerable<Product>> GetProductsAsync();
        Product GetProduct(int pid);
        Task<Product> GetProductAsync(int pid);
        void AddProuct(Product product);
        Product AddProduct2(Product product);

        Task<TopCustomer> GetTopCustomerAsync();
        IEnumerable<Supplier> GetSuppliers();
    }
}