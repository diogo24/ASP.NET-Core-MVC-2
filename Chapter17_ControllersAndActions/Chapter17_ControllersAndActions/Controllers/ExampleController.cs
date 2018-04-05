using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter17_ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        //public ViewResult Index() => View(DateTime.Now);

        //public ViewResult Index()
        //{
        //    ViewBag.Message = "Hello";
        //    ViewBag.Date = DateTime.Now;
        //    return View();
        //}

        //public ViewResult Result() => View((object)"Hello World");
        //public RedirectResult Redirect() => Redirect("/Example/Index");

        //public RedirectResult Redirect() => RedirectPermanent("/Example/Index");

        //public RedirectToRouteResult Redirect() =>
        //     RedirectToRoute(new
        //     {
        //         controller = "Example",
        //         action = "Index",
        //         ID = "MyID"
        //     });

        //public RedirectToActionResult Redirect() => RedirectToAction(nameof(Index));

        public JsonResult Index() => Json(new[] { "Alice", "Bob", "Joe" });
        public ContentResult IndexContentJSOn()
            => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");

        public ObjectResult IndexObjectResult() 
            => Ok(new string[] { "Alice", "Bob", "Joe" });

        public VirtualFileResult IndexVirtualFileResult()
            => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");

        //public StatusCodeResult IndexNotFound()
        //    => StatusCode(StatusCodes.Status404NotFound);

        public StatusCodeResult IndexNotFound() => NotFound();
    }
}
