using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MCS.Web.Framework.AccessControlHelper
{
    /// <summary>
    /// 无需访问权限
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoAccessControlAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}
