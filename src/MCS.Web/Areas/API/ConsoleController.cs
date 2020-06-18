using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Web.Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.API.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ConsoleController : Controller
    {
        /// <summary>
        /// 获取导航
        /// </summary>
        /// <returns></returns>
        [HttpGet("Navigation")]
        public ActionResult<object> Navigation()
        {
            var navs = PrivilegeHelper.AdminPrivilegesDefault.Privilege;
            return Json(new { router = navs });
        }
    }
}