using MCS.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket
{
    public static class WebSocketExtend
    {

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="data"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static Task SendStringAsync(this System.Net.WebSockets.WebSocket webSocket, string data, CancellationToken ct = default(CancellationToken))
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var segment = new ArraySegment<byte>(buffer);
            return webSocket.SendAsync(segment, WebSocketMessageType.Text, true, ct);
        }

        public static Task SendModelAsync(this System.Net.WebSockets.WebSocket webSocket, WebSocketProtocolModel model, CancellationToken ct = default(CancellationToken))
        {
            var json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            });
            return webSocket.SendStringAsync(json, ct);
        }

        /// <summary>
        /// 接受返回的消息
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static async Task<string> ReceiveStringAsync(this System.Net.WebSockets.WebSocket webSocket, CancellationToken ct = default(CancellationToken))
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    ct.ThrowIfCancellationRequested();

                    result = await webSocket.ReceiveAsync(buffer, ct);
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

        /// <summary>
        /// 接受返回的消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="webSocket"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static async Task<T> ReceiveModelAsync<T>(this System.Net.WebSockets.WebSocket webSocket, CancellationToken ct = default(CancellationToken))
        {
            string jsonStr = await webSocket.ReceiveStringAsync(ct);
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

        /// <summary>
        /// 接受返回的消息
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public static async Task<WebSocketProtocolModel> ReceiveModelAsync(this System.Net.WebSockets.WebSocket webSocket, CancellationToken ct = default(CancellationToken))
        {
            return await webSocket.ReceiveModelAsync<WebSocketProtocolModel>(ct);
        }

    }
}
