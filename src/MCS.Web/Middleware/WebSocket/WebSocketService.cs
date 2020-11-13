using MCS.Core;
using MCS.Web.WebSocket.Command;
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

namespace MCS.Web
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
            WebSocketCommandManagement.Register();
            app.UseWebSockets();
            app.UseMiddleware<WebSocketService>();
        }

        /// <summary>
        /// 客户端列表
        /// </summary>
        private static ConcurrentDictionary<string, WebSocketSession> _sockets = new ConcurrentDictionary<string, WebSocketSession>();

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

            if (!_sockets.ContainsKey(sessionId))
            {
                Log.Debug(context.TraceIdentifier);
                WebSocketSession sessionModel = new WebSocketSession()
                {
                    SessionId = sessionId,
                    Session = currentWebSocketContext
                };
                _sockets.TryAdd(sessionId, sessionModel);
            }

            while (true)
            {
                //如果取消连接
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                //根据Id获取对应用户
                WebSocketSession currentSession = GetSessionById(sessionId);
                WebSocketProtocolModel response = await currentSession.ReceiveModelAsync();

                if (response == null)
                {
                    if (currentWebSocketContext.State != WebSocketState.Open)
                    {
                        break;
                    }
                    continue;
                }

                //var payment = WebSocketCommandManagement.GetPlugin<IWebSocketMainCommand>("");

                await Broadcast(response);

            }

            WebSocketSession dummy;
            _sockets.TryRemove(sessionId, out dummy);

            await currentWebSocketContext.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            currentWebSocketContext.Dispose();
        }

        #region 扩展方法
        /// <summary>
        /// 获取会话
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private WebSocketSession GetSessionById(string id)
        {
            WebSocketSession dummy;
            _sockets.TryGetValue(id, out dummy);
            return dummy;
        }

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        private async Task Broadcast(WebSocketProtocolModel msgModel)
        {
            foreach (var socket in _sockets)
            {
                if (socket.Value.Session.State != WebSocketState.Open)
                {
                    continue;
                }
                await socket.Value.SendModelAsync(msgModel);
            }
        }

        /// <summary>
        /// 对指定用户广播
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        private async Task BroadcastByUserId(long userId, WebSocketProtocolModel msgModel)
        {
            foreach (var socket in _sockets)
            {
                if (socket.Value.Session.State != WebSocketState.Open)
                {
                    continue;
                }
                await socket.Value.SendModelAsync(msgModel);
            }
        }
        #endregion
    }
}
