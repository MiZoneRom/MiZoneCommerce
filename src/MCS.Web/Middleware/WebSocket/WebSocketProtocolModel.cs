using MCS.Web.WebSocket.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Web.Middleware.WebSocket
{
    public class WebSocketProtocolModel
    {
        public WebSocketProtocolCommandType Cmd { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
