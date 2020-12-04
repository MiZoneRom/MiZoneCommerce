using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MCS.Core
{
    public class BaseExceptions : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        public BaseExceptions(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var json = new JsonErrorResponse();

            //这里面是自定义的操作记录日志
            if (context.Exception.GetType() == typeof(MCSException))
            {
                json.msg = context.Exception.Message; if (_env.IsDevelopment())
                {
                    json.devMsg = context.Exception.StackTrace;//堆栈信息
                }
                context.Result = new ObjectResult(json);//返回异常数据 
            }
            else
            {
                json.msg = "发生了未知内部错误";
                if (_env.IsDevelopment())
                {
                    json.devMsg = context.Exception.StackTrace;//堆栈信息
                }
                context.Result = new InternalServerErrorObjectResult(json);
                Log.Error(json.msg, context.Exception);
            }

        }
    }

    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }

}
