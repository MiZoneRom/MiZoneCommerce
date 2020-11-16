using MCS.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket
{
    public class WebSocketSession
    {
        /// <summary>
        /// 会话Id
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// 验证Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 是否绑定用户
        /// </summary>
        public bool IsRegister { get; set; }

        /// <summary>
        /// 会话
        /// </summary>
        public System.Net.WebSockets.WebSocket Session { get; set; }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task SendModelAsync(WebSocketProtocolModel model, CancellationToken ct = default(CancellationToken))
        {
            var json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });
            var buffer = Encoding.UTF8.GetBytes(json);
            var segment = new ArraySegment<byte>(buffer);
            return Session.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task SendStringAsync(string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return Session.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        /// <summary>
        /// 接受返回的消息
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<string> ReceiveStringAsync(CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await Session.ReceiveAsync(buffer, ct);
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

        public async Task<T> ReceiveModelAsync<T>(CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();
                    result = await Session.ReceiveAsync(buffer, ct);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);
                ms.Seek(0, SeekOrigin.Begin);
                if (result.MessageType != WebSocketMessageType.Text)
                {
                    return default(T);
                }
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    string jsonStr = await reader.ReadToEndAsync();
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(jsonStr);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Socket消息反序列化失败", ex);
                        return default(T);
                    }
                }
            }
        }

        /// <summary>
        /// 接受返回的消息
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<WebSocketProtocolModel> ReceiveModelAsync(CancellationToken ct = default(CancellationToken))
        {
            return await ReceiveModelAsync(ct);
        }

    }
}
