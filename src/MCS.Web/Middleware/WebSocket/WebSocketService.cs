using MCS.Application;
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

            try
            {
                NavigationApplication.GetNavigations();
            }
            catch (Exception ex)
            {
                Log.Error("aa", ex);
            }
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

            //会话ID
            string sessionId = context.TraceIdentifier;
            //Token
            string token = context.Request.Headers["Authorization"];

            Log.Debug(sessionId + "__" + token);

            //如果队列中不存在该用户
            if (!WebSocketSessionPool.ExistsSession(sessionId))
            {
                WebSocketSession sessionModel = new WebSocketSession()
                {
                    SessionId = sessionId,
                    Token = token,
                    Session = currentWebSocketContext,
                    ConnectTime = DateTime.Now,
                    IsRegister = !string.IsNullOrEmpty(token)
                };
                WebSocketSessionPool.AddSession(sessionModel);
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

                //如果用户不存在
                if (currentSession == null)
                {
                    Log.Error("用户不存在");
                    continue;
                }

                //接收消息
                WebSocketProtocolModel response = await currentSession.Session.ReceiveModelAsync();
                currentSession.LastReceiveTime = DateTime.Now;

                //如果消息为空
                if (response == null)
                {
                    Log.Error("消息为空");
                    if (currentWebSocketContext.State != WebSocketState.Open)
                    {
                        break;
                    }
                    continue;
                }

                //防止客户端连接断开
                try
                {
                    var commandFunction = WebSocketCommandManagement.GetFunction<IWebSocketCommand>(response.Cmd);
                    if (commandFunction == null)
                    {
                        Log.Error("无匹配方法");
                        continue;
                    }
                    commandFunction.ReceiveModel(currentSession, response);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }

            }

            //用户断开连接后移出队列
            WebSocketSession dummy;
            WebSocketSessionPool.TryRemove(sessionId, out dummy);

            await currentWebSocketContext.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            currentWebSocketContext.Dispose();
        }

    }
}
