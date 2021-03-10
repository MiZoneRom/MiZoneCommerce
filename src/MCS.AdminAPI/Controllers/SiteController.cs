using MCS.Application;
using MCS.DTO;
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
    /// 站点配置
    /// </summary>
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SiteController : BaseAPIController
    {
        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <returns></returns>
        [HttpGet("SiteSettings")]
        public ActionResult<object> SiteSettings()
        {
            SiteSettings siteSettingModel = SiteSettingApplication.SiteSettings;
            return SuccessResult<object>(siteSettingModel);
        }

        /// <summary>
        /// 设置系统设置
        /// </summary>
        /// <param name="siteSettingModel"></param>
        /// <returns></returns>
        [HttpPut("SiteSettings")]
        public ActionResult<object> SiteSettings(SiteSettings siteSettingModel)
        {
            var settings = SiteSettingApplication.SiteSettings;
            settings.SiteName = siteSettingModel.SiteName;
            SiteSettingApplication.SaveChanges();
            return SuccessResult<object>();
        }
    }
}
