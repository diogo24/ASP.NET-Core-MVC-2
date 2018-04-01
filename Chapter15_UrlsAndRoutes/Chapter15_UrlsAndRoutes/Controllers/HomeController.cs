﻿using Chapter15_UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter15_UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => 
            View("Result",
            new Result
            {
                Controller = nameof(HomeController),
                Action     = nameof(Index)
            });

        public ViewResult CustomVariable(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable),
            };
            r.Data["Id"] = id ?? "<no value>"; // RouteData.Values["id"];
            return View("Result", r);
        }
    }
}
