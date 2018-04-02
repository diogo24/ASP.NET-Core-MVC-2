﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17_ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        //public ViewResult Index() => View(DateTime.Now);

        public ViewResult Index()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public ViewResult Result() => View((object)"Hello World");
        //public RedirectResult Redirect() => Redirect("/Example/Index");

        //public RedirectResult Redirect() => RedirectPermanent("/Example/Index");

        //public RedirectToRouteResult Redirect() =>
        //     RedirectToRoute(new
        //     {
        //         controller = "Example",
        //         action = "Index",
        //         ID = "MyID"
        //     });

        public RedirectToActionResult Redirect() => RedirectToAction(nameof(Index));
    }
}
