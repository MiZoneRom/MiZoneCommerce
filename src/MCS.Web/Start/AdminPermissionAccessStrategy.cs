using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeihanLi.AspNetMvc.AccessControlHelper;

namespace MCS.Web
{
    public class AdminPermissionAccessStrategy : IResourceAccessStrategy
    {
        private readonly IHttpContextAccessor _accessor;

        public AdminPermissionAccessStrategy(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool IsCanAccess(string accessKey)
        {
            var user = _accessor.HttpContext.User;
            return user.Identity.IsAuthenticated && user.IsInRole("Admin");
        }

        public IActionResult DisallowedCommonResult => new ContentResult
        {
            Content = "No Permission",
            ContentType = "text/plain",
            StatusCode = 403
        };

        public IActionResult DisallowedAjaxResult => new JsonResult(new Framework.BaseControllers.BaseAPIController.Result<object>
        {
            msg = "No Permission",
            code = 998
        });

    }
}
