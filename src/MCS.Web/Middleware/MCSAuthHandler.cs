using MCS.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MCS.Web
{
    public class MCSAuthHandler : IAuthenticationHandler
    {
        public const string SchemeName = "MCSAuth";
        protected AuthenticationScheme _scheme;
        protected HttpContext _context;
        protected string _area;

        /// <summary>
        /// 初始化认证
        /// </summary>
        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            _scheme = scheme;
            _context = context;
            _area = _context.Request.RouteValues["area"] == null ? "" : _context.Request.RouteValues["area"].ToString();
            return Task.CompletedTask;
        }

        /// <summary>
        /// 认证处理
        /// </summary>
        public Task<AuthenticateResult> AuthenticateAsync()
        {

            if (!_context.User.Identity.IsAuthenticated)
            {
                return Task.FromResult(AuthenticateResult.Fail("未登陆"));
            }

            var ticket = GetAuthTicket("test", "test");
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

        AuthenticationTicket GetAuthTicket(string name, string role)
        {
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Role, role),
            }, "My_Auth");

            var principal = new ClaimsPrincipal(claimsIdentity);
            return new AuthenticationTicket(principal, _scheme.Name);
        }

        /// <summary>
        /// 权限不足时的处理
        /// </summary>
        public Task ForbidAsync(AuthenticationProperties properties)
        {
            _context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 未登录时的处理
        /// </summary>
        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            _context.Response.Redirect($"/{_area}/Login");
            return Task.CompletedTask;
        }

    }
}
