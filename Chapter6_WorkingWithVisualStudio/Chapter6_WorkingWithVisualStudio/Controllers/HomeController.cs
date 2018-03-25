using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chapter6_WorkingWithVisualStudio.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chapter6_WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(SimpleRepository.SharedRepository.Products.Where(p => p?.Price < 50));
    }
}
