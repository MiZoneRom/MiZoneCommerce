using MCS.Web.WebSocket.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket
{
    public class MessageCommand : CommondRegistration
    {
        public MessageCommand()
        {
            Commond = WebSocketProtocolCommandType.Message;
            RegisterCommand();
        }

    }
}
