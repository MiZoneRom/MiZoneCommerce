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
            //ViewBag.NavigationTypes = EnumHelper.ToDescriptionDictionary<NavigationType>();
            return View();
        }

        //public JsonResult ListResult(NavigationType? type)
        //{
        //    var navList = ManagerNavigationApplication.GetNavigations();
        //    if (type.HasValue && type > 0)
        //    {
        //        navList = navList.Where(a => a.NavType == type).ToList();
        //    }
        //    return Json(new Result() { success = true, msg = "", data = navList });
        //}

        public IActionResult Edit(long? id)
        {
            ViewBag.Navigations = ManagerNavigationApplication.GetNavigationModels().Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString() }).ToList();
            //ViewBag.Actions = NavigationAction.Add.ToSelectList();
            if (id.HasValue)
            {
                ManagerNavigationModel model = ManagerNavigationApplication.GetNavigation(id.Value);
                return View(model);
            }
            return View(new ManagerNavigationModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ManagerNavigationInfo model)
        {
            ServiceProvider.Instance<IManagerNavigationService>.Create.UpdateNavigation(model);
            return SuccessResult();
        }

    }
}
