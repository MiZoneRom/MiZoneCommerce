using MCS.Application;
using MCS.Core;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Areas.Admin.ViewComponents
{
    public class ContentHeaderViewComponent : BaseViewComponents
    {
        public ContentHeaderViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string path = this.HttpContext.Request.Path;
            ViewBag.PageName = NavigationApplication.GetPageName(path);
            return View();
        }
    }
}
