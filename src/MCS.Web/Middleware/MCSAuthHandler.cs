using MCS.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Web
{
    public class MCSAuthHandler : IAuthenticationHandler, IAuthenticationSignInHandler, IAuthenticationSignOutHandler
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
            string redirectUrl = "";
            if (_area.ToLower() == "web")
            {
                redirectUrl = "/Login";
            }
            else
            {
                redirectUrl = $"/{_area}/Login";
            }
            string returnUrl = _context.Request.Path;
            if (!string.IsNullOrEmpty(returnUrl))
            {
                redirectUrl += $"?ReturnUrl={returnUrl}";
            }
            _context.Response.Redirect(redirectUrl);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            var ticket = new AuthenticationTicket(user, properties, SchemeName);
            _context.Response.Cookies.Append("myCookie", this.Serialize(ticket));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public Task SignOutAsync(AuthenticationProperties properties)
        {
            _context.Response.Cookies.Delete("myCookie");
            return Task.CompletedTask;
        }

        private AuthenticationTicket Deserialize(string content)
        {
            byte[] byteTicket = Encoding.Default.GetBytes(content);
            return TicketSerializer.Default.Deserialize(byteTicket);
        }

        private string Serialize(AuthenticationTicket ticket)
        {
            byte[] byteTicket = TicketSerializer.Default.Serialize(ticket);
            return Encoding.Default.GetString(byteTicket);
        }

    }
}
