﻿using System;

#if NET45

using System.Web.Mvc;
using WeihanLi.Common;
using DependencyResolver = WeihanLi.Common.DependencyResolver;

#else

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

#endif

namespace WeihanLi.AspNetMvc.AccessControlHelper
{
    /// <summary>
    /// 权限控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
#if NET45
    public class AccessControlAttribute : FilterAttribute, IAuthorizationFilter
#else
    public class AccessControlAttribute : Attribute, IAuthorizationFilter
#endif
    {
        public string AccessKey { get; set; }

#if NET45
        public void OnAuthorization(AuthorizationContext filterContext)

#else

        public virtual void OnAuthorization(AuthorizationFilterContext filterContext)
#endif
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));

            var isDefinedNoControl = filterContext.ActionDescriptor.IsDefined(typeof(NoAccessControlAttribute), true);

            if (!isDefinedNoControl)
            {
                IResourceAccessStrategy accessStrategy = null;

#if NET45
                accessStrategy = DependencyResolver.Current.ResolveService<IResourceAccessStrategy>();
#else
                accessStrategy = filterContext.HttpContext.RequestServices.GetRequiredService<IResourceAccessStrategy>();
#endif

                if (accessStrategy == null)
                    throw new ArgumentException("IResourceAccessStrategy not initialized，please register your ResourceAccessStrategy", nameof(IResourceAccessStrategy));

                if (!accessStrategy.IsCanAccess(AccessKey))
                {
                    //if Ajax request
                    filterContext.Result = filterContext.HttpContext.Request.IsAjaxRequest() ?
                        accessStrategy.DisallowedAjaxResult :
                        accessStrategy.DisallowedCommonResult;
                }
            }
        }
    }

#if !NET45

    public static class AjaxRequestExtensions
    {
        public static bool IsAjaxRequest(this Microsoft.AspNetCore.Http.HttpRequest request)
        {
            return request?.Headers != null && string.Equals(request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsDefined(this Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor actionDescriptor,
            Type attributeType, bool inherit)
        {
            if (actionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                if (controllerActionDescriptor.MethodInfo.GetCustomAttribute(attributeType) == null)
                {
                    if (inherit && controllerActionDescriptor.ControllerTypeInfo.GetCustomAttribute(attributeType) != null)
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }

#endif
}
