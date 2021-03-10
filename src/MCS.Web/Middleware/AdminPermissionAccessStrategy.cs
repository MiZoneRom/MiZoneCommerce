using MCS.Application;
using MCS.Core;
using MCS.Web.Framework.AccessControlHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MCS.Web
{
    /// <summary>
    /// 资源权限访问控制
    /// </summary>
    public class AdminPermissionAccessStrategy : IResourceAccessStrategy
    {
        private readonly IHttpContextAccessor _accessor;

        public AdminPermissionAccessStrategy(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool IsCanAccess(string accessKey)
        {
            //获取当前登录用户
            var user = _accessor.HttpContext.User;
            //如果没有认证
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            var sidClaim = user.Claims.Where(a => a.Type == ClaimTypes.Sid).FirstOrDefault();
            if (sidClaim == null)
            {
                return false;
            }

            //如果有访问Key
            if (!string.IsNullOrEmpty(accessKey))
            {
                long userId = Convert.ToInt64(sidClaim.Value);
                string controller = _accessor.HttpContext.Request.RouteValues["Controller"].ToString();
                //string view = _accessor.HttpContext.Request.RouteValues["View"].ToString();
                return ManagerApplication.GetManagerAccess(userId, accessKey);
            }

            return true;
        }

        public IActionResult DisallowedCommonResult => new ContentResult
        {
            Content = "No Permission",
            ContentType = "text/plain",
            StatusCode = 403
        };

        public IActionResult DisallowedAjaxResult => new JsonResult(new Framework.BaseControllers.BaseAPIController.Result<object>
        {
            success = false,
            msg = "No Permission",
            code = 403
        });

    }
}
