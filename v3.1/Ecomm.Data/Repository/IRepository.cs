using Ecomm.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecomm.Data.Repository
{
    public interface IRepository
    {
        IEnumerable<Person> GetPeople();
        Task<IEnumerable<Product>> GetProducts();
        Person GetPerson(int id);
        Product FindProduct(int id);
        Task<Product> FindProductAsync(int id);
        IEnumerable<Category> GetCategories();
        void UpdatePerson(Person p);
    }
}