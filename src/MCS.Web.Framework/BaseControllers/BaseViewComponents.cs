using MCS.Application;
using MCS.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MCS.Web.Framework
{
    public abstract class BaseViewComponents : ViewComponent
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
                var userId = this.UserClaimsPrincipal.FindFirstValue(ClaimTypes.Sid);
                if (!string.IsNullOrEmpty(userId))
                    manager = ManagerApplication.GetPlatformManager(Convert.ToInt32(userId));
                return manager;
            }
        }

    }
}
