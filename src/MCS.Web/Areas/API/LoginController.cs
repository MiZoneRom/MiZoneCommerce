using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MCS.IServices;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using MCS.DTO;
using MCS.Web.Framework.BaseControllers;
using MCS.Entities;
using MCS.Core.Helper;

namespace MCS.Web.Areas.API.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {

        private readonly IConfiguration _configuration;
        private readonly IManagerService _manager;

        public LoginController(IConfiguration configuration, IManagerService manager)
        {
            _configuration = configuration;
            _manager = manager;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<object> Get(string username, string password)
        {

            ManagersInfo managerModel = _manager.Login(username, password);
            var jwtSection = _configuration.GetSection("jwt");
            int tokenExpires = Convert.ToInt32(jwtSection.GetSection("TokenExpires").Value);
            int refreshTokenExpires = Convert.ToInt32(jwtSection.GetSection("RefreshTokenExpires").Value);

            if (managerModel == null)
            {
                return ErrorResult<int>("用户名或密码错误");
            }

            JwtTokenHelper jwtTokenHelper = new JwtTokenHelper();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, managerModel.UserName),
                new Claim(ClaimTypes.Role, managerModel.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sid, managerModel.Id.ToString()),
            };

            string token = jwtTokenHelper.GetToken(claims);
            string refreshToken = jwtTokenHelper.RefreshToken();
            string tokenExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(tokenExpires));
            string refreshToeknExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(refreshTokenExpires));

            _manager.AddRefeshToken(token, refreshToken, managerModel.Id, refreshTokenExpires);

            return SuccessResult<object>(new { token = token, refreshToken = refreshToken, userName = managerModel.UserName, expires = tokenExpired, refreshExpires = refreshToeknExpired });
        }

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("RefreshToken")]
        public ActionResult<object> RefreshToken([FromBody] RefreshTokenModel entity)
        {
            ManagersInfo managerModel = CurrentManager;
            var jwtSection = _configuration.GetSection("jwt");
            int tokenExpires = Convert.ToInt32(jwtSection.GetSection("TokenExpires").Value);
            int refreshTokenExpires = Convert.ToInt32(jwtSection.GetSection("RefreshTokenExpires").Value);
            string token = entity.token;
            string refreshToken = entity.refresh_token;

            if (managerModel == null)
            {
                return ErrorResult<int>("用户登录过期");
            }

            ManagerTokenInfo tokenModel = _manager.GetToken(managerModel.Id);

            if (tokenModel == null)
            {
                return ErrorResult<int>("认证过期");
            }

            _manager.RemoveToken(managerModel.Id);

            JwtTokenHelper jwtTokenHelper = new JwtTokenHelper();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, managerModel.UserName),
                new Claim(ClaimTypes.Role, managerModel.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sid, managerModel.Id.ToString()),
            };

            string newToken = jwtTokenHelper.GetToken(claims);
            string newRefreshToken = jwtTokenHelper.RefreshToken();

            string tokenExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(tokenExpires));
            string refreshToeknExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(refreshTokenExpires));

            _manager.AddRefeshToken(newToken, newRefreshToken, managerModel.Id, refreshTokenExpires);

            return SuccessResult<object>(new { token = newToken, refreshToken = newRefreshToken, userName = managerModel.UserName, expires = tokenExpired, refreshExpires = refreshToeknExpired });

        }

    }
}