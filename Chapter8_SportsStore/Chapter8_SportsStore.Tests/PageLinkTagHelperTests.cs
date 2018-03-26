using Chapter8_SportsStore.Infrastructure;
using Chapter8_SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chapter8_SportsStore.Tests
{
    public class PageLinkTagHelperTests
    {
        [Fact]
        public void Can_Generate_Page_Links()
        {
            // Arrange
            var urlHelper = new Mock<IUrlHelper>();
            urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
                 .Returns("Test/Page1")
                 .Returns("Test/Page2")
                 .Returns("Test/Page3");

            var urlHelperFactory = new Mock<IUrlHelperFactory>();
            urlHelperFactory.Setup(s => s.GetUrlHelper(It.IsAny<ActionContext>()))
            .Returns(urlHelper.Object);

            var pageLinkTagHelper = new PageLinkTagHelper(urlHelperFactory.Object)
            {
                PageModel = new PagingInfo {
                    CurrentPage = 2,
                    ItemsPerPage = 10,
                    TotalItems = 28
                } ,
                PageAction = "Test"
            };

            var tagContext = new TagHelperContext(
                 new TagHelperAttributeList(),
                 new Dictionary<object, object>(), "");

            var content = new Mock<TagHelperContent>();
            var output = new TagHelperOutput("div", 
                new TagHelperAttributeList(),
                (cache, encode) => Task.FromResult(content.Object) );

            // Act
            pageLinkTagHelper.Process(tagContext, output);

            // Assert
            Assert.Equal(@"<a href=""Test/Page1"">1</a>"
                 + @"<a href=""Test/Page2"">2</a>"
                 + @"<a href=""Test/Page3"">3</a>",
                 output.Content.GetContent());
        }
    }
}
