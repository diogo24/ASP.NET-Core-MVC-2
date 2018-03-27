using Chapter8_SportsStore.Models;
using Chapter8_SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chapter8_SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            Expression<Func<Product, bool>> categoryFilter = p => category == null || p.Category == category;
            var products = repository.Products
                .Where(categoryFilter)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);

            var pageInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count(categoryFilter)
            };

            var productsListVM = new ProductsListViewModel
            {
                Products        = products,
                PagingInfo      = pageInfo,
                CurrentCategory = category
            };

            return View(productsListVM);
        }
    }
}
