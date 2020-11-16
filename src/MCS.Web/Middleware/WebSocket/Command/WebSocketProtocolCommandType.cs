using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket.Command
{
    public enum WebSocketProtocolCommandType
    {
        /// <summary>
        /// 心跳
        /// </summary>
        HeartBeat = 0,
        /// <summary>
        /// 注册
        /// </summary>
        Register = 1,
        /// <summary>
        /// 信息
        /// </summary>
        Message = 2
    }
}
