using Chapter14_ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter14_ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService _uptimeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UptimeService updtimeService, ILogger<HomeController> logger)
        {
            _uptimeService = updtimeService;
            _logger        = logger;
        }

        public ViewResult Index(bool throwException = false)
        {
            _logger.LogDebug($"Handled {Request.Path} at uptime {_uptimeService.Uptime}");

            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{_uptimeService.Uptime}ms"
            });
        }

        public ViewResult Error() => View(nameof(Index),
            new Dictionary<string, string>
            {
                ["Message"] = "This is the Error action"
            });
    }
}
