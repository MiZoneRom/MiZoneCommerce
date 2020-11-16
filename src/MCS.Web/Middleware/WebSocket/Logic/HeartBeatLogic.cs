using MCS.Core;
using MCS.Web.Middleware.WebSocket;
using MCS.Web.Middleware.WebSocket.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket.Logic
{
    [MessageCommand(WebSocketProtocolCommandType.HeartBeat)]
    public class HeartBeatLogic : IWebSocketCommand
    {
        public HeartBeatLogic()
        {
        }

        public async void ReceiveModel(WebSocketSession session, WebSocketProtocolModel message)
        {
            await session.Session.SendModelAsync(new WebSocketProtocolModel()
            {
                Cmd = WebSocketProtocolCommandType.HeartBeat,
                Success = true,
                Data = new { time = DateTime.Now.ToString() }
            });
        }

    }
}
