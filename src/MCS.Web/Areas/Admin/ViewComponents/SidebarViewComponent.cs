using MCS.Application;
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
            ViewBag.Navs = NavigationApplication.GetNavigations();
            ViewBag.Manager = CurrentManager;
            return View();
        }
    }
}
