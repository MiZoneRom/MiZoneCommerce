using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public abstract class CommondRegistration
    {
        protected WebSocketProtocolCommandType Commond { get; set; }

        protected static List<CommondRegistration> areaRegistration = new List<CommondRegistration>();

        public void RegisterCommand()
        {
            areaRegistration.Add(this);
        }

    }
}
