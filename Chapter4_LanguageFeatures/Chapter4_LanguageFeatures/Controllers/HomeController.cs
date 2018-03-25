using Chapter4_LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4_LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.TextList = new string[] { "C#", "Language", "Features" };

            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                
                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
                results.Add($@"{nameof(Product.Name)}: {name}, 
                            {nameof(Product.Category)}: {p?.Category}, 
                            {nameof(Product.Price)}: {price:C2}, {nameof(Product.Related)}: {relatedName}");
            }

            ViewBag.Products = results;

            //Dictionary<string, Product> products = new Dictionary<string, Product> {
            //     { "Kayak", new Product { Name = "Kayak", Price = 275M } },
            //     { "Lifejacket", new Product{ Name = "Lifejacket", Price = 48.95M } }
            // };

            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
                ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            };

            ViewBag.ProductsDic = products.Keys;

            
            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            decimal total = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] is decimal d)
                {
                    total += d;
                }

                switch (data[i])
                {
                    case decimal decimalValue:
                        total += decimalValue;
                        break;
                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                }
            }

            ViewBag.Totals = new string[] { $"Total: {total:C2}" };
            
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            decimal cartTotal = cart.TotalPrices();

            ViewBag.CartTotals = new string[] { $"Cart Total: {cartTotal:C2}" };

            Product[] productArray = {
                 new Product {Name = "Kayak", Price = 275M},
                 new Product {Name = "Lifejacket", Price = 48.95M},
                 new Product {Name = "Soccer ball", Price = 19.50M},
                 new Product {Name = "Corner flag", Price = 34.95M}
             };

            //decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            decimal arrayFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal arrayFilterNameTotal = productArray.FilterByName('S').TotalPrices();

            Func<Product, bool> nameFilter = delegate (Product prod) {
                return prod?.Name?[0] == 'S';
            };
            decimal priceFilterTotal = productArray
            .Filter(FilterByPrice)
            .TotalPrices();
            decimal nameFilterTotal = productArray
            .Filter(nameFilter)
            .TotalPrices();

            decimal priceFilterLambdaTotal = productArray
                 .Filter(p => (p?.Price ?? 0) >= 20)
                 .TotalPrices();
            decimal nameFilterLambdaTotal = productArray
            .Filter(p => p?.Name?[0] == 'S')
            .TotalPrices();

            ViewBag.FiltersTotals = new string[] {
                $"Cart Total: {cartTotal:C2}",
                $"Array Total: {arrayTotal:C2}",
                $"Array Filter Total: {arrayFilterTotal:C2}",
                $"Array Filter Name Total: {arrayFilterNameTotal:C2}",

                $"Price Filter Total: {priceFilterTotal:C2}",
                $"Name Filter Total: {nameFilterTotal:C2}",

                $"Price Filter Lambda Total: {priceFilterLambdaTotal:C2}",
                $"Name Filter Lambda Total: {nameFilterLambdaTotal:C2}"
            };

            return View(Product.GetProducts().Select(p => p?.Name));
        }

        public ViewResult IndexLambda() => View(Product.GetProducts().Select(p => p?.Name));

        public ViewResult IndexTypesInference()
        {
            var names = new[] { "Kayak", "Lifejacket", "Soccer ball" };
            return View("IndexLambda", names);
        }

        public ViewResult IndexAnonymousTypes()
        {
            var products = new[] {
             new { Name = "Kayak", Price = 275M },
             new { Name = "Lifejacket", Price = 48.95M },
             new { Name = "Soccer ball", Price = 19.50M },
             new { Name = "Corner flag", Price = 34.95M }
            };
            //return View("IndexLambda", products.Select(p => p.Name));
            return View("IndexLambda", products.Select(p => p.GetType().Name));
        }

        public async Task<ViewResult> IndexAsync()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return View("IndexLambda", new string[] { $"Length: {length}" });
        }

        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }
    }
}
