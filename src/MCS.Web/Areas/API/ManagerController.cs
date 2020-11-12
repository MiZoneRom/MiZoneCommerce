﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCS.Web.Framework.BaseControllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MCS.Web.Areas.API.Controllers
{
    /// <summary>
    /// 管理员
    /// </summary>
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
    public class ManagerController : BaseAPIController
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
        public ActionResult<object> Get()
        {
            return Json(new { managerModel = CurrentManager });
        }

    }
}