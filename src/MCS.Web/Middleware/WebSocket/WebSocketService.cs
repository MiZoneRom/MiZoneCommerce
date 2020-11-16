using MCS.Core;
using MCS.Web.Middleware.WebSocket.Command;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket
{
    /// <summary>
    /// WS服务
    /// </summary>
    public class WebSocketService
    {

        /// <summary>
        /// 路由绑定处理
        /// </summary>
        /// <param name="app"></param>
        public static void Map(IApplicationBuilder app)
        {
            WebSocketCommandManagement.RegisterFunction();
            app.UseWebSockets();
            app.UseMiddleware<WebSocketService>();
        }

        private readonly RequestDelegate _next;

        public WebSocketService(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {

            //如果不是Websocket
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);
                return;
            }

            CancellationToken ct = context.RequestAborted;
            var currentWebSocketContext = await context.WebSockets.AcceptWebSocketAsync();
            string sessionId = context.TraceIdentifier;
            string token = context.Request.Headers["Authorization"];

            if (!WebSocketSessionPool.ExistsSession(sessionId))
            {
                WebSocketSession sessionModel = new WebSocketSession()
                {
                    SessionId = sessionId,
                    Session = currentWebSocketContext
                };
                WebSocketSessionPool.AddSession(sessionId, sessionModel);
            }

            while (true)
            {
                //如果取消连接
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                //根据Id获取对应用户
                WebSocketSession currentSession = WebSocketSessionPool.GetSessionById(sessionId);
                WebSocketProtocolModel response = await currentSession.ReceiveModelAsync();

                if (response == null)
                {
                    if (currentWebSocketContext.State != WebSocketState.Open)
                    {
                        break;
                    }
                    continue;
                }

                var commandFunction = WebSocketCommandManagement.GetFunction<IWebSocketCommand>(WebSocketProtocolCommandType.Message);
                commandFunction.ReceiveModel(currentSession, response);

            }

            WebSocketSession dummy;
            WebSocketSessionPool.TryRemove(sessionId, out dummy);

            await currentWebSocketContext.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            currentWebSocketContext.Dispose();
        }

    }
}
