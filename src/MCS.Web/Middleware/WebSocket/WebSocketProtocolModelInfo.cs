using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Web
{
    public class WebSocketProtocolModelInfo
    {
        /// <summary>
        /// 程序集类全名
        /// </summary>
        public string ClassFullName { get; set; }
        public string PluginId { get; set; }
        public WebSocketProtocolCommandType Cmd { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
