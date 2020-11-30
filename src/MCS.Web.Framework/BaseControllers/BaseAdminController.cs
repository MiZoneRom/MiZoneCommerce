using MCS.Application;
using MCS.Core.Helper;
using MCS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Web.Framework
{
    public abstract class BaseAdminController : BaseController
    {
        ManagerInfo manager = null;

        public ManagerInfo CurrentManager
        {
            get
            {
                if (manager != null)
                {
                    return manager;
                }

                var userId = UserCookieEncryptHelper.Decrypt(WebHelper.GetCookie(CookieKeysCollection.PLATFORM_MANAGER), CookieKeysCollection.USERROLE_ADMIN, true);
                if (userId > 0)
                    manager = ManagerApplication.GetPlatformManager(userId);
                if (null == manager)
                {
                    WebHelper.DeleteCookie(CookieKeysCollection.PLATFORM_MANAGER);
                    Redirect(Url.Action("Login", new { area = "Admin" }));
                    return null;
                }
                return manager;
            }
        }

    }
}
