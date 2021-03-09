using MCS.Web.Framework;
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
    [Authorize]
    public class ConsoleController : BaseAdminAPIController
    {
        /// <summary>
        /// 获取导航
        /// </summary>
        /// <returns></returns>
        [HttpGet("Navigation")]
        public ActionResult<object> Navigation()
        {
            var navs = PrivilegeHelper.AdminPrivilegesDefault.Privilege;
            return SuccessResult<object>(navs);
        }
    }
}
