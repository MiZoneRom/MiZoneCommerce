using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Core
{
    public static class HttpContextAccessor
    {
        public static IHttpContextAccessor Current;
        public static HttpContext HttpContext { get { return Current.HttpContext; } }
    }
}
