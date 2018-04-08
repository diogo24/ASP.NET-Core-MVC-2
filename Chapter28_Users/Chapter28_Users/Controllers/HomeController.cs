using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter28_Users.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() =>
            View(new Dictionary<string, object> { ["Placeholder"] = "Placeholder" });
    }
}
