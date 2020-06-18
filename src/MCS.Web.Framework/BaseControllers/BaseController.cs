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

    public class BaseController : Controller
    {

        #region 构造函数
        public BaseController()
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
        public ManagersInfo CurrentManager
        {
            get
            {

                string toekn = Token;

                if (string.IsNullOrEmpty(toekn))
                {
                    return null;
                }

                ClaimsPrincipal clams = new JwtTokenHelper().GetPrincipalFromAccessToken(toekn);

                if (clams == null)
                {
                    return null;
                }

                Claim iden = clams.Claims.Where(a => a.Type == JwtRegisteredClaimNames.Sid).FirstOrDefault();

                if (iden == null)
                {
                    return null;
                }

                long userId = Convert.ToInt64(iden.Value);
                ManagersInfo manager = ServiceProvider.Instance<IManagerService>.Create.GetPlatformManager(userId);

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
        protected Result<T> ApiResult<T>(bool success, string msg = "", T data = default(T), int code = 0)
        {
            return new Result<T>
            {
                success = success,
                msg = msg,
                data = data,
                code = code
            };
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected Result<T> SuccessResult<T>(T data = default(T), string msg = "", int code = 0)
        {
            return ApiResult<T>(true, msg, data, code);
        }

        /// <summary>
        /// 失败返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected Result<T> ErrorResult<T>(string msg, T data = default(T), int code = 0)
        {
            return ApiResult<T>(false, msg, data, code);
        }

        public class Result<TData>
        {
            #region 字段
            private bool _success = false;
            private string _msg = string.Empty;
            private int _code = 0;
            private TData _data = default(TData);
            #endregion

            #region 构造函数

            #endregion

            #region 属性
            public bool success
            {
                get { return _success; }
                set { _success = value; }
            }

            public string msg
            {
                get { return _msg; }
                set { _msg = value; }
            }

            /// <summary>
            /// 状态码
            /// </summary>
            public int code
            {
                get { return _code; }
                set { _code = value; }
            }

            public TData data
            {
                get { return _data; }
                set { _data = value; }
            }

            #endregion

            #region 重写方法
            //public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value)
            //{
            //    if (!_members.ContainsKey(binder.Name))
            //    {
            //        _members.Add(binder.Name, value);
            //        return true;
            //    }

            //    return base.TrySetMember(binder, value);
            //}

            //public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
            //{
            //    if (_members.ContainsKey(binder.Name))
            //    {
            //        result = _members[binder.Name];
            //        return true;
            //    }

            //    return base.TryGetMember(binder, out result);
            //}

            //public override IEnumerable<string> GetDynamicMemberNames()
            //{
            //    return base.GetDynamicMemberNames().Concat(_members.Keys);
            //}
            #endregion
        }

        #endregion


    }
}
