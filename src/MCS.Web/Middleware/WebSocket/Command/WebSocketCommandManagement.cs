using MCS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MCS.Web.Middleware.WebSocket.Command
{
    public static class WebSocketCommandManagement
    {
        /// <summary>
        /// 已注册方法
        /// </summary>
        public static Dictionary<WebSocketProtocolCommandType, string> CommandFunctionList = new Dictionary<WebSocketProtocolCommandType, string>();

        /// <summary>
        /// 注册命令对应方法
        /// </summary>
        public static void RegisterFunction()
        {
            List<Type> typeList = new List<Type>();
            var types = Assembly.GetAssembly(typeof(IWebSocketCommand)).GetTypes().Where(t => !t.IsInterface);
            foreach (var item in types)
            {
                Type[] ins = item.GetInterfaces();
                foreach (Type ty in ins)
                {
                    if (ty == typeof(IWebSocketCommand))
                    {
                        typeList.Add(item);
                    }
                }
            }

            foreach (Type item in typeList)
            {
                var attr = item.GetCustomAttributes(typeof(MessageCommandAttribute), true).FirstOrDefault() as MessageCommandAttribute;
                CommandFunctionList.Add(attr.Command, item.FullName);
            }

        }

        /// <summary>
        /// 获取命令内容
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetCommandInfo(WebSocketProtocolCommandType command)
        {
            return CommandFunctionList[command];
        }

        /// <summary>
        /// 获取命令对应方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static T GetFunction<T>(WebSocketProtocolCommandType command) where T : IWebSocketCommand
        {
            var commandInfo = GetCommandInfo(command);
            Type sourceType = Type.GetType(commandInfo);
            var functionObj = (T)Activator.CreateInstance(sourceType);
            return functionObj;
        }

    }
}
