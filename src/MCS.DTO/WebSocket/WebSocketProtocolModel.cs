using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.DTO.WebSocket
{
    public class WebSocketProtocolModel
    {
        public int CmdId { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public string MessageType { get; set; }
        public object Data { get; set; }
    }
}
