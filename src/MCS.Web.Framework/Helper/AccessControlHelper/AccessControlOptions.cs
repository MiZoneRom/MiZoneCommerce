using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MCS.Web.Framework.AccessControlHelper
{
    public class AccessControlOptions
    {
        public bool UseAsDefaultPolicy { get; set; }

        public Func<Microsoft.AspNetCore.Http.HttpContext, string> AccessKeyResolver { get; set; } = context =>
            context.Request.Headers.TryGetValue("X-Access-Key", out var val) ? val.ToString() : null;

        public Func<Microsoft.AspNetCore.Http.HttpContext, Task> DefaultUnauthorizedOperation { get; set; }
    }
}
