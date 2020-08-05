using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Application;
using MCS.DTO;
using MCS.Web.Framework.BaseControllers;
using Microsoft.AspNetCore.Mvc;

namespace MCS.Web.Areas.API
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SiteController : BaseController
    {
        [HttpGet("SiteSettings")]
        public ActionResult<object> SiteSettings()
        {
            SiteSettings siteSettingModel = SiteSettingApplication.SiteSettings;
            return SuccessResult<object>(siteSettingModel);
        }
    }
}
