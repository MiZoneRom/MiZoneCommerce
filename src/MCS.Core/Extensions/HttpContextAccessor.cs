using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using UAParser;

namespace MCS.Core
{
    public static class HttpContextAccessor
    {
        public static IHttpContextAccessor Current;
        public static HttpContext HttpContext { get { return Current.HttpContext; } }

        public static ClientInfo UserAgent(this HttpRequest request)
        {
            var parser = Parser.GetDefault();
            return parser.Parse(request.Headers["User-Agent"]);
        }

    }
}
