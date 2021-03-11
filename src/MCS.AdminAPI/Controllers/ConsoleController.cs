using MCS.Application;
using MCS.DTO;
using MCS.Web.Framework;
using MCS.Web.Framework.AccessControlHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.AdminAPI.Controllers
{
    /// <summary>
    /// 控制台
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ConsoleController : BaseAdminAPIController
    {
        /// <summary>
        /// 获取导航
        /// </summary>
        /// <returns>导航列表</returns>
        [HttpGet("Navigation")]
        [AccessControl(AccessKey = "Navigation")]
        public ActionResult<object> Navigation()
        {
            long roleId = CurrentManager.RoleId;
            var navs = ManagerNavigationApplication.GetNavigationTreeList(roleId);
            return SuccessResult<List<ManagerNavigationModel>>(navs);
        }
    }
}
