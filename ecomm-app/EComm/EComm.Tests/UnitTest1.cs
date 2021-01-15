using EComm.Shared.Models;
using EComm.Web.Controllers;
using EComm.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace EComm.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var repo = new MockRepository();
            var controller = new HomeController(repo, null);
            var result = controller.Details(1);
            Assert.IsAssignableFrom<ViewResult>(result);

            var view = result as ViewResult;
            var model = view.Model as Product;

            Assert.Equal("Yellow Bike", model.Name);
        }
    }
}
