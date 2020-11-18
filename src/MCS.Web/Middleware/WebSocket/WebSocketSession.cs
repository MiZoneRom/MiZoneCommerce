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
        /// 连接时间
        /// </summary>
        public DateTime ConnectTime { get; set; }

        /// <summary>
        /// 最后发送消息时间 （服务端向客户端发送）
        /// </summary>
        public DateTime LastSendTime { get; set; }

        /// <summary>
        /// 最后接收时间 (客户端向服务端发送)
        /// </summary>
        public DateTime LastReceiveTime { get; set; }

        /// <summary>
        /// 最后推送微信消息时间
        /// </summary>
        public DateTime LastSendWeiXinOpen { get; set; }

        /// <summary>
        /// 会话
        /// </summary>
        public System.Net.WebSockets.WebSocket Session { get; set; }

    }
}
