using MCS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public abstract class CommondRegistration
    {
        public WebSocketProtocolCommandType Commond { get; set; }

        protected static List<CommondRegistration> areaRegistration = new List<CommondRegistration>();

        public abstract void RegisterAreaOrder();

        public static void Register()
        {
            List<Type> xxx = new List<Type>();
            var ass = Assembly.GetAssembly(typeof(IWebSocketCommand)).GetTypes().Where(t => !t.IsInterface);
            foreach (var item in ass)
            {
                Type[] ins = item.GetInterfaces();
                foreach (Type ty in ins)
                {
                    if (ty == typeof(IWebSocketCommand))
                    {
                        xxx.Add(item);
                    }
                }
            }

            foreach (Type item in xxx)
            {
                object obj = Activator.CreateInstance(item);//创建一个obj对象
            }

            //Type[] types = ass.GetTypes();

            //var xxx = typeof(IWebSocketCommand).Assembly.GetTypes(); //获取当前类库下所有类型
            //var aaa = xxx.Where(t => typeof(IWebSocketCommand).IsAssignableFrom(t));
            //var bbb = aaa.Where(t => !t.IsAbstract && t.IsClass).Select(t => (IWebSocketCommand)Activator.CreateInstance(t)); //获取间接或直接继承t的所有类型

            foreach (var o in areaRegistration)
            {
                o.RegisterAreaOrder();
            }
        }

    }
}
