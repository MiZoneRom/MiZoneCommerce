using MCS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public static class WebSocketCommandManagement
    {
        /// <summary>
        /// 已安装插件
        /// </summary>
        public static Dictionary<WebSocketProtocolCommandType, string> IntalledPlugins = new Dictionary<WebSocketProtocolCommandType, string>();
        //此处可以考虑放到缓存中,否则多Web下会存在问题

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

            Log.Debug(IntalledPlugins);

            //Type[] types = ass.GetTypes();

            //var xxx = typeof(IWebSocketCommand).Assembly.GetTypes(); //获取当前类库下所有类型
            //var aaa = xxx.Where(t => typeof(IWebSocketCommand).IsAssignableFrom(t));
            //var bbb = aaa.Where(t => !t.IsAbstract && t.IsClass).Select(t => (IWebSocketCommand)Activator.CreateInstance(t)); //获取间接或直接继承t的所有类型

            //foreach (var o in areaRegistration)
            //{
            //    o.RegisterAreaOrder();
            //}

        }

        static WebSocketCommandManagement()
        {
            //初始化intalledPlugins
            //foreach (var value in Enum.GetValues(typeof(WebSocketProtocolCommandType)))
            //{
            //    IntalledPlugins.Add((WebSocketProtocolCommandType)value, string.Empty);
            //}
        }

        /// <summary>
        /// 获取指定的插件信息
        /// </summary>
        /// <param name="pluginId">插件标识</param>
        /// <returns></returns>
        public static string GetPluginInfo(WebSocketProtocolCommandType pluginId)
        {
            return IntalledPlugins[pluginId];
        }

        /// <summary>
        /// 获取指定id的插件
        /// </summary>
        /// <typeparam name="T">插件类型</typeparam>
        /// <param name="pluginId">插件Id</param>
        /// <returns></returns>
        public static T GetPlugin<T>(WebSocketProtocolCommandType pluginId) where T : IWebSocketCommand
        {
            var pluginInfo = GetPluginInfo(pluginId);
            return Instance.Get<T>(pluginInfo);
        }

    }
}
