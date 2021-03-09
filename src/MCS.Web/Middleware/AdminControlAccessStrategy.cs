using MCS.Web.Framework.AccessControlHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web
{
    /// <summary>
    /// 控件访问权限控制
    /// </summary>
    public class AdminControlAccessStrategy : IControlAccessStrategy
    {
        private readonly IHttpContextAccessor _accessor;

        public AdminControlAccessStrategy(IHttpContextAccessor httpContextAccessor) => _accessor = httpContextAccessor;

        public bool IsControlCanAccess(string accessKey)
        {
            if ("Never".Equals(accessKey, System.StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            var user = _accessor.HttpContext.User;
            return user.Identity.IsAuthenticated && user.IsInRole("Admin");
        }

    }
}
