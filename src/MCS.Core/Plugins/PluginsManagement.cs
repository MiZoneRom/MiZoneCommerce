using MCS.Core.Helper;
using MCS.Core.Plugins;
using MCS.Core.Plugins.Message;
using MCS.Core.Plugins.OAuth;
using MCS.Core.Plugins.Payment;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace MCS.Core
{
    /// <summary>
    /// 插件管理
    /// </summary>
    public static class PluginsManagement
    {

        /// <summary>
        /// 已安装插件 此处可以考虑放到缓存中,否则多Web下会存在问题
        /// </summary>
        static Dictionary<PluginType, List<PluginInfo>> IntalledPlugins = new Dictionary<PluginType, List<PluginInfo>>();

        /// <summary>
        /// 标记是否已经在创建时加载，插件已注册
        /// </summary>
        static bool pluginsRegisted = false;

        /// <summary>
        /// 标记是否已经在创建时加载，策略已注册
        /// </summary>
        static bool strategiesRegisted = false;

        /// <summary>
        /// 注入服务
        /// </summary>
        static IServiceCollection services;

        /// <summary>
        /// 构造方法
        /// </summary>
        static PluginsManagement()
        {
            //初始化intalledPlugins
            foreach (var value in Enum.GetValues(typeof(PluginType)))
            {
                IntalledPlugins.Add((PluginType)value, new List<PluginInfo>());
            }
        }

        /// <summary>
        /// 加载策略所有dll
        /// </summary>
        /// <param name="pluginsDirectory"></param>
        public static void AddStrategies(this IServiceCollection _services)
        {
            services = _services;
            if (!strategiesRegisted)
            {
                strategiesRegisted = true;
                string pluginsDirectory = IOHelper.GetMapPath("/Strategies");
                List<string> dllFiles = GetPluginFiles(pluginsDirectory).ToList();
                foreach (string dllFileName in dllFiles)//加载这些文件
                {
                    Assembly assembly = InstallAssembly(dllFileName);
                }
            }
        }

        /// <summary>
        /// 加载指定目录下所有dll
        /// </summary>
        /// <param name="pluginsDirectory"></param>
        public static void AddPlugins(this IServiceCollection _services)
        {
            services = _services;
            if (!pluginsRegisted)
            {
                pluginsRegisted = true;
                string pluginsDirectory = IOHelper.GetMapPath("/Plugins");
                List<string> dllFiles = GetPluginFiles(pluginsDirectory).ToList();
                foreach (string dllFileName in dllFiles)//加载这些文件
                {
                    Assembly assembly = InstallAssembly(dllFileName);
                }
            }
        }

        public static void UseStrategies(this IApplicationBuilder app)
        {

        }

        public static void UsePlugins(this IApplicationBuilder app)
        {

        }

        /// <summary>
        /// 获取已安装的插件信息
        /// </summary>
        /// <param name="pluginType">插件类型</param>
        /// <returns></returns>
        public static IEnumerable<PluginInfo> GetInstalledPluginInfos(PluginType pluginType)
        {
            IEnumerable<PluginInfo> plugins = IntalledPlugins[pluginType].Select(item => DeepClone(item));
            return plugins;
        }

        /// <summary>
        /// 获取指定的插件信息
        /// </summary>
        /// <param name="pluginId">插件标识</param>
        /// <returns></returns>
        public static PluginInfo GetPluginInfo(string pluginId)
        {
            PluginInfo pluginfo = null;
            foreach (var plugins in IntalledPlugins.Values)
            {
                pluginfo = plugins.FirstOrDefault(item => item.PluginId == pluginId);
                if (pluginfo != null)
                    break;
            }
            return pluginfo;
        }

        /// <summary>
        /// 根据类型获取已安装的插件
        /// </summary>
        /// <param name="pluginType">插件类型</param>
        /// <returns></returns>
        public static IEnumerable<T> GetInstalledPlugins<T>(PluginType pluginType) where T : IPlugin
        {
            IEnumerable<PluginInfo> pluginInfos = GetInstalledPluginInfos(pluginType);
            T[] plugins = new T[pluginInfos.Count()];
            int i = 0;
            foreach (var pluginInfo in pluginInfos)
            {
                plugins[i++] = Core.Instance.Get<T>(pluginInfo.ClassFullName);
            }
            return plugins;
        }

        /// <summary>
        /// 根据Id获取已安装的插件
        /// </summary>
        /// <param name="pluginType">插件类型</param>
        /// <returns></returns>
        public static T GetInstalledPlugin<T>(string pluginId) where T : IPlugin
        {
            T plugin = default(T);
            PluginInfo pluginInfo = GetPluginInfo(pluginId);
            if (pluginInfo != null)
                plugin = Instance.Get<T>(pluginInfo.ClassFullName);
            return plugin;
        }

        /// <summary>
        /// 开启插件
        /// </summary>
        /// <param name="pluginId">插件标识</param>
        /// <param name="enable">是否开启</param>
        static void EnablePlugin_Private(string pluginId, bool enable)
        {
            PluginInfo plugInfo = GetPluginInfo(pluginId);
            if (plugInfo == null)
                throw new PluginNotFoundException(pluginId);
            plugInfo.Enable = enable;

            //序列化,将插件信息保存到系统插件配置文件中
            XmlHelper.SerializeToXmlByOSS(plugInfo, IOHelper.GetMapPath("/Plugins/Configs/") + pluginId + ".config");
        }

        /// <summary>
        /// 安装插件
        /// </summary>
        /// <param name="pluginFullDirectory"></param>
        public static void InstallPlugin(string pluginFullDirectory)
        {
            IEnumerable<string> dllFiles = GetPluginFiles(pluginFullDirectory);
            foreach (string dllFileName in dllFiles)//加载这些文件
                try
                {
                    InstallAssembly(dllFileName);
                }
                catch (Exception ex)
                {
                    Core.Log.Error("插件安装失败(" + dllFileName + ")", ex);
                }
        }

        /// <summary>
        /// 卸载插件
        /// </summary>
        /// <param name="classFullName"></param>
        public static void UnInstallPlugin(string classFullName)
        {
            List<PluginInfo> allPlugins = new List<PluginInfo>();
            foreach (var pluginsList in IntalledPlugins.Values)
            {
                allPlugins.AddRange(pluginsList);
            }
            PluginInfo pluginInfo = allPlugins.FirstOrDefault(item => item.ClassFullName == classFullName);
            if (pluginInfo == null)
                Log.Warn(string.Format("卸载插件{0}时没有找到插件信息", classFullName));
            else
            {
                foreach (var pluginType in pluginInfo.PluginTypes)
                    IntalledPlugins[pluginType].Remove(pluginInfo);//从已安装列表中移除该插件
                try
                {
                    System.IO.Directory.Delete(pluginInfo.PluginDirectory, true);
                }
                catch
                {
                    Log.Warn(string.Format("移除插件{0}时没有找到对应的插件目录", pluginInfo.PluginId));
                }
            }
        }

        /// <summary>
        /// 获取指定类型所有插件
        /// </summary>
        /// <typeparam name="T">插件类型</typeparam>
        /// <returns></returns>
        public static IEnumerable<Plugin<T>> GetPlugins<T>() where T : IPlugin
        {
            var pluginType = GetPluginTypeByType(typeof(T));
            var pluginInfos = GetInstalledPluginInfos(pluginType);

            int length = pluginInfos.Count();
            Plugin<T>[] plugins = new Plugin<T>[length];
            for (var i = 0; i < length; i++)
            {
                plugins[i] = new Plugin<T>()
                {
                    Biz = Instance.Get<T>(pluginInfos.ElementAt(i).ClassFullName),
                    PluginInfo = pluginInfos.ElementAt(i)
                };
            }
            return plugins;
        }

        /// <summary>
        /// 获取指定id的插件
        /// </summary>
        /// <typeparam name="T">插件类型</typeparam>
        /// <param name="pluginId">插件Id</param>
        /// <returns></returns>
        public static Plugin<T> GetPlugin<T>(string pluginId) where T : IPlugin
        {
            var pluginInfo = GetPluginInfo(pluginId);
            Plugin<T> plugin = new Plugin<T>()
            {
                PluginInfo = pluginInfo,
                Biz = Instance.Get<T>(pluginInfo.ClassFullName)
            };
            return plugin;
        }

        /// <summary>
        /// 开启插件
        /// </summary>
        /// <param name="pluginId">插件Id</param>
        /// <param name="enable">是否开启</param>
        public static void EnablePlugin(string pluginId, bool enable)
        {
            try
            {
                var plugin = GetPlugin<IPlugin>(pluginId);
                if (enable)//检查是否可以开启
                    plugin.Biz.CheckCanEnable();
                EnablePlugin_Private(pluginId, enable);
            }
            catch
            {
                throw;
            }
        }


        public static void UninstallPlugin(string pluginId)
        {
            throw new NotImplementedException();
        }


        public static IEnumerable<Plugin<T>> GetPlugins<T>(bool onlyEnabled) where T : IPlugin
        {
            var commonPlugins = GetPlugins<T>();
            if (onlyEnabled)
                commonPlugins = commonPlugins.Where(item => item.PluginInfo.Enable);
            return commonPlugins;
        }

        static PluginType GetPluginTypeByType(Type pluginType)
        {
            PluginType enum_pluginType;
            if (pluginType == typeof(IPaymentPlugin))
                enum_pluginType = PluginType.PayPlugin;
            else if (pluginType == typeof(IExpress))
                enum_pluginType = PluginType.Express;
            else if (pluginType == typeof(IOAuthPlugin))
                enum_pluginType = PluginType.OauthPlugin;
            else if (pluginType == typeof(IMessagePlugin))
                enum_pluginType = PluginType.Message;
            else if (pluginType == typeof(ISMSPlugin))
                enum_pluginType = PluginType.SMS;
            else if (pluginType == typeof(IEmailPlugin))
                enum_pluginType = PluginType.Email;
            else
                throw new NotSupportedException("暂不支持" + pluginType.Name + "类型的插件");
            return enum_pluginType;
        }

        /// <summary>
        /// 加载(安装)dll 
        /// </summary>
        /// <param name="dllFileName"></param>
        /// <returns></returns>
        static Assembly InstallAssembly(string dllFileName)
        {

            string newFileName = dllFileName;
            FileInfo fileInfo = new FileInfo(dllFileName);
            DirectoryInfo copyFolder;

            if (!string.IsNullOrWhiteSpace(AppDomain.CurrentDomain.DynamicDirectory))
            {
                //获取asp.net dll运行目录
                copyFolder = new DirectoryInfo(AppDomain.CurrentDomain.DynamicDirectory);
            }
            else
                copyFolder = new DirectoryInfo(IOHelper.GetMapPath(""));

            newFileName = copyFolder.FullName + "\\" + fileInfo.Name;

            Assembly assembly = null;
            PluginInfo pluginfo = null;
            try
            {
                try
                {
                    System.IO.File.Copy(dllFileName, newFileName, true);
                }
                catch
                {
                    //在某些情况下会出现"正由另一进程使用，因此该进程无法访问该文件"错误，所以先重命名再复制
                    File.Move(newFileName, newFileName + Guid.NewGuid().ToString("N") + ".locked");
                    System.IO.File.Copy(dllFileName, newFileName, true);
                }

                assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(newFileName);

                //排除以 MCS.Plugin 开头的，非插件的dll，主要是插件基类
                if (assembly.FullName.StartsWith("MCS.Plugin") && !assembly.FullName.Contains("MCS.Plugin.Payment.Alipay.Base"))
                {

                    pluginfo = AddPluginInfo(fileInfo);//添加插件信息

                    //向插件注入信息
                    IPlugin plugin = Core.Instance.Get<IPlugin>(pluginfo.ClassFullName);
                    plugin.WorkDirectory = fileInfo.Directory.FullName;
                    plugin.Regist(services);

                }

            }
            catch (IOException ex)
            {
                Log.Error("插件复制失败(" + dllFileName + ")！", ex);
                if (pluginfo != null)//插件复制失败时，移除插件安装信息
                    RemovePlugin(pluginfo);
            }
            catch (Exception ex)
            {
                Log.Error("插件加载失败(" + dllFileName + ")！", ex);
                if (pluginfo != null)//插件加载失败时，移除插件安装信息
                    RemovePlugin(pluginfo);
            }

            return assembly;
        }

        /// <summary>
        /// 添加插件信息
        /// </summary>
        /// <param name="dllFile"></param>
        static PluginInfo AddPluginInfo(FileInfo dllFile)
        {
            PluginInfo pluginInfo;
            string pluginId = dllFile.Name.Replace(".dll", "");
            string installedConfigPath = IOHelper.GetMapPath("/Plugins/Configs/") + pluginId + ".config";
            string webPath = "/Plugins/Configs/" + pluginId + ".config";

            if (!MCSIO.ExistFile(webPath))//检查是否已经安装过
            {
                //未安装过

                //查找插件自带的配置文件
                FileInfo[] configFiles = dllFile.Directory.GetFiles("plugin.config", SearchOption.TopDirectoryOnly);
                if (configFiles.Length > 0)
                {

                    //读取插件自带的配置信息
                    pluginInfo = (PluginInfo)XmlHelper.DeserializeFromXMLByOSS(typeof(PluginInfo), configFiles[0].FullName);

                    //使用程序集名称为插件唯一标识
                    pluginInfo.PluginId = pluginId;

                    //记录插件所在目录
                    pluginInfo.PluginDirectory = dllFile.Directory.FullName;

                    //更新插件时间
                    pluginInfo.AddedTime = DateTime.Now;

                    //序列化,将插件信息保存到系统插件配置文件中
                    XmlHelper.SerializeToXmlByOSS(pluginInfo, installedConfigPath);
                }
                else
                    throw new FileNotFoundException("未找到插件" + pluginId + "的配置文件");

            }
            else
            {
                //读取系统插件配置文件中的配置信息
                pluginInfo = (PluginInfo)XmlHelper.DeserializeFromXMLByOSS(typeof(PluginInfo), installedConfigPath);
            }

            //将插件信息保存至内存插件列表中
            UpdatePluginList(pluginInfo);

            return pluginInfo;
        }

        /// <summary>
        /// 更新插件列表
        /// </summary>
        /// <param name="plugin"></param>
        static void UpdatePluginList(PluginInfo plugin)
        {
            foreach (var pluginType in plugin.PluginTypes)
                IntalledPlugins[pluginType].Add(plugin);
        }

        static void RemovePlugin(PluginInfo plugin)
        {
            foreach (var pluginType in plugin.PluginTypes)
                IntalledPlugins[pluginType].Remove(plugin);
        }

        /// <summary>
        /// 获取插件程序集文件
        /// </summary>
        /// <param name="pluginDirectory">插件所在目录</param>
        /// <returns></returns>
        static IEnumerable<string> GetPluginFiles(string pluginDirectory)
        {
            if (!Directory.Exists(pluginDirectory))
                throw new MCSException("未能找到指定的插件目录:" + pluginDirectory);

            //搜索当前目录(包括子目录)下所有dll文件
            string[] dllFiles = System.IO.Directory.GetFiles(pluginDirectory, "*.dll", System.IO.SearchOption.AllDirectories);
            return dllFiles;
        }

        /// <summary>
        /// 深复制IPlugin
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        static PluginInfo DeepClone(PluginInfo plugin)
        {
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(plugin);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PluginInfo>(jsonString);
        }

    }
}
