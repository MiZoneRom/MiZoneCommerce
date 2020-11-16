using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket.Command
{
    public enum WebSocketProtocolCommandType
    {
        #region
        /// <summary>
        /// 心跳
        /// </summary>
        HeartBeat = 0,
        #endregion

        #region
        /// <summary>
        /// 注册
        /// </summary>
        Register = 1001,
        #endregion

        #region 即时消息
        /// <summary>
        /// 信息
        /// </summary>
        Message = 2001,
        /// <summary>
        /// 历史消息
        /// </summary>
        HistoryMessage = 2002,
        #endregion

        #region 定位
        /// <summary>
        /// 更新定位
        /// </summary>
        UpdateLocation = 3001,
        /// <summary>
        /// 广播定位
        /// </summary>
        BroadcastLocation = 3002
        #endregion


    }
}
