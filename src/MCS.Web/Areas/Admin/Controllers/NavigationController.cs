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
using MCS.Web.Framework.AccessControlHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NavigationController : BaseAdminController
    {
        [Authorize]
        [AccessControl(AccessKey = "List")]
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 导航列表
        /// </summary>
        /// <returns></returns>
        public JsonResult ListResult()
        {
            var navList = ManagerNavigationApplication.GetNavigations();
            return Json(new Result() { success = true, msg = "", data = navList });
        }

        /// <summary>
        /// 编辑导航
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        [AccessControl(AccessKey = "Edit")]
        public IActionResult Edit(long? id, long? parentId)
        {
            ViewBag.Navigations = ManagerNavigationApplication.GetNavigationModels().Select(a => new SelectListItem() { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == parentId }).ToList();
            ManagerNavigationModel model = ManagerNavigationApplication.GetNavigation(id == null ? 0 : id.Value);
            return View(model);
        }

        /// <summary>
        /// 编辑导航
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessControl(AccessKey = "Edit")]
        public IActionResult Edit(ManagerNavigationModel model)
        {
            ManagerNavigationApplication.UpdateNavigation(model);
            return SuccessResult();
        }

    }
}
