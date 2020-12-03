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

        public JsonResult ListResult(NavigationType? type)
        {
            var navList = NavigationApplication.GetNavigations();
            if (type.HasValue && type > 0)
            {
                navList = navList.Where(a => a.Type == type).ToList();
            }
            return Json(new Result() { success = true, msg = "", data = navList });
        }

    }
}
