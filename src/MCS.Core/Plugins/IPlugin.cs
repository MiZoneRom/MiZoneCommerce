using Microsoft.Extensions.DependencyInjection;
using System;

namespace MCS.Core.Plugins
{
    public interface IPlugin
    {
        /// <summary>
        /// 插件工作目录
        /// </summary>
        string WorkDirectory { set; }

        /// <summary>
        /// 检查是否可以开启插件
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PluginConfigException"></exception>
        void CheckCanEnable();

        void Regist(IServiceCollection _services);
    }
}
