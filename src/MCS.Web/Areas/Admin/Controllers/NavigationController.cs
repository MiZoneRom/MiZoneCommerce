using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Application;
using MCS.CommonModel;
using MCS.Core;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NavigationController : BaseAdminController
    {
        [Authorize]
        public IActionResult List()
        {
            ViewBag.NavigationTypes = EnumHelper.ToDescriptionDictionary<NavigationType>();
            return View();
        }

        public JsonResult ListResult()
        {
            var navList = NavigationApplication.GetNavigations();
            return Json(new Result() { success = true, msg = "添加成功！", data = navList });
        }

    }
}
