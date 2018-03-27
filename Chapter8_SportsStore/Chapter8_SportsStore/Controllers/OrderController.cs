using Chapter8_SportsStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter8_SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly Cart cartService;

        public OrderController(IOrderRepository repository, Cart cartService)
        {
            orderRepository = repository;
            this.cartService = cartService;
        }

        public ViewResult List() => View(orderRepository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = orderRepository.Orders
            .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                orderRepository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cartService.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (!ModelState.IsValid)
            {
                return View(order);
            }

            order.Lines = cartService.Lines.ToList();
            orderRepository.SaveOrder(order);
            return RedirectToAction(nameof(Completed));
        }

        public ViewResult Completed()
        {
            cartService.Clear();
            return View();
        }
    }
}
