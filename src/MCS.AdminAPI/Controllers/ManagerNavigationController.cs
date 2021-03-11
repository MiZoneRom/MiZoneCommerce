﻿using MCS.Application;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
using MCS.Web.Framework.AccessControlHelper;
using MCS.Web.Framework.BaseControllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.AdminAPI.Controllers
{
    /// <summary>
    /// 导航
    /// </summary>
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ManagerNavigationController : BaseAPIController
    {
        protected readonly IManagerNavigationService _iManagerNavigationService;

        /// <summary>
        /// 站点设置
        /// </summary>
        /// <param name="iManagerNavigationService"></param>
        public ManagerNavigationController(IManagerNavigationService iManagerNavigationService)
        {
            _iManagerNavigationService = iManagerNavigationService;
        }

        /// <summary>
        /// 获取导航
        /// </summary>
        /// <returns>导航列表</returns>
        [HttpGet]
        [AccessControl(AccessKey = "Navigation")]
        public ActionResult<object> GetNavigationList()
        {
            long roleId = CurrentManager.RoleId;
            var navs = ManagerNavigationApplication.GetNavigationTreeList(roleId);
            return SuccessResult<List<ManagerNavigationModel>>(navs);
        }

        /// <summary>
        /// 获取导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<object> Get(long id)
        {
            ManagerNavigationModel model = ManagerNavigationApplication.GetNavigation(id);
            return SuccessResult<object>(model);
        }

        /// <summary>
        /// 设置导航
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<object> Put(ManagerNavigationInfo model)
        {
            _iManagerNavigationService.UpdateNavigation(model);
            return SuccessResult<object>(null, "更新成功");
        }

        /// <summary>
        /// 删除导航
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<object> Delete(long id)
        {
            return SuccessResult<object>(null, "删除成功");
        }
    }
}
