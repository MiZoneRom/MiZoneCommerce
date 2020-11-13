using MCS.Core;
using MCS.Web.WebSocket.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public class MessageCommand : CommondRegistration, IWebSocketCommand
    {
        public MessageCommand()
        {
            areaRegistration.Add(this);
            Commond = WebSocketProtocolCommandType.Message;
        }

        public override void RegisterAreaOrder()
        {
            Log.Debug(Commond);
        }

    }
}
