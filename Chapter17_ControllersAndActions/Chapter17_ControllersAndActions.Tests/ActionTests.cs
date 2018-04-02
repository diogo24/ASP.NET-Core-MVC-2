using Chapter17_ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Chapter17_ControllersAndActions.Tests
{
    public class ActionTests
    {
        [Fact]
        public void ViewSelected()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.ReceiveForm("Adam", "London");
            // Assert
            Assert.Equal("Result", result.ViewName);
        }

        //[Fact]
        //public void ModelObjectType()
        //{
        //    //Arrange
        //    ExampleController controller = new ExampleController();
        //    // Act
        //    ViewResult result = controller.Index();
        //    // Assert
        //    Assert.IsType<System.DateTime>(result.ViewData.Model);
        //}

        [Fact]
        public void ModelObjectType()
        {
            //Arrange
            ExampleController controller = new ExampleController();
            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.IsType<string>(result.ViewData["Message"]);
            Assert.Equal("Hello", result.ViewData["Message"]);
            Assert.IsType<System.DateTime>(result.ViewData["Date"]);
        }

        //[Fact]
        //public void Redirection()
        //{
        //    // Arrange
        //    ExampleController controller = new ExampleController();
        //    // Act
        //    RedirectResult result = controller.Redirect();
        //    // Assert
        //    Assert.Equal("/Example/Index", result.Url);
        //    Assert.True(result.Permanent);
        //}

        //[Fact]
        //public void Redirection()
        //{
        //    // Arrange
        //    ExampleController controller = new ExampleController();
        //    // Act
        //    RedirectToRouteResult result = controller.Redirect();
        //    // Assert
        //    Assert.False(result.Permanent);
        //    Assert.Equal("Example", result.RouteValues["controller"]);
        //    Assert.Equal("Index", result.RouteValues["action"]);
        //    Assert.Equal("MyID", result.RouteValues["ID"]);
        //}

        [Fact]
        public void Redirection()
        {
            // Arrange
            ExampleController controller = new ExampleController();
            // Act
            RedirectToActionResult result = controller.Redirect();
            // Assert
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ActionName);
        }
    }
}
