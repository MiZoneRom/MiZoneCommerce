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
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SiteController : BaseAPIController
    {
        [HttpGet("SiteSettings")]
        public ActionResult<object> SiteSettings()
        {
            SiteSettings siteSettingModel = SiteSettingApplication.SiteSettings;
            return SuccessResult<object>(siteSettingModel);
        }

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
