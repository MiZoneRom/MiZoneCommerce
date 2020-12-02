﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseAdminController
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
