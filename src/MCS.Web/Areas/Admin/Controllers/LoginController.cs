using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MCS.CommonModel;
using MCS.Core.Helper;
using MCS.IServices;
using MCS.Web.Areas.Admin.Models.Manage;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : BaseController
    {

        /// <summary>
        /// 同一用户名无需验证的的尝试登录次数
        /// </summary>
        const int TIMES_WITHOUT_CHECKCODE = 3;

        private readonly IConfiguration _iConfiguration;
        private readonly IManagerService _iManagerService;

        public LoginController(IConfiguration iConfiguration, IManagerService iManagerService)
        {
            _iConfiguration = iConfiguration;
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

            CheckCheckCode(user.UserName, user.CheckCode);

            var managerModel = _iManagerService.Login(user.UserName, user.Password);
            var jwtSection = _iConfiguration.GetSection("jwt");
            int tokenExpires = Convert.ToInt32(jwtSection.GetSection("TokenExpires").Value);
            int refreshTokenExpires = Convert.ToInt32(jwtSection.GetSection("RefreshTokenExpires").Value);

            if (managerModel == null)
            {
                int errorTimes = SetErrorTimes(user.UserName);
                return ErrorResult("用户名和密码不匹配");
            }

            JwtTokenHelper jwtTokenHelper = new JwtTokenHelper();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Actor, "Admin"),
                new Claim(ClaimTypes.Name, managerModel.UserName),
                new Claim(ClaimTypes.Role, managerModel.RoleId.ToString()),
                new Claim(ClaimTypes.Sid, managerModel.Id.ToString()),
            };

            string token = jwtTokenHelper.GetToken(claims);
            string refreshToken = jwtTokenHelper.RefreshToken();
            string tokenExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(tokenExpires));
            string refreshToeknExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(refreshTokenExpires));

            _iManagerService.RemoveExpiresToken(managerModel.Id);
            _iManagerService.AddRefeshToken(token, refreshToken, managerModel.Id, refreshTokenExpires);

            HttpContext.Response.Cookies.Append(CookieKeysCollection.MANAGER_TOKEN, token);
            HttpContext.Response.Cookies.Append(CookieKeysCollection.MANAGER_REFRESH_TOKEN, refreshToken);

            var identity = new ClaimsIdentity(CookieKeysCollection.MANAGER);
            identity.AddClaims(claims);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            //清除输入错误记录次数
            ClearErrorTimes(user.UserName);

            if (ModelState.IsValid)
            {
                return RedirectResult("/Admin/Home");
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
