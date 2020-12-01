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
        public async Task<AuthenticateResult> AuthenticateAsync()
        {
            var cookie = _context.Request.Cookies["myCookie"];
            if (string.IsNullOrEmpty(cookie))
            {
                return AuthenticateResult.NoResult();
            }
            return AuthenticateResult.Success(this.Deserialize(cookie));
        }

        /// <summary>
        /// 未登录时的处理
        /// </summary>
        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            string redirectUrl;
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
        /// 权限不足时的处理
        /// </summary>
        public Task ForbidAsync(AuthenticationProperties properties)
        {
            _context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
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

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        private AuthenticationTicket Deserialize(string content)
        {
            byte[] byteTicket = Encoding.Default.GetBytes(content);
            return TicketSerializer.Default.Deserialize(byteTicket);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        private string Serialize(AuthenticationTicket ticket)
        {
            byte[] byteTicket = TicketSerializer.Default.Serialize(ticket);
            return Encoding.Default.GetString(byteTicket);
        }

    }
}
