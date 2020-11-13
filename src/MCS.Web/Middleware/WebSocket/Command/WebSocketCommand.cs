using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web
{
    public class WebSocketCommand<T> : WebSocketCommandBase where T : IWebSocketCommand
    {
        public T Biz { get; set; }
    }
}
