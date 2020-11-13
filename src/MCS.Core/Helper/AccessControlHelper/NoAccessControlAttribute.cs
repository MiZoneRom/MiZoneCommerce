﻿using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MCS.Core.AccessControlHelper
{
    /// <summary>
    /// NoAccessControl
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NoAccessControlAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}