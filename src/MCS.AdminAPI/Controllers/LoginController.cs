using MCS.Core;
using MCS.Core.Helper;
using MCS.DTO;
using MCS.Entities;
using MCS.IServices;
using MCS.Web.Framework.AccessControlHelper;
using MCS.Web.Framework.BaseControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MCS.AdminAPI.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    [ApiController]
    [Route("api/admin/[controller]")]
    public class LoginController : BaseAdminAPIController
    {

        private readonly IConfiguration _iConfiguration;
        private readonly IManagerService _iManagerService;

        public LoginController(IConfiguration iConfiguration, IManagerService iManagerService)
        {
            _iConfiguration = iConfiguration;
            _iManagerService = iManagerService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        [NoAccessControl]
        public Result<ManagerLoginModel> Get(string username, string password)
        {

            ManagerInfo managerModel = _iManagerService.Login(username, password);
            var jwtSection = _iConfiguration.GetSection("jwt");
            int tokenExpires = Convert.ToInt32(jwtSection.GetSection("TokenExpires").Value);
            int refreshTokenExpires = Convert.ToInt32(jwtSection.GetSection("RefreshTokenExpires").Value);

            if (managerModel == null)
            {
                throw new MCSException("用户名或密码错误");
            }

            JwtTokenHelper jwtTokenHelper = new JwtTokenHelper();

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Actor, "Admin"),
                new Claim(ClaimTypes.Name, managerModel.UserName),
                new Claim(ClaimTypes.Role, managerModel.RoleId.ToString()),
                new Claim(ClaimTypes.Sid, managerModel.Id.ToString()),
            };

            string token = jwtTokenHelper.GetToken(claims);
            string refreshToken = jwtTokenHelper.RefreshToken();
            string tokenExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(tokenExpires));
            string refreshToeknExpired = StringHelper.GetTimeStamp(DateTime.UtcNow.AddMinutes(refreshTokenExpires));

            _iManagerService.RemoveExpiresToken(managerModel.Id);
            _iManagerService.AddRefeshToken(token, refreshToken, managerModel.Id, refreshTokenExpires);

            return SuccessResult(new ManagerLoginModel { Token = token, RefreshToken = refreshToken, UserName = managerModel.UserName, Expires = tokenExpired, RefreshExpires = refreshToeknExpired });
        }

        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("RefreshToken")]
        [NoAccessControl]
        public Result<ManagerLoginModel> RefreshToken([FromBody] RefreshTokenModel entity)
        {

            //jwt配置
            var jwtSection = _iConfiguration.GetSection("jwt");
            int tokenExpires = Convert.ToInt32(jwtSection.GetSection("TokenExpires").Value);
            int refreshTokenExpires = Convert.ToInt32(jwtSection.GetSection("RefreshTokenExpires").Value);
            string token = entity.token;
            string refreshToken = entity.refresh_token;

            //获取刷新token记录
            ManagerTokenInfo tokenModel = _iManagerService.GetTokenByRefreshToken(entity.refresh_token);

            if (tokenModel == null)
            {
                throw new MCSException("登录过期");
            }

            //通过记录获取用户信息
            ManagerInfo managerModel = _iManagerService.GetPlatformManager(tokenModel.ManagerId);

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

            tokenModel.Token = newToken;
            tokenModel.RefreshToken = newRefreshToken;
            tokenModel.Expires = DateTime.Now.AddMinutes(refreshTokenExpires);

            //更新token
            _iManagerService.UpdateManagerToken(tokenModel);

            return SuccessResult(new ManagerLoginModel { Token = newToken, RefreshToken = newRefreshToken, UserName = managerModel.UserName, Expires = tokenExpired, RefreshExpires = refreshToeknExpired });

        }
    }
}
