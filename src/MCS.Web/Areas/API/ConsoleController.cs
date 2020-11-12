using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Web.Framework;
using MCS.Web.Framework.BaseControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.API.Controllers
{
    /// <summary>
    /// 控制台
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ConsoleController : BaseAPIController
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