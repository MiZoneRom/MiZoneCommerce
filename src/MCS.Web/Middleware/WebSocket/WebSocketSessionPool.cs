using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket
{
    public class WebSocketSessionPool
    {

        /// <summary>
        /// 客户端列表
        /// </summary>
        private static ConcurrentDictionary<string, WebSocketSession> _sockets = new ConcurrentDictionary<string, WebSocketSession>();

        /// <summary>
        /// 是否存在会话
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public static bool ExistsSession(string sessionId)
        {
            return _sockets.ContainsKey(sessionId);
        }

        /// <summary>
        /// 添加会话
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="sessionModel"></param>
        /// <returns></returns>
        public static bool AddSession(string sessionId, WebSocketSession sessionModel)
        {
            return _sockets.TryAdd(sessionId, sessionModel);
        }

        /// <summary>
        /// 尝试移除
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="dummy"></param>
        /// <returns></returns>
        public static bool TryRemove(string sessionId, out WebSocketSession dummy)
        {
            return _sockets.TryRemove(sessionId, out dummy);
        }

        /// <summary>
        /// 获取会话
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static WebSocketSession GetSessionById(string id)
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
        public static async Task Broadcast(WebSocketProtocolModel msgModel)
        {
            foreach (var socket in _sockets)
            {
                if (socket.Value.Session.State != WebSocketState.Open)
                {
                    continue;
                }
                await socket.Value.Session.SendModelAsync(msgModel);
            }
        }

        /// <summary>
        /// 对指定用户广播
        /// </summary>
        /// <param name="msgModel"></param>
        /// <returns></returns>
        public static async Task BroadcastByUserId(long userId, WebSocketProtocolModel msgModel)
        {
            foreach (var socket in _sockets)
            {
                if (socket.Value.Session.State != WebSocketState.Open)
                {
                    continue;
                }
                await socket.Value.Session.SendModelAsync(msgModel);
            }
        }

    }
}
