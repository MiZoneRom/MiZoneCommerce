using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Application;
using MCS.CommonModel;
using MCS.Core;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                navList = navList.Where(a => a.NavType == type).ToList();
            }
            return Json(new Result() { success = true, msg = "", data = navList });
        }

        public IActionResult Edit(long? id)
        {
            ViewBag.Navigations = NavigationApplication.GetNavigationModels().Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString() }).ToList();
            ViewBag.Actions = NavigationAction.Add.ToSelectList();
            if (id.HasValue)
            {
                NavigationModel model = NavigationApplication.GetNavigation(id.Value);
                return View(model);
            }
            return View(new NavigationModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NavigationInfo model)
        {
            ServiceProvider.Instance<INavigationService>.Create.UpdateNavigation(model);
            return SuccessResult();
        }

    }
}
