using MCS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web
{
    public static class WebSocketCommandManagement
    {
        /// <summary>
        /// 已安装插件
        /// </summary>
        static Dictionary<WebSocketProtocolCommandType, List<WebSocketProtocolModelInfo>> IntalledPlugins = new Dictionary<WebSocketProtocolCommandType, List<WebSocketProtocolModelInfo>>();//此处可以考虑放到缓存中,否则多Web下会存在问题

        static WebSocketCommandManagement()
        {
            //初始化intalledPlugins
            foreach (var value in Enum.GetValues(typeof(WebSocketProtocolCommandType)))
            {
                IntalledPlugins.Add((WebSocketProtocolCommandType)value, new List<WebSocketProtocolModelInfo>());
            }
        }

        /// <summary>
        /// 获取已安装的插件信息
        /// </summary>
        /// <param name="pluginType">插件类型</param>
        /// <returns></returns>
        public static IEnumerable<WebSocketProtocolModelInfo> GetInstalledPluginInfos(WebSocketProtocolCommandType pluginType)
        {
            IEnumerable<WebSocketProtocolModelInfo> plugins = IntalledPlugins[pluginType].Select(item => DeepClone(item));
            return plugins;
        }

        /// <summary>
        /// 获取指定的插件信息
        /// </summary>
        /// <param name="pluginId">插件标识</param>
        /// <returns></returns>
        public static WebSocketProtocolModelInfo GetPluginInfo(string pluginId)
        {
            WebSocketProtocolModelInfo pluginfo = null;
            foreach (var plugins in IntalledPlugins.Values)
            {
                pluginfo = plugins.FirstOrDefault(item => item.PluginId == pluginId);
                if (pluginfo != null)
                    break;
            }
            return pluginfo;
        }

        /// <summary>
        /// 获取指定id的插件
        /// </summary>
        /// <typeparam name="T">插件类型</typeparam>
        /// <param name="pluginId">插件Id</param>
        /// <returns></returns>
        public static WebSocketCommand<T> GetPlugin<T>(string pluginId) where T : IWebSocketCommand
        {
            var pluginInfo = GetPluginInfo(pluginId);
            WebSocketCommand<T> plugin = new WebSocketCommand<T>()
            {
                ModelInfo = pluginInfo,
                Biz = Instance.Get<T>(pluginInfo.ClassFullName)
            };
            return plugin;
        }

        /// <summary>
        /// 深复制IPlugin
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        static WebSocketProtocolModelInfo DeepClone(WebSocketProtocolModelInfo plugin)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(plugin);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<WebSocketProtocolModelInfo>(jsonString);
        }

    }
}
