using MCS.Web.Framework.AccessControlHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.AdminAPI.Controllers
{

    /// <summary>
    /// 管理员
    /// </summary>
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(AccessControlHelperConstants.PolicyName)]
    public class ManagerController : BaseAdminAPIController
    {

        private readonly IConfiguration _configuration;

        public ManagerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <returns>管理员Model</returns>
        [HttpGet]
        [AccessControl(AccessKey = "Manager")]
        public ActionResult<object> Get()
        {
            return Json(new { managerModel = CurrentManager });
        }


    }
}
