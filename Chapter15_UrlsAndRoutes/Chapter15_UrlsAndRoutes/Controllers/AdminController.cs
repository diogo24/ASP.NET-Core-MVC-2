using Chapter15_UrlsAndRoutes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter15_UrlsAndRoutes.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index() => 
            View("Result",
                new Result
                {
                    Controller = nameof(AdminController),
                    Action = nameof(Index)
                });
    }
}
