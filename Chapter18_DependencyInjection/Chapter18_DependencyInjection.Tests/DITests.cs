using Chapter18_DependencyInjection.Controllers;
using Chapter18_DependencyInjection.Infrastructure;
using Chapter18_DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Chapter18_DependencyInjection.Tests
{
    public class DITests
    {
        //[Fact]
        //public void ControllerTest()
        //{
        //    // Arrange
        //    var data = new[] { new Product { Name = "Test", Price = 100 } };
        //    var mock = new Mock<IRepository>();
        //    mock.SetupGet(m => m.Products).Returns(data);
        //    HomeController controller = new HomeController
        //    {
        //        Repository = mock.Object
        //    };

        //    // Act
        //    ViewResult result = controller.Index();

        //    // Assert
        //    Assert.Equal(data, result.ViewData.Model);
        //}

        //[Fact]
        //public void ControllerTest()
        //{
        //    // Arrange
        //    var data = new[] { new Product { Name = "Test", Price = 100 } };
        //    var mock = new Mock<IRepository>();
        //    mock.SetupGet(m => m.Products).Returns(data);
        //    TypeBroker.SetTestObject(mock.Object);
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index();

        //    // Assert
        //    Assert.Equal(data, result.ViewData.Model);
        //}

        //[Fact]
        //public void ControllerTest()
        //{
        //    // Arrange
        //    var data = new[] { new Product { Name = "Test", Price = 100 } };
        //    var mock = new Mock<IRepository>();
        //    mock.SetupGet(m => m.Products).Returns(data);
        //    HomeController controller = new HomeController(mock.Object);

        //    // Act
        //    ViewResult result = controller.Index();

        //    // Assert
        //    Assert.Equal(data, result.ViewData.Model);
        //}
    }
}
