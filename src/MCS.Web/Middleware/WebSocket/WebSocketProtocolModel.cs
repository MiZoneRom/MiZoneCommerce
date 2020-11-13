using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Web
{
    public class WebSocketProtocolModel
    {
        public WebSocketProtocolCommondType Cmd { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
