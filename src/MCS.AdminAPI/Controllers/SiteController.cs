using MCS.Application;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
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
        protected readonly IManagerNavigationService _iManagerNavigationService;

        /// <summary>
        /// 站点设置
        /// </summary>
        /// <param name="iManagerNavigationService"></param>
        public SiteController(IManagerNavigationService iManagerNavigationService)
        {
            _iManagerNavigationService = iManagerNavigationService;
        }

        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<object> GetSiteSettings()
        {
            SiteSettings siteSettingModel = SiteSettingApplication.SiteSettings;
            return SuccessResult<object>(siteSettingModel);
        }

        /// <summary>
        /// 设置系统设置
        /// </summary>
        /// <param name="siteSettingModel"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<object> UpdateSiteSettings(SiteSettings siteSettingModel)
        {
            var settings = SiteSettingApplication.SiteSettings;
            settings.SiteName = siteSettingModel.SiteName;
            SiteSettingApplication.SaveChanges();
            return SuccessResult<object>();
        }

    }
}
