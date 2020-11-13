using MCS.Core;
using MCS.Web.WebSocket.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public class MessageCommand : IWebSocketCommand
    {
        public WebSocketProtocolCommandType Commond { get; set; }
        public MessageCommand()
        {
            Commond = WebSocketProtocolCommandType.Message;
        }
    }
}
