using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket.Command
{
    public interface IWebSocketCommand
    {
        void ReceiveModel(WebSocketSession session, WebSocketProtocolModel message);
    }
}
