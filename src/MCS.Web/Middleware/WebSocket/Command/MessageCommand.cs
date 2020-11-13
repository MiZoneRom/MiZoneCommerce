using MCS.Core;
using MCS.Web.WebSocket.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public class MessageCommand : WebSocketCommand, IWebSocketCommand
    {
        public MessageCommand()
        {
            Commond = WebSocketProtocolCommandType.Message;
            RegisterAreaOrder();
        }

        //public override void RegisterAreaOrder()
        //{
        //    Log.Debug(Commond);
        //}

    }
}
