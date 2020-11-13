using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public class WebSocketCommand : IWebSocketCommand
    {
        public WebSocketProtocolCommandType Commond { get; set; }

        public void RegisterAreaOrder()
        {
            WebSocketCommandManagement.IntalledPlugins.Add(WebSocketProtocolCommandType.Message, this.GetType().FullName);
        }

    }
}
