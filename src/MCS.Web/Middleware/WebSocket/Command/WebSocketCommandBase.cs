using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public abstract class WebSocketCommandBase
    {
        public WebSocketProtocolModelInfo ModelInfo { get; set; }
    }
}
