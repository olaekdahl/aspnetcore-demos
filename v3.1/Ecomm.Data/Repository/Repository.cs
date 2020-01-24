using Ecomm.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Data.Repository
{
    public class Repository : IRepository
    {
        private DemoDbCtx _demoCtx;
        private ProductDbCtx _prodCtx;

        public Repository(DemoDbCtx demoCtx, ProductDbCtx prodCtx)
        {
            _demoCtx = demoCtx;
            _prodCtx = prodCtx;
        }

        public Person GetPerson(int id)
        {
            return _demoCtx.People.Find(id);
        }

        public void UpdatePerson(Person p)
        {
            _demoCtx.People.Attach(p);
            _demoCtx.Entry(p).State = EntityState.Modified;
            _demoCtx.SaveChanges();

        }

        public Product FindProduct(int id)
        {
            return _prodCtx.Products.Find(id);
        }

        public async Task<Product> FindProductAsync(int id)
        {
            return await _prodCtx.Products.FindAsync(id);
        }

        public IEnumerable<Person> GetPeople()
        {
            return _demoCtx.People.ToList();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var result = await _prodCtx.Products.ToListAsync();
            
            //some other code...
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _prodCtx.Categories.ToList();
        }
    }
}
