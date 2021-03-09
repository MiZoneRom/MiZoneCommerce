using MCS.Application;
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
        /// <returns></returns>
        [HttpGet("Navigation")]
        [AccessControl(AccessKey = "Contact")]
        public ActionResult<object> Navigation()
        {
            long roleId = CurrentManager.RoleId;
            var navs = NavigationApplication.GetNavigationByRoleId(roleId);
            return SuccessResult<object>(navs);
        }
    }
}
