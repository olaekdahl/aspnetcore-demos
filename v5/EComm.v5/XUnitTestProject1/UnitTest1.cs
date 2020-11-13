using EComm.Web.Controllers;
using EComm.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        // [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        [Fact]
        public void Test1()
        {
            var _repo = new MockRepository();
            var controller = new ProductsController(null, null, _repo, null);

            var result = controller.Details(1);
            Assert.IsAssignableFrom<ViewResult>(result);

            var view = result as ViewResult;
            var model = view.Model as Product;
            Assert.Equal("Blue Bike", model.ProductName);
        }

        [Fact]
        public void Test2()
        {
            var options = new DbContextOptionsBuilder<ECommDbContext>()
            .UseInMemoryDatabase(databaseName: "EFComm")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ECommDbContext(options))
            {
                context.Products.AddRange(new Product
                {
                    Id = 1,
                    IsDiscontinued = false,
                    ProductName = "Blue Bike",
                    SupplierId = 1,
                    UnitPrice = 100.99M
                },
                new Product
                {
                    Id = 2,
                    IsDiscontinued = false,
                    ProductName = "Red Bike",
                    SupplierId = 1,
                    UnitPrice = 110.99M
                });
                
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ECommDbContext(options))
            {
                Repository repo = new Repository(context);
                List<Product> products = repo.GetProducts().ToList();
                var prod = repo.GetProduct(1);

                Assert.Equal(2, products.Count);
                Assert.Equal(1, prod.Id);
            }
        }
    }
}
