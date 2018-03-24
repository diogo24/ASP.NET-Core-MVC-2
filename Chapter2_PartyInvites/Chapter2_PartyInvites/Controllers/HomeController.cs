using Chapter2_PartyInvites.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter2_PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm() {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: store response from guest
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }

            return View(guestResponse);
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(s => s.WillAttend == true));
        }
    }
}
