﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter28_Users.Controllers
{
    public class ClaimsController : Controller
    {
        [Authorize]
        public ViewResult Index() => View(User?.Claims);
    }
}
