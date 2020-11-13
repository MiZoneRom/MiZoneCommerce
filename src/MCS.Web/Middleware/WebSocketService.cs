using MCS.DTO.WebSocket;
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

        public async Task Invoke(HttpContext context)
        {

            //如果不是Websocket
            if (!context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);
                return;
            }

            //System.Net.WebSockets.WebSocket dummy;

            CancellationToken ct = context.RequestAborted;
            var currentSession = await context.WebSockets.AcceptWebSocketAsync();
            string sessionId = Guid.NewGuid().ToString();
            //string socketId = context.Request.Query["sid"].ToString();

            if (!_sockets.ContainsKey(sessionId))
            {
                WebSocketSession sessionModel = new WebSocketSession()
                {
                    SessionId = sessionId,
                    Session = currentSession
                };
                _sockets.TryAdd(sessionId, sessionModel);
            }

            //_sockets.TryRemove(socketId, out dummy);
            //_sockets.TryAdd(socketId, currentSocket);

            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    break;
                }

                string response = await ReceiveStringAsync(currentSession, ct);
                //WebSocketProtocolModel msg = JsonConvert.DeserializeObject<WebSocketProtocolModel>(response);

                //if (string.IsNullOrEmpty(response))
                //{
                //    if (currentSocket.State != WebSocketState.Open)
                //    {
                //        break;
                //    }

                //    continue;
                //}

                //foreach (var socket in _sockets)
                //{
                //    if (socket.Value.State != WebSocketState.Open)
                //    {
                //        continue;
                //    }
                //    //如果是接收者
                //    if (socket.Key == msg.ReceiverID || socket.Key == socketId)
                //    {
                //        await SendStringAsync(socket.Value, JsonConvert.SerializeObject(msg), ct);
                //    }
                //}

                await SendStringAsync(currentSession, JsonConvert.SerializeObject(response), ct);

            }

            //_sockets.TryRemove(socketId, out dummy);

            await currentSession.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", ct);
            currentSession.Dispose();
        }

        #region 扩展方法
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="data"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        private static Task SendStringAsync(System.Net.WebSockets.WebSocket socket, string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return socket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        /// <summary>
        /// 接受返回的消息
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        private static async Task<string> ReceiveStringAsync(System.Net.WebSockets.WebSocket socket, CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await socket.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);
                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                {
                    return null;
                }
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }
        #endregion
    }
}
