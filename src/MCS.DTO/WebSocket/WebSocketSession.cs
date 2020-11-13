using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.DTO.WebSocket
{
    public class WebSocketSession
    {
        /// <summary>
        /// 会话Id
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// 会话
        /// </summary>
        public System.Net.WebSockets.WebSocket Session { get; set; }
    }
}
