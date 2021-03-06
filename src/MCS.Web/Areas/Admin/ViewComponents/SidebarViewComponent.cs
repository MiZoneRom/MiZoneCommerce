﻿using MCS.Application;
using MCS.Core;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Areas.Admin.ViewComponents
{
    public class SidebarViewComponent : BaseViewComponents
    {
        public SidebarViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string path = this.HttpContext.Request.Path;
            Log.Debug(path);
            List<DTO.ManagerNavigationModel> navList = ManagerNavigationApplication.GetNavigationTreeList(CurrentManager.RoleId, path);
            ViewBag.Navs = navList;
            ViewBag.Manager = CurrentManager;
            return View();
        }
    }
}
