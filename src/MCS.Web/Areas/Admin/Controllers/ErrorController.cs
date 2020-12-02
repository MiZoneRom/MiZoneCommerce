using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public IActionResult InternalServerError()
        {
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }

    }
}
