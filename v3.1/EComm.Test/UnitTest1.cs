using Ecomm.Data.Models;
using Ecomm.Data.Repository;
using Ecomm.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var repo = new MockRepository();
            var controller = new HomeController(null, repo, null);

            var result = controller.GetPerson(5);
            Assert.IsAssignableFrom<ViewResult>(result);
            var view = result as ViewResult;
            var model = view.Model as Person;
            Assert.Equal("Ola", model.FirstName);
        }
    }
}
