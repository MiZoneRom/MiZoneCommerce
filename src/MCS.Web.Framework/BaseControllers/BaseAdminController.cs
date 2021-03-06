﻿using MCS.Application;
using MCS.Core.Helper;
using MCS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                    manager = ManagerApplication.GetPlatformManager(Convert.ToInt32(userId));
                if (null == manager)
                {
                    Redirect(Url.Action("Login", new { area = "Admin" }));
                    return null;
                }
                return manager;
            }
        }

    }
}
