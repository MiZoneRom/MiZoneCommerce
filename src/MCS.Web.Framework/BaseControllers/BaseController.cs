using MCS.Core.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MCS.Web.Framework
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {

        }

        public class Result
        {
            public bool success { get; set; } = true;

            public string msg { get; set; }

            public object data { get; set; }

            public int code { get; set; } = 200;
        }

        /// <summary>
        /// 统一返回json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="success"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// camelCase,
        /// <returns></returns>
        protected JsonResult Json<T>(bool success, string msg = "", T data = default(T), int code = 0, bool camelCase = false)
        {
            if (camelCase)
            {
                var options = new JsonSerializerOptions
                {
                    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                    PropertyNameCaseInsensitive = true
                };
                return Json(new Result()
                {
                    data = data,
                    msg = msg,
                    success = success,
                    code = code
                }, options);
            }
            else
            {
                var options = new JsonSerializerOptions
                {
                    DictionaryKeyPolicy = null,
                    PropertyNameCaseInsensitive = true
                };
                return Json(new Result()
                {
                    data = data,
                    msg = msg,
                    success = success,
                    code = code
                }, options);
            }
        }

        /// <summary>
        /// 失败结果，可以返回数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        protected JsonResult ErrorResult<T>(string msg = "", T data = default(T), int code = 500, bool camelCase = false)
        {
            return Json<T>(false, msg, data, code, camelCase: camelCase);
        }

        /// <summary>
        /// 失败结果，无数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        protected JsonResult ErrorResult(string msg = "", int code = 500, bool camelCase = false)
        {
            return ErrorResult<dynamic>(msg: msg, code: code, camelCase: camelCase);
        }

        /// <summary>
        /// 重定向
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <param name="camelCase"></param>
        /// <returns></returns>
        protected JsonResult RedirectResult(string url = "")
        {
            return Json<object>(true, "", data: new { url = url }, code: 302, camelCase: false);
        }

        /// <summary>
        /// 成功结果，可以返回数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        protected JsonResult SuccessResult<T>(string msg = "", T data = default(T), int code = 201, bool camelCase = false)
        {
            return Json<T>(true, msg, data, code, camelCase: camelCase);
        }

        /// <summary>
        /// 成功结果，无数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        protected JsonResult SuccessResult()
        {
            return Json<object>(true);
        }

        protected JsonResult SuccessResult(string msg)
        {
            return Json<object>(true, msg);
        }

    }
}
