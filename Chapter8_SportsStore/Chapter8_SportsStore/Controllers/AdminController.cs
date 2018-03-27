using Chapter8_SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter8_SportsStore.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Products);

        [HttpGet]
        public ViewResult Edit(int productId) =>
            View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

        [HttpPost]
        public IActionResult Edit(Product product) {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public RedirectToActionResult Delete(int productID)
        {
            var entity = repository.DeleteProduct(productID);
            if (entity != null)
            {
                TempData["message"] = $"{entity.Name} was deleted";
            }

            return RedirectToAction("Index");
        }
    }
}
