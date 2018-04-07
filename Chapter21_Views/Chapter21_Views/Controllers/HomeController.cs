using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter21_Views.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index()
        //{
        //    ViewBag.Message = "Hello, World";
        //    ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");
        //    return View("DebugData");
        //}

        //public ViewResult Index() => View(new string[] { "Apple", "Orange", "Pear" });

        public ViewResult Index() => View("MyView", new string[] { "Apple", "Orange", "Pear" });

        public ViewResult List() => View();
    }
}
