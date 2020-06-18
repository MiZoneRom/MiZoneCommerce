using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MCS.Core.Helper
{
    public class JwtTokenHelper
    {

        private readonly IConfiguration _configuration;

        public JwtTokenHelper()
        {
            _configuration = ConfigurationHelper.Configuration;
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetToken(string userName)
        {

            var claims = new[]
            {new Claim(ClaimTypes.Name, userName)};

            var jwtSection = _configuration.GetSection("jwt");
            int tokenExpires = Convert.ToInt32(jwtSection.GetSection("TokenExpires").Value);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.GetSection("SecurityKey").Value)); // 获取密钥
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //凭证 ，根据密钥生成

            var token = new JwtSecurityToken(
                audience: jwtSection.GetSection("ValidAudience").Value,
                issuer: jwtSection.GetSection("ValidIssuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenExpires),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetToken(Claim[] claims)
        {

            var jwtSection = _configuration.GetSection("jwt");
            int tokenExpires = Convert.ToInt32(jwtSection.GetSection("TokenExpires").Value);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.GetSection("SecurityKey").Value)); // 获取密钥
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //凭证 ，根据密钥生成

            var token = new JwtSecurityToken(
                audience: jwtSection.GetSection("ValidAudience").Value,
                issuer: jwtSection.GetSection("ValidIssuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenExpires),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// 生成刷新令牌
        /// </summary>
        /// <returns></returns>
        public string RefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        /// <summary>
        /// 从Token中获取用户身份
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsPrincipal GetPrincipalFromAccessToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSection = _configuration.GetSection("jwt");

            try
            {
                return handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.GetSection("SecurityKey").Value)),
                    ValidateLifetime = false
                }, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
