using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MCS.CommonModel;
using MCS.IServices;
using MCS.Web.Areas.Admin.Models.Manage;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : BaseController
    {

        /// <summary>
        /// 同一用户名无需验证的的尝试登录次数
        /// </summary>
        const int TIMES_WITHOUT_CHECKCODE = 3;

        private IManagerService _iManagerService;

        public LoginController(IManagerService iManagerService)
        {
            _iManagerService = iManagerService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("UserName,Password,Remember,CheckCode")] ManageLoginModel user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                ModelState.AddModelError(nameof(ManageLoginModel), "名称需要填写");
                return View(nameof(Index));
            }

            CheckCheckCode(user.UserName, user.CheckCode);

            var manager = _iManagerService.Login(user.UserName, user.Password);
            if (manager == null)
            {
                ModelState.AddModelError(nameof(ManageLoginModel), "用户名和密码不匹配");
                int errorTimes = SetErrorTimes(user.UserName);
                return View(nameof(Index));
            }

            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, manager.UserName), new Claim(ClaimTypes.NameIdentifier, manager.Id.ToString()) };

            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieKeysCollection.PLATFORM_MANAGER));

            await HttpContext.SignInAsync(MCSAuthHandler.SchemeName, userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                IsPersistent = false,
                AllowRefresh = false
            });

            //清除输入错误记录次数
            ClearErrorTimes(user.UserName);

            if (ModelState.IsValid)
            {
                return RedirectResult("");
                //return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View(nameof(Index));
        }

        /// <summary>
        /// 检查错误次数
        /// </summary>
        /// <param name="username"></param>
        /// <param name="checkCode"></param>
        void CheckCheckCode(string username, string checkCode)
        {
            var errorTimes = GetErrorTimes(username);
            if (errorTimes >= TIMES_WITHOUT_CHECKCODE)
            {
                if (string.IsNullOrWhiteSpace(checkCode))
                    throw new Core.MCSException("30分钟内登录错误3次以上需要提供验证码");

                string systemCheckCode = HttpContext.Session.GetString("password");
                if (systemCheckCode.ToLower() != checkCode.ToLower())
                    throw new Core.MCSException("验证码错误");

                //生成随机验证码，强制使验证码过期（一次提交必须更改验证码）
                HttpContext.Session.SetString("checkCode", Guid.NewGuid().ToString());
            }
        }

        /// <summary>
        /// 清除错误次数
        /// </summary>
        /// <param name="username"></param>
        void ClearErrorTimes(string username)
        {
            Core.Cache.Remove(CacheKeyCollection.ManagerLoginError(username));
        }

        /// <summary>
        /// 设置错误登录次数
        /// </summary>
        /// <param name="username"></param>
        /// <returns>返回最新的错误登录次数</returns>
        int SetErrorTimes(string username)
        {
            var times = GetErrorTimes(username) + 1;
            Core.Cache.Insert(CacheKeyCollection.ManagerLoginError(username), times, DateTime.Now.AddMinutes(30.0));//写入缓存
            return times;
        }

        /// <summary>
        /// 获取指定用户名在30分钟内的错误登录次数
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int GetErrorTimes(string username)
        {
            var timesObject = Core.Cache.Get<int>(CacheKeyCollection.ManagerLoginError(username));
            return timesObject;
        }

    }
}
