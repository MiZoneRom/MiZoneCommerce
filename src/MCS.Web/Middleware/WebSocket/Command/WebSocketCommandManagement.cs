﻿using MCS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS.Web.WebSocket.Command
{
    public static class WebSocketCommandManagement
    {
        /// <summary>
        /// 已安装插件
        /// </summary>
        static Dictionary<WebSocketProtocolCommandType, List<WebSocketProtocolModelInfo>> IntalledPlugins = new Dictionary<WebSocketProtocolCommandType, List<WebSocketProtocolModelInfo>>();
        //此处可以考虑放到缓存中,否则多Web下会存在问题

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

    }
}