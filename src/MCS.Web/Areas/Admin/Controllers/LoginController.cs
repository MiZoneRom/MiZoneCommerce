using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.IServices;
using MCS.Web.Areas.Admin.Models.Manage;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        private IManagerService _iManagerService;

        public LoginController(IManagerService iManagerService)
        {
            _iManagerService = iManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("UserName,Password")] ManageLoginModel user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                ModelState.AddModelError(nameof(ManageLoginModel), "名称需要填写");
                return View(nameof(Index));
            }

            var manager = _iManagerService.Login(user.UserName, user.Password);
            if (manager == null)
            {
                ModelState.AddModelError(nameof(ManageLoginModel), "用户名和密码不匹配");
                return View(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(nameof(Index));
        }

    }
}
