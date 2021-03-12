using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MCS.Core;
using MCS.Core.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using MCS.IServices;
using MCS.Entities;

namespace MCS.Web.Framework.BaseControllers
{

    public class BaseAPIController : Controller
    {

        #region 构造函数
        public BaseAPIController()
        {

        }
        #endregion

        public string Token
        {
            get
            {
                string token = HttpContext.Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(token))
                {
                    return string.Empty;
                }
                token = token.Replace("Bearer", "").Trim();
                return token;
            }
        }

        /// <summary>
        /// 当前管理员
        /// </summary>
        public ManagerInfo CurrentManager
        {
            get
            {

                string token = Token;

                if (string.IsNullOrEmpty(token))
                {
                    return null;
                }

                ClaimsPrincipal clams = new JwtTokenHelper().GetPrincipalFromAccessToken(token);

                if (clams == null)
                {
                    return null;
                }

                Claim iden = clams.Claims.Where(a => a.Type == ClaimTypes.Sid).FirstOrDefault();

                if (iden == null)
                {
                    return null;
                }

                long userId = Convert.ToInt64(iden.Value);
                ManagerInfo manager = ServiceProvider.Instance<IManagerService>.Create.GetPlatformManager(userId);

                return manager;
            }
            set
            {



            }

        }

        #region 公共方法

        ///// <summary>
        ///// 通用JSON成功返回
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //protected JsonResult<Result<T>> JsonResult<T>(T data = default(T), string msg = "", int code = 0)
        //{
        //    return Json(SuccessResult(data, msg, code));
        //}

        /// <summary>
        /// 通用返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="success"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected ApiResult<T> ApiResultContent<T>(bool success, string msg = "", T data = default(T), int code = 200)
        {
            return new ApiResult<T>
            {
                Success = success,
                Msg = msg,
                Data = data,
                Code = code
            };
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected ApiResult<T> SuccessResult<T>(T data = default(T), string msg = "", int code = 200)
        {
            return ApiResultContent<T>(true, msg, data, code);
        }

        /// <summary>
        /// 失败返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected ApiResult<T> ErrorResult<T>(string msg, T data = default(T), int code = 406)
        {
            return ApiResultContent<T>(false, msg, data, code);
        }

        /// <summary>
        /// API返回基类
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        public class ApiResult<TData>
        {
            /// <summary>
            /// 是否成功
            /// </summary>
            public bool Success { get; set; } = false;

            /// <summary>
            /// 返回消息
            /// </summary>
            public string Msg { get; set; } = string.Empty;

            /// <summary>
            /// 状态码
            /// </summary>
            public int Code { get; set; } = 200;

            /// <summary>
            /// 数据
            /// </summary>
            public TData Data { get; set; } = default(TData);

        }

        #endregion


    }
}
