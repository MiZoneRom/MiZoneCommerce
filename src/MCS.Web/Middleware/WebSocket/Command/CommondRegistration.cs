using MCS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public abstract class CommondRegistration
    {

        protected static List<CommondRegistration> areaRegistration = new List<CommondRegistration>();

        public static void Register()
        {
            var xxx = typeof(WebSocketService).Assembly.GetTypes(); //获取当前类库下所有类型
            var aaa = xxx.Where(t => typeof(IWebSocketCommand).IsAssignableFrom(t));
            var bbb=aaa.Where(t => !t.IsAbstract && t.IsClass).Select(t => (IWebSocketCommand)Activator.CreateInstance(t)); //获取间接或直接继承t的所有类型

            //foreach (var o in areaRegistration)
            //{
            //    o.RegisterAreaOrder();
            //}
        }

    }
}
