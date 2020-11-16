using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket.Command
{
    /// <summary>
    /// 消息命令属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class MessageCommandAttribute : Attribute
    {
        public WebSocketProtocolCommandType Command { set; get; }

        public MessageCommandAttribute(WebSocketProtocolCommandType commond)
        {
            this.Command = commond;
        }

    }
}
