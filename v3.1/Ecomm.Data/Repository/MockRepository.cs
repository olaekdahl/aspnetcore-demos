using Ecomm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Data.Repository
{
    public class MockRepository : IRepository
    {
        public Product FindProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int id)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { Id = 1, FirstName = "Ola" });
            people.Add(new Person() { Id = 2, FirstName = "Tim" });
            Person person = (from p in people
                               where p.Id == id
                               select p).SingleOrDefault();
            return person;
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person p)
        {
            throw new NotImplementedException();
        }
    }
}
