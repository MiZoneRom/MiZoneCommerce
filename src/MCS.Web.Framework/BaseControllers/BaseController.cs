using MCS.Core.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Web.Framework
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }

        /// <summary>
        /// 设置普通用户登录cookie
        /// </summary>
        /// <param name="userId">登录用户的id</param>
        /// <param name="expiredTime">cookie过期时间</param>
        protected virtual void SetUserLoginCookie(long userId, DateTime? expiredTime = null)
        {
            var cookieValue = UserCookieEncryptHelper.Encrypt(userId, CookieKeysCollection.USERROLE_USER);
            if (expiredTime.HasValue)
                WebHelper.SetCookie(CookieKeysCollection.MCS_USER, cookieValue, expiredTime.Value);
            else
                WebHelper.SetCookie(CookieKeysCollection.MCS_USER, cookieValue);
        }

        /// <summary>
        /// 设置Admin登录cookie
        /// </summary>
        /// <param name="adminId">Admin的id</param>
        /// <param name="expiredTime">cookie过期时间</param>
        protected virtual void SetAdminLoginCookie(long adminId, DateTime? expiredTime = null)
        {
            var cookieValue = UserCookieEncryptHelper.Encrypt(adminId, CookieKeysCollection.USERROLE_ADMIN, 1);
            if (expiredTime.HasValue)
                WebHelper.SetCookie(CookieKeysCollection.PLATFORM_MANAGER, cookieValue, expiredTime.Value);
            else
                WebHelper.SetCookie(CookieKeysCollection.PLATFORM_MANAGER, cookieValue);
        }

    }
}
