using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Web.Areas.Admin.Models.Manage;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] ManageLoginModel user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                ModelState.AddModelError(nameof(ManageLoginModel), "名称需要填写");
                return View(nameof(Login));
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(user);
        }

    }
}
